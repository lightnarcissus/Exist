//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/CG/Other/PolkaDot" 
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
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.5)
		_Contribution("Contribution", Float) = 0.45
		_Normalize("Normalize", Range(-1, 1)) = -1.0
		_AnimSpeed("Anim Speed", Float) = 0.0
		
		_RadiusLow("Radius Low", Range(0.0, 1.0)) = 0.0
		_RadiusHigh("Radius High", Range(0.0, 1.0)) = 1.0
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
			
			float _RadiusLow;
			float _RadiusHigh;

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
			float4 FAST32_hash_3D_Cell( float3 gridcell )	//	generates 4 different random numbers for the single given cell point
			{
				//    gridcell is assumed to be an integer coordinate

				//	TODO: 	these constants need tweaked to find the best possible noise.
				//			probably requires some kind of brute force computational searching or something....
				const float2 OFFSET = float2( 50.0, 161.0 );
				const float DOMAIN = 69.0;
				const float4 SOMELARGEFLOATS = float4( 635.298681, 682.357502, 668.926525, 588.255119 );
				const float4 ZINC = float4( 48.500388, 65.294118, 63.934599, 63.279683 );

				//	truncate the domain
				gridcell.xyz = gridcell - floor(gridcell * ( 1.0 / DOMAIN )) * DOMAIN;
				gridcell.xy += OFFSET.xy;
				gridcell.xy *= gridcell.xy;
				return frac( ( gridcell.x * gridcell.y ) * ( 1.0 / ( SOMELARGEFLOATS + gridcell.zzzz * ZINC ) ) );
			}

			//
			//	Falloff defined in XSquared
			//	( smoothly decrease from 1.0 to 0.0 as xsq increases from 0.0 to 1.0 )
			//	http://briansharpe.wordpress.com/2011/11/14/two-useful-interpolation-functions-for-noise-development/
			//
			float Falloff_Xsq_C1( float xsq ) { xsq = 1.0 - xsq; return xsq*xsq; }	// ( 1.0 - x*x )^2   ( Used by Humus for lighting falloff in Just Cause 2.  GPUPro 1 )
			float Falloff_Xsq_C2( float xsq ) { xsq = 1.0 - xsq; return xsq*xsq*xsq; }	// ( 1.0 - x*x )^3.   NOTE: 2nd derivative is 0.0 at x=1.0, but non-zero at x=0.0
			float4 Falloff_Xsq_C2( float4 xsq ) { xsq = 1.0 - xsq; return xsq*xsq*xsq; }

			//
			//	PolkaDot Noise 3D
			//	http://briansharpe.files.wordpress.com/2011/12/polkadotsample.jpg
			//	http://briansharpe.files.wordpress.com/2012/01/polkaboxsample.jpg
			//	TODO, these images have random intensity and random radius.  This noise now has intensity as proportion to radius.  Images need updated.  TODO
			//
			//	Generates a noise of smooth falloff polka dots.
			//	Allow for control on radius.  Intensity is proportional to radius
			//	Return value range of 0.0->1.0
			//
			float PolkaDot3D( 	float3 P,
								float radius_low,		//	radius range is 0.0->1.0
								float radius_high	)
			{
				//	establish our grid cell and unit position
				float3 Pi = floor(P);
				float3 Pf = P - Pi;

				//	calculate the hash.
				float4 hash = FAST32_hash_3D_Cell( Pi );

				//	user variables
				float RADIUS = max( 0.0, radius_low + hash.w * ( radius_high - radius_low ) );
				float VALUE = RADIUS / max( radius_high, radius_low );	//	new keep value in proportion to radius.  Behaves better when used for bumpmapping, distortion and displacement

				//	calc the noise and return
				RADIUS = 2.0/RADIUS;
				Pf *= RADIUS;
				Pf -= ( RADIUS - 1.0 );
				Pf += hash.xyz * ( RADIUS - 2.0 );
				//Pf *= Pf;		//	this gives us a cool box looking effect
				return Falloff_Xsq_C2( min( dot( Pf, Pf ), 1.0 ) ) * VALUE;
			}

			//
			// 3D Fractional Brownian Motion
			//
			float fBM(float3 p, float3 offset, float2 scale, float3 turbulence, float turbulencePower, float frequency, float amplitude, float radiusLow, float radiusHigh)
			{
				float h = 0.0;
				h = PolkaDot3D((float3(p.x*scale.x+turbulence.x*turbulencePower, p.y*scale.y+turbulence.y*turbulencePower, p.z+turbulence.z*turbulencePower)+offset) * frequency, radiusLow, radiusHigh);
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
					v.vertex.y = fBM(float3(v.texcoord.xy, _Time*_AnimSpeed), _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _RadiusLow, _RadiusHigh);
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
				float h = fBM(float3(i.texcoord.xy, _Time*_AnimSpeed), _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _RadiusLow, _RadiusHigh);

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
