//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/CG/Perlin/Standard" 
{
	Properties 
	{
		_Octaves ("Octaves", Range(0, 20)) = 10
		_LowColor("Low Color", Vector) = (0.0, 0.0, 0.0, 1.0)
		_HighColor("High Color", Vector) = (1.0, 1.0, 1.0, 1.0)
		_Texturing("Texturing", Range(-1, 1)) = -1.0
		_LowTexture("Low Texture", 2D) = "" {} 
		_HighTexture("High Texture", 2D) = "" {}
		_TurbulenceMapX("Turbulence Map X", 2D) = "black" {}
		_TurbulenceMapY("Turbulence Map Y", 2D) = "black" {}
		_TurbulenceMapZ("Turbulence Map Z", 2D) = "black" {}
		_TurbulencePower("Turbulence Power", Float) = 1.0
		_Displace("Displace", Range(-1, 1)) = -1.0
		_Frequency ("Frequency", Float) = 0.5
		_Amplitude ("Amplitude", Float) = 1.0
		_Lacunarity ("Lacunarity", Float) = 1.92
		_Persistence ("Persistence", Float) = 0.6
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.0)
		_NoiseScale ("Noise Scale", Vector) = (1.0, 1.0, 1.0)
		_Contribution("Contribution", Float) = 1.0
		_Normalize("Normalize", Range(-1, 1)) = 1.0
		_AnimSpeed("Anim Speed", Float) = 0.0
	}

	CGINCLUDE
	#include "UnityCG.cginc"
	ENDCG
	
	SubShader 
	{
		Pass
		{
			// Additive blending - Add result to whatever is on the screen
			//Blend One One
		
			CGPROGRAM

			#pragma target 3.0
			#pragma glsl
			#pragma vertex vert
			#pragma fragment frag
			
			int _Octaves;
			float _Displace;
			float4 _LowColor;
			float4 _HighColor;
			float _Texturing;
			sampler2D _LowTexture;
			float4 _LowTexture_ST;
			sampler2D _HighTexture;
			float4 _HighTexture_ST;
			sampler2D _TurbulenceMapX;
			float4 _TurbulenceMapX_ST;
			sampler2D _TurbulenceMapY;
			float4 _TurbulenceMapY_ST;
			sampler2D _TurbulenceMapZ;
			float4 _TurbulenceMapZ_ST;
			float _TurbulencePower;
			float _Frequency;
			float _Amplitude;
			float3 _NoiseOffset;
			float2 _NoiseScale;
			float _Contribution;
			int _Normalize;
			float _AnimSpeed;
			float _Lacunarity;
			float _Persistence;

			//
			//	FAST32_hash
			//	A very fast hashing function.  Requires 32bit support.
			//	http://briansharpe.wordpress.com/2011/11/15/a-fast-and-simple-32bit-floating-point-hash-function/
			//
			//	The hash formula takes the form....
			//	hash = mod( coord.x * coord.x * coord.y * coord.y, SOMELARGEFLOAT ) / SOMELARGEFLOAT
			//  We truncate and offset the domain to the most interesting part of the noise.
			//	SOMELARGEFLOAT should be in the range of 400.0->1000.0 and needs to be hand picked.  Only some give good results.
			//	3D Noise is achieved by offsetting the SOMELARGEFLOAT value by the Z coordinate
			//
			void FAST32_hash_3D( 	float3 gridcell,
									out float4 lowz_hash_0,
									out float4 lowz_hash_1,
									out float4 lowz_hash_2,
									out float4 highz_hash_0,
									out float4 highz_hash_1,
									out float4 highz_hash_2	)		//	generates 3 random numbers for each of the 8 cell corners
			{
				//    gridcell is assumed to be an integer coordinate

				//	TODO: 	these constants need tweaked to find the best possible noise.
				//			probably requires some kind of brute force computational searching or something....
				const float2 OFFSET = float2( 50.0, 161.0 );
				const float DOMAIN = 69.0;
				const float3 SOMELARGEFLOATS = float3( 635.298681, 682.357502, 668.926525 );
				const float3 ZINC = float3( 48.500388, 65.294118, 63.934599 );

				//	truncate the domain
				gridcell.xyz = gridcell.xyz - floor(gridcell.xyz * ( 1.0 / DOMAIN )) * DOMAIN;
				float3 gridcell_inc1 = step( gridcell, float3( DOMAIN - 1.5 ) ) * ( gridcell + 1.0 );

				//	calculate the noise
				float4 P = float4( gridcell.xy, gridcell_inc1.xy ) + OFFSET.xyxy;
				P *= P;
				P = P.xzxz * P.yyww;
				float3 lowz_mod = float3( 1.0 / ( SOMELARGEFLOATS.xyz + gridcell.zzz * ZINC.xyz ) );
				float3 highz_mod = float3( 1.0 / ( SOMELARGEFLOATS.xyz + gridcell_inc1.zzz * ZINC.xyz ) );
				lowz_hash_0 = frac( P * lowz_mod.xxxx );
				highz_hash_0 = frac( P * highz_mod.xxxx );
				lowz_hash_1 = frac( P * lowz_mod.yyyy );
				highz_hash_1 = frac( P * highz_mod.yyyy );
				lowz_hash_2 = frac( P * lowz_mod.zzzz );
				highz_hash_2 = frac( P * highz_mod.zzzz );
			}

			float3 Interpolation_C2( float3 x ) 
			{ 
				return x * x * x * (x * (x * 6.0 - 15.0) + 10.0); 
			}

			//
			//	Perlin Noise 3D  ( gradient noise )
			//	Return value range of -1.0->1.0
			//	http://briansharpe.files.wordpress.com/2011/11/perlinsample.jpg
			//
			float Perlin3D( float3 P )
			{
				//	establish our grid cell and unit position
				float3 Pi = floor(P);
				float3 Pf = P - Pi;
				float3 Pf_min1 = Pf - 1.0;

			#if 1
				//
				//	classic noise.
				//	requires 3 random values per point.  with an efficent hash function will run faster than improved noise
				//

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
				float4 hashx0, hashy0, hashz0, hashx1, hashy1, hashz1;
				FAST32_hash_3D( Pi, hashx0, hashy0, hashz0, hashx1, hashy1, hashz1 );
				//SGPP_hash_3D( Pi, hashx0, hashy0, hashz0, hashx1, hashy1, hashz1 );

				//	calculate the gradients
				float4 grad_x0 = hashx0 - 0.49999;
				float4 grad_y0 = hashy0 - 0.49999;
				float4 grad_z0 = hashz0 - 0.49999;
				float4 grad_x1 = hashx1 - 0.49999;
				float4 grad_y1 = hashy1 - 0.49999;
				float4 grad_z1 = hashz1 - 0.49999;
				float4 grad_results_0 = rsqrt( grad_x0 * grad_x0 + grad_y0 * grad_y0 + grad_z0 * grad_z0 ) * ( float2( Pf.x, Pf_min1.x ).xyxy * grad_x0 + float2( Pf.y, Pf_min1.y ).xxyy * grad_y0 + Pf.zzzz * grad_z0 );
				float4 grad_results_1 = rsqrt( grad_x1 * grad_x1 + grad_y1 * grad_y1 + grad_z1 * grad_z1 ) * ( float2( Pf.x, Pf_min1.x ).xyxy * grad_x1 + float2( Pf.y, Pf_min1.y ).xxyy * grad_y1 + Pf_min1.zzzz * grad_z1 );

			#if 1
				//	Classic Perlin Interpolation
				float3 blend = Interpolation_C2( Pf );
				float4 res0 = lerp( grad_results_0, grad_results_1, blend.z );
				float2 res1 = lerp( res0.xy, res0.zw, blend.y );
				float final = lerp( res1.x, res1.y, blend.x );
				final *= 1.1547005383792515290182975610039;		//	(optionally) scale things to a strict -1.0->1.0 range    *= 1.0/sqrt(0.75)
				return final;
			#else
				//	Classic Perlin Surflet
				//	http://briansharpe.wordpress.com/2012/03/09/modifications-to-classic-perlin-noise/
				Pf *= Pf;
				Pf_min1 *= Pf_min1;
				float4 vecs_len_sq = float4( Pf.x, Pf_min1.x, Pf.x, Pf_min1.x ) + float4( Pf.yy, Pf_min1.yy );
				float final = dot( Falloff_Xsq_C2( min( float4( 1.0 ), vecs_len_sq + Pf.zzzz ) ), grad_results_0 ) + dot( Falloff_Xsq_C2( min( float4( 1.0 ), vecs_len_sq + Pf_min1.zzzz ) ), grad_results_1 );
				final *= 2.3703703703703703703703703703704;		//	(optionally) scale things to a strict -1.0->1.0 range    *= 1.0/cube(0.75)
				return final;
			#endif

			#else
				//
				//	improved noise.
				//	requires 1 random value per point.  Will run faster than classic noise if a slow hashing function is used
				//

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
				float4 hash_lowz, hash_highz;
				FAST32_hash_3D( Pi, hash_lowz, hash_highz );
				//BBS_hash_3D( Pi, hash_lowz, hash_highz );
				//SGPP_hash_3D( Pi, hash_lowz, hash_highz );

				//
				//	"improved" noise using 8 corner gradients.  Faster than the 12 mid-edge point method.
				//	Ken mentions using diagonals like this can cause "clumping", but we'll live with that.
				//	[1,1,1]  [-1,1,1]  [1,-1,1]  [-1,-1,1]
				//	[1,1,-1] [-1,1,-1] [1,-1,-1] [-1,-1,-1]
				//
				hash_lowz -= 0.5;
				float4 grad_results_0_0 = float2( Pf.x, Pf_min1.x ).xyxy * sign( hash_lowz );
				hash_lowz = abs( hash_lowz ) - 0.25;
				float4 grad_results_0_1 = float2( Pf.y, Pf_min1.y ).xxyy * sign( hash_lowz );
				float4 grad_results_0_2 = Pf.zzzz * sign( abs( hash_lowz ) - 0.125 );
				float4 grad_results_0 = grad_results_0_0 + grad_results_0_1 + grad_results_0_2;

				hash_highz -= 0.5;
				float4 grad_results_1_0 = float2( Pf.x, Pf_min1.x ).xyxy * sign( hash_highz );
				hash_highz = abs( hash_highz ) - 0.25;
				float4 grad_results_1_1 = float2( Pf.y, Pf_min1.y ).xxyy * sign( hash_highz );
				float4 grad_results_1_2 = Pf_min1.zzzz * sign( abs( hash_highz ) - 0.125 );
				float4 grad_results_1 = grad_results_1_0 + grad_results_1_1 + grad_results_1_2;

				//	blend the gradients and return
				float3 blend = Interpolation_C2( Pf );
				float4 res0 = lerp( grad_results_0, grad_results_1, blend.z );
				float2 res1 = lerp( res0.xy, res0.zw, blend.y );
				return lerp( res1.x, res1.y, blend.x ) * (2.0 / 3.0);	//	(optionally) mult by (2.0/3.0) to scale to a strict -1.0->1.0 range

			#endif

			}

			//
			// 3D Fractional Brownian Motion
			//
			float fBM(float3 p, int octaves, float3 offset, float2 scale, float3 turbulence, float turbulencePower, float frequency, float amplitude, float lacunarity, float persistence)
			{
				float sum = 0.0;
				for (int i = 0; i < 20; i++)
				{
					if(i >= octaves) break;
					float h = Perlin3D((float3(p.x*scale.x+turbulence.x*turbulencePower, p.y*scale.y+turbulence.y*turbulencePower, p.z+turbulence.z*turbulencePower)+offset) * frequency);
					sum += h*amplitude;
					frequency *= lacunarity;
					amplitude *= persistence;
				}
				return sum;
			}

			//
			// Vertex shader
			//
			
			struct v2f 
			{
				float4 position : POSITION;
				float4 worldPos : TEXCOORD1;
				float2 texcoord : TEXCOORD0;
			};

			v2f vert (appdata_base v)
			{
				v2f o;
				
				if(_Displace > 0.0)
				{
					float3 turbulence;
					turbulence.x = tex2D(_TurbulenceMapX, _TurbulenceMapX_ST.xy * o.texcoord + _TurbulenceMapX_ST.zw).x;
					turbulence.y = tex2D(_TurbulenceMapY, _TurbulenceMapY_ST.xy * o.texcoord + _TurbulenceMapY_ST.zw).x;
					turbulence.z = tex2D(_TurbulenceMapZ, _TurbulenceMapZ_ST.xy * o.texcoord + _TurbulenceMapZ_ST.zw).x;
					v.vertex.y = fBM(float3(v.texcoord.xy, _Time*_AnimSpeed), _Octaves, _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _Lacunarity, _Persistence);
				}
				o.worldPos = mul(_Object2World, v.vertex);
				o.position = mul(UNITY_MATRIX_MVP, v.vertex);
				o.texcoord = v.texcoord.xy * 5.0;
				return o;
			}

			//
			// Fragment shader
			//

			float4 frag (v2f i) : COLOR
			{
				float3 turbulence;
				turbulence.x = tex2D(_TurbulenceMapX, _TurbulenceMapX_ST.xy * i.texcoord + _TurbulenceMapX_ST.zw).x;
				turbulence.y = tex2D(_TurbulenceMapY, _TurbulenceMapY_ST.xy * i.texcoord + _TurbulenceMapY_ST.zw).x;
				turbulence.z = tex2D(_TurbulenceMapZ, _TurbulenceMapZ_ST.xy * i.texcoord + _TurbulenceMapZ_ST.zw).x;
				float h = fBM(float3(i.texcoord.xy, _Time*_AnimSpeed), _Octaves, _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _Lacunarity, _Persistence);

				if(_Normalize > 0)
				{
					// set range to (0, 1)
					h = (h + 1.0)/2.0;
				}
				
				// do the accumulation with the previous fixed-point height
				h = h*_Contribution;
				
				float4 color;
				float4 lowTexColor = tex2D(_LowTexture, _LowTexture_ST.xy * i.texcoord + _LowTexture_ST.zw);
				float4 highTexColor = tex2D(_HighTexture, _HighTexture_ST.xy * i.texcoord + _HighTexture_ST.zw);

				if(_Texturing > 0.0)
				{
					color = lerp(_LowColor * lowTexColor, _HighColor * highTexColor, h);
				}
				else
				{
					color = lerp(_LowColor, _HighColor, h);
				}
				
				return float4(color.r, color.g, color.b, h);
			}

			ENDCG
		}
	} 
	FallBack "VertexLit"
}
