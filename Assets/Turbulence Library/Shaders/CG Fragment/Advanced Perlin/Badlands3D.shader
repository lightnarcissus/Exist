//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/CG/Advanced Perlin/Badlands3D" 
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
		_Frequency ("Frequency", Float) = 0.25
		_Amplitude ("Amplitude", Float) = 0.6
		_Lacunarity ("Lacunarity", Float) = 1.92
		_Persistence ("Persistence", Float) = 0.75
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.0)
		_NoiseScale ("Noise Scale", Vector) = (1.0, 1.0, 1.0)
		_Contribution("Contribution", Float) = 0.5
		_Normalize("Normalize", Range(-1, 1)) = -1.0
		_Floor ("Floor", Float) = 0.5
		_Powered("Powered", Range(-1, 1)) = 1.0
		_RidgePower("Ridge Power", Range(1.0, 8.0)) = 1.0
		_RidgeOffset("Ridge Offset", Float) = 0.3
		_Warp("Warp", Float) = 0.15
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
			float3 _NoiseScale;
			float _Contribution;
			int _Normalize;
			float _Lacunarity;
			float _Persistence;
			float _Floor;
			int _Powered;
			float _RidgePower;
			float _RidgeOffset;
			float _Warp;

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

			//
			//	PerlinSurflet3D_Deriv
			//	Perlin Surflet 3D noise with derivatives
			//	returns float4( value, xderiv, yderiv, zderiv )
			//
			float4 PerlinSurflet3D_Deriv( float3 P )
			{
				//	establish our grid cell and unit position
				float3 Pi = floor(P);
				float3 Pf = P - Pi;
				float3 Pf_min1 = Pf - 1.0;

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
				float4 hashx0, hashy0, hashz0, hashx1, hashy1, hashz1;
				FAST32_hash_3D( Pi, hashx0, hashy0, hashz0, hashx1, hashy1, hashz1 );
				//SGPP_hash_3D( Pi, hashx0, hashy0, hashz0, hashx1, hashy1, hashz1 );

				//	calculate the gradients
				float4 grad_x0 = hashx0 - 0.49999;
				float4 grad_y0 = hashy0 - 0.49999;
				float4 grad_z0 = hashz0 - 0.49999;
				float4 norm_0 = rsqrt( grad_x0 * grad_x0 + grad_y0 * grad_y0 + grad_z0 * grad_z0 );
				grad_x0 *= norm_0;
				grad_y0 *= norm_0;
				grad_z0 *= norm_0;
				float4 grad_x1 = hashx1 - 0.49999;
				float4 grad_y1 = hashy1 - 0.49999;
				float4 grad_z1 = hashz1 - 0.49999;
				float4 norm_1 = rsqrt( grad_x1 * grad_x1 + grad_y1 * grad_y1 + grad_z1 * grad_z1 );
				grad_x1 *= norm_1;
				grad_y1 *= norm_1;
				grad_z1 *= norm_1;
				float4 grad_results_0 = float2( Pf.x, Pf_min1.x ).xyxy * grad_x0 + float2( Pf.y, Pf_min1.y ).xxyy * grad_y0 + Pf.zzzz * grad_z0;
				float4 grad_results_1 = float2( Pf.x, Pf_min1.x ).xyxy * grad_x1 + float2( Pf.y, Pf_min1.y ).xxyy * grad_y1 + Pf_min1.zzzz * grad_z1;

				//	get lengths in the x+y plane
				float3 Pf_sq = Pf*Pf;
				float3 Pf_min1_sq = Pf_min1*Pf_min1;
				float4 vecs_len_sq = float2( Pf_sq.x, Pf_min1_sq.x ).xyxy + float2( Pf_sq.y, Pf_min1_sq.y ).xxyy;

				//	evaluate the surflet
				float4 m_0 = vecs_len_sq + Pf_sq.zzzz;
				m_0 = max(1.0 - m_0, 0.0);
				float4 m2_0 = m_0*m_0;
				float4 m3_0 = m_0*m2_0;

				float4 m_1 = vecs_len_sq + Pf_min1_sq.zzzz;
				m_1 = max(1.0 - m_1, 0.0);
				float4 m2_1 = m_1*m_1;
				float4 m3_1 = m_1*m2_1;

				//	calc the deriv
				float4 temp_0 = -6.0 * m2_0 * grad_results_0;
				float xderiv_0 = dot( temp_0, float2( Pf.x, Pf_min1.x ).xyxy ) + dot( m3_0, grad_x0 );
				float yderiv_0 = dot( temp_0, float2( Pf.y, Pf_min1.y ).xxyy ) + dot( m3_0, grad_y0 );
				float zderiv_0 = dot( temp_0, Pf.zzzz ) + dot( m3_0, grad_z0 );

				float4 temp_1 = -6.0 * m2_1 * grad_results_1;
				float xderiv_1 = dot( temp_1, float2( Pf.x, Pf_min1.x ).xyxy ) + dot( m3_1, grad_x1 );
				float yderiv_1 = dot( temp_1, float2( Pf.y, Pf_min1.y ).xxyy ) + dot( m3_1, grad_y1 );
				float zderiv_1 = dot( temp_1, Pf_min1.zzzz ) + dot( m3_1, grad_z1 );

				const float FINAL_NORMALIZATION = 2.3703703703703703703703703703704;	//	scales the final result to a strict 1.0->-1.0 range
				return float4( dot( m3_0, grad_results_0 ) + dot( m3_1, grad_results_1 ) , float3(xderiv_0,yderiv_0,zderiv_0) + float3(xderiv_1,yderiv_1,zderiv_1) ) * FINAL_NORMALIZATION;
			}

			float4 ridge(float3 p, int powered, float ridgePower, float offset)
			{
				// Powered Ridge
				if(powered > 0)
				{
					return pow(offset - abs(4*PerlinSurflet3D_Deriv(p)), ridgePower);
				}
				else
				{
					return offset - abs(4*PerlinSurflet3D_Deriv(p));
				}
			}

			//
			// 3D Fractional Brownian Motion
			//
			float fBM(float3 p, int octaves, float floorV, float3 offset, float3 scale, float3 turbulence, float turbulencePower, float frequency, float amplitude, float lacunarity, float persistence, int powered, float ridgePower, float ridgeOffset, float warp)
			{
				float sum = floorV;
				float bias = 0.0;
				float3 dsum = float3(0.0, 0.0, 0.0);
				for (int i = 0; i < 20; i++)
				{
					if(i >= octaves) break;
					float4 n = 0.25 * (0 + ridge((float3(p.x*scale.x+turbulence.x*turbulencePower, p.y*scale.y+turbulence.y*turbulencePower, p.z*scale.z+turbulence.z*turbulencePower)+offset+warp*dsum)*frequency, powered, ridgePower, ridgeOffset));
					sum += amplitude * n.y * n.z * n.w;
					dsum += amplitude * n.yzw * -n.x;
					bias -= amplitude;
					frequency *= lacunarity;
					amplitude *= persistence * saturate(sum);
				}
				sum += 0.5 * bias;
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
				float h = fBM(float3(i.worldPos.xyz), _Octaves, _Floor, _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _Lacunarity, _Persistence, _Powered, _RidgePower, _RidgeOffset, _Warp);

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
