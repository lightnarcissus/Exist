//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/CG/Other/CubistNoise" 
{
	Properties 
	{
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
		_Frequency ("Frequency", Float) = 1.0
		_Amplitude ("Amplitude", Float) = 1.0
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.0)
		_NoiseScale ("Noise Scale", Vector) = (1.0, 1.0, 1.0)
		_Contribution("Contribution", Float) = 0.45
		_Normalize("Normalize", Range(-1, 1)) = -1.0
		_AnimSpeed("Anim Speed", Float) = 0.0
		
		_RangeClamp("Range Clamp", Vector) = (-1.5, 0.5, 0.0)
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
			
			float2 _RangeClamp;

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
									out float4 lowz_hash_3,
									out float4 highz_hash_0,
									out float4 highz_hash_1,
									out float4 highz_hash_2,
									out float4 highz_hash_3	)		//	generates 4 random numbers for each of the 8 cell corners
			{
				//    gridcell is assumed to be an integer coordinate

				//	TODO: 	these constants need tweaked to find the best possible noise.
				//			probably requires some kind of brute force computational searching or something....
				const float2 OFFSET = float2( 50.0, 161.0 );
				const float DOMAIN = 69.0;
				const float4 SOMELARGEFLOATS = float4( 635.298681, 682.357502, 668.926525, 588.255119 );
				const float4 ZINC = float4( 48.500388, 65.294118, 63.934599, 63.279683 );

				//	truncate the domain
				gridcell.xyz = gridcell.xyz - floor(gridcell.xyz * ( 1.0 / DOMAIN )) * DOMAIN;
				float3 gridcell_inc1 = step( gridcell, float3( DOMAIN - 1.5 ) ) * ( gridcell + 1.0 );

				//	calculate the noise
				float4 P = float4( gridcell.xy, gridcell_inc1.xy ) + OFFSET.xyxy;
				P *= P;
				P = P.xzxz * P.yyww;
				lowz_hash_3.xyzw = float4( 1.0 / ( SOMELARGEFLOATS.xyzw + gridcell.zzzz * ZINC.xyzw ) );
				highz_hash_3.xyzw = float4( 1.0 / ( SOMELARGEFLOATS.xyzw + gridcell_inc1.zzzz * ZINC.xyzw ) );
				lowz_hash_0 = frac( P * lowz_hash_3.xxxx );
				highz_hash_0 = frac( P * highz_hash_3.xxxx );
				lowz_hash_1 = frac( P * lowz_hash_3.yyyy );
				highz_hash_1 = frac( P * highz_hash_3.yyyy );
				lowz_hash_2 = frac( P * lowz_hash_3.zzzz );
				highz_hash_2 = frac( P * highz_hash_3.zzzz );
				lowz_hash_3 = frac( P * lowz_hash_3.wwww );
				highz_hash_3 = frac( P * highz_hash_3.wwww );
			}

			float3 Interpolation_C2( float3 x ) 
			{ 
				return x * x * x * (x * (x * 6.0 - 15.0) + 10.0); 
			}

			//
			//	Cubist Noise 3D
			//	http://briansharpe.files.wordpress.com/2011/12/cubistsample.jpg
			//
			//	Generates a noise which resembles a cubist-style painting pattern.  Final Range 0.0->1.0
			//	NOTE:  contains discontinuities.  best used only for texturing.
			//	NOTE:  Any serious game implementation should hard-code these parameter values for efficiency.
			//
			float Cubist3D( float3 P, float2 range_clamp )	// range_clamp.x = low, range_clamp.y = 1.0/(high-low).  suggest value low=-2.0  high=1.0
			{
				//	establish our grid cell and unit position
				float3 Pi = floor(P);
				float3 Pf = P - Pi;
				float3 Pf_min1 = Pf - 1.0;

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
				float4 hashx0, hashy0, hashz0, hash_value0, hashx1, hashy1, hashz1, hash_value1;
				FAST32_hash_3D( Pi, hashx0, hashy0, hashz0, hash_value0, hashx1, hashy1, hashz1, hash_value1 );

				//	calculate the gradients
				float4 grad_x0 = hashx0 - 0.49999;
				float4 grad_y0 = hashy0 - 0.49999;
				float4 grad_z0 = hashz0 - 0.49999;
				float4 grad_x1 = hashx1 - 0.49999;
				float4 grad_y1 = hashy1 - 0.49999;
				float4 grad_z1 = hashz1 - 0.49999;
				float4 grad_results_0 = rsqrt( grad_x0 * grad_x0 + grad_y0 * grad_y0 + grad_z0 * grad_z0 ) * ( float2( Pf.x, Pf_min1.x ).xyxy * grad_x0 + float2( Pf.y, Pf_min1.y ).xxyy * grad_y0 + Pf.zzzz * grad_z0 );
				float4 grad_results_1 = rsqrt( grad_x1 * grad_x1 + grad_y1 * grad_y1 + grad_z1 * grad_z1 ) * ( float2( Pf.x, Pf_min1.x ).xyxy * grad_x1 + float2( Pf.y, Pf_min1.y ).xxyy * grad_y1 + Pf_min1.zzzz * grad_z1 );

				//	invert the gradient to convert from perlin to cubist
				grad_results_0 = ( hash_value0 - 0.5 ) * ( 1.0 / grad_results_0 );
				grad_results_1 = ( hash_value1 - 0.5 ) * ( 1.0 / grad_results_1 );

				//	blend the gradients and return
				float3 blend = Interpolation_C2( Pf );
				float4 res0 = lerp( grad_results_0, grad_results_1, blend.z );
				float2 res1 = lerp( res0.xy, res0.zw, blend.y );
				float final = lerp( res1.x, res1.y, blend.x );

				//	the 1.0/grad calculation pushes the result to a possible to +-infinity.  Need to clamp to keep things sane
				return clamp( ( final - range_clamp.x ) * range_clamp.y, 0.0, 1.0 );
				//return smoothstep( 0.0, 1.0, ( final - range_clamp.x ) * range_clamp.y );		//	experiments.  smoothstep doesn't look as good, but does remove some discontinuities....
			}

			//
			// 3D Fractional Brownian Motion
			//
			float fBM(float3 p, float3 offset, float2 scale, float3 turbulence, float turbulencePower, float frequency, float amplitude, float2 rangeClamp)
			{
				float h;
				h = Cubist3D((float3(p.x*scale.x+turbulence.x*turbulencePower, p.y*scale.y+turbulence.y*turbulencePower, p.z+turbulence.z*turbulencePower)+offset) * frequency, rangeClamp);
				h += h*amplitude;
				return h;
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
					v.vertex.y = fBM(float3(v.texcoord.xy, _Time*_AnimSpeed), _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _RangeClamp);
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
				float h = fBM(float3(i.texcoord.xy, _Time*_AnimSpeed), _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _RangeClamp);

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
