//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/CG/Other/SparseConvolution" 
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
			//	Falloff defined in XSquared
			//	( smoothly decrease from 1.0 to 0.0 as xsq increases from 0.0 to 1.0 )
			//	http://briansharpe.wordpress.com/2011/11/14/two-useful-interpolation-functions-for-noise-development/
			//
			float Falloff_Xsq_C1( float xsq ) { xsq = 1.0 - xsq; return xsq*xsq; }	// ( 1.0 - x*x )^2   ( Used by Humus for lighting falloff in Just Cause 2.  GPUPro 1 )
			float Falloff_Xsq_C2( float xsq ) { xsq = 1.0 - xsq; return xsq*xsq*xsq; }	// ( 1.0 - x*x )^3.   NOTE: 2nd derivative is 0.0 at x=1.0, but non-zero at x=0.0
			float4 Falloff_Xsq_C2( float4 xsq ) { xsq = 1.0 - xsq; return xsq*xsq*xsq; }

			//	convert a 0.0->1.0 sample to a -1.0->1.0 sample weighted towards the extremes
			float4 Cellular_weight_samples( float4 samples )
			{
				samples = samples * 2.0 - 1.0;
				//return (1.0 - samples * samples) * sign(samples);	// square
				return (samples * samples * samples) - sign(samples);	// cubic (even more variance)
			}

			//
			//	SparseConvolution3D
			//
			//	Very crude approximation of sparse convolution noise.  ( derived from the Cellular3D implementation )
			//	return value scaling to 0.0->1.0 range TODO
			//
			float SparseConvolution3D(float3 P)
			{
				//	establish our grid cell and unit position
				float3 Pi = floor(P);
				float3 Pf = P - Pi;

				//	calculate the hash.
				float4 hash_x0, hash_y0, hash_z0, hash_x1, hash_y1, hash_z1;
				FAST32_hash_3D( Pi, hash_x0, hash_y0, hash_z0, hash_x1, hash_y1, hash_z1 );

				//	generate the 8 random points
				//	restrict the random point offset to eliminate artifacts
				//	we'll improve the variance of the noise by pushing the points to the extremes of the jitter window
				const float JITTER_WINDOW = 0.166666666;	// 0.166666666 will guarentee no artifacts. It is the intersection on x of graphs f(x)=( (0.5 + (0.5-x))^2 + 2*((0.5-x)^2) ) and f(x)=( 2 * (( 0.5 + x )^2) + x * x )
				hash_x0 = Cellular_weight_samples( hash_x0 ) * JITTER_WINDOW + float4(0.0, 1.0, 0.0, 1.0);
				hash_y0 = Cellular_weight_samples( hash_y0 ) * JITTER_WINDOW + float4(0.0, 0.0, 1.0, 1.0);
				hash_x1 = Cellular_weight_samples( hash_x1 ) * JITTER_WINDOW + float4(0.0, 1.0, 0.0, 1.0);
				hash_y1 = Cellular_weight_samples( hash_y1 ) * JITTER_WINDOW + float4(0.0, 0.0, 1.0, 1.0);
				hash_z0 = Cellular_weight_samples( hash_z0 ) * JITTER_WINDOW + float4(0.0, 0.0, 0.0, 0.0);
				hash_z1 = Cellular_weight_samples( hash_z1 ) * JITTER_WINDOW + float4(1.0, 1.0, 1.0, 1.0);

				//	find the squared distance to each point
				float4 dx1 = Pf.xxxx - hash_x0;
				float4 dy1 = Pf.yyyy - hash_y0;
				float4 dz1 = Pf.zzzz - hash_z0;
				float4 dx2 = Pf.xxxx - hash_x1;
				float4 dy2 = Pf.yyyy - hash_y1;
				float4 dz2 = Pf.zzzz - hash_z1;
				float4 d1 = dx1 * dx1 + dy1 * dy1 + dz1 * dz1;
				float4 d2 = dx2 * dx2 + dy2 * dy2 + dz2 * dz2;

				//	sum kernels and return
				const float RADIUS = ( 1.0 - JITTER_WINDOW );
				d1 *= ( ( 1.0 / RADIUS ) * ( 1.0 / RADIUS ) );
				d2 *= ( ( 1.0 / RADIUS ) * ( 1.0 / RADIUS ) );
				return dot( Falloff_Xsq_C2( min( d1, float4( 1.0 ) ) ) + Falloff_Xsq_C2( min( d2, float4( 1.0 ) ) ), float4( 1.0 ) );
			}

			//
			// 3D Fractional Brownian Motion
			//
			float fBM(float3 p, float3 offset, float2 scale, float3 turbulence, float turbulencePower, float frequency, float amplitude)
			{
				float h = 0.0;
				h = SparseConvolution3D((float3(p.x*scale.x+turbulence.x*turbulencePower, p.y*scale.y+turbulence.y*turbulencePower, p.z+turbulence.z*turbulencePower)+offset) * frequency);
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
					v.vertex.y = fBM(float3(v.texcoord.xy, _Time*_AnimSpeed), _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude);
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
				float h = fBM(float3(i.texcoord.xy, _Time*_AnimSpeed), _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude);

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
