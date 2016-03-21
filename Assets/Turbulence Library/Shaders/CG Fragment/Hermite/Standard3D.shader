//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/CG/Hermite/Standard3D" 
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
		_Frequency ("Frequency", Float) = 0.5
		_Amplitude ("Amplitude", Float) = 1.0
		_Lacunarity ("Lacunarity", Float) = 1.92
		_Persistence ("Persistence", Float) = 0.6
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.0)
		_NoiseScale ("Noise Scale", Vector) = (1.0, 1.0, 1.0)
		_Contribution("Contribution", Float) = 1.0
		_Normalize("Normalize", Range(-1, 1)) = 1.0
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
			//	Quintic Hermite Interpolation
			//	http://www.rose-hulman.edu/~finn/CCLI/Notes/day09.pdf
			//
			//  NOTE: maximum value of a hermitequintic interpolation with zero acceleration at the endpoints would be...
			//        f(x=0.5) = MAXPOS + MAXVELOCITY * ( ( x - 6x^3 + 8x^4 - 3x^5 ) - ( -4x^3 + 7x^4 -3x^5 ) ) = MAXPOS + MAXVELOCITY * 0.3125
			//
			//	variable naming conventions:
			//	val = value ( position )
			//	grad = gradient ( velocity )
			//	x = 0.0->1.0 ( time )
			//	i = interpolation = a value to be interpolated
			//	e = evaluation = a value to be used to calculate the interpolation
			//	0 = start
			//	1 = end
			//
			float QuinticHermite( float x, float ival0, float ival1, float egrad0, float egrad1 )		// quintic hermite with start/end acceleration of 0.0
			{
				const float3 C0 = float3( -15.0, 8.0, 7.0 );
				const float3 C1 = float3( 6.0, -3.0, -3.0 );
				const float3 C2 = float3( 10.0, -6.0, -4.0 );
				float3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				return ival0 + dot( float3( (ival1 - ival0), egrad0, egrad1 ), h123.xyz + float3( 0.0, x, 0.0 ) );
			}
			float4 QuinticHermite( float x, float4 ival0, float4 ival1, float4 egrad0, float4 egrad1 )		// quintic hermite with start/end acceleration of 0.0
			{
				const float3 C0 = float3( -15.0, 8.0, 7.0 );
				const float3 C1 = float3( 6.0, -3.0, -3.0 );
				const float3 C2 = float3( 10.0, -6.0, -4.0 );
				float3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				return ival0 + (ival1 - ival0) * h123.xxxx + egrad0 * float4( h123.y + x ) + egrad1 * h123.zzzz;
			}
			float4 QuinticHermite( float x, float2 igrad0, float2 igrad1, float2 egrad0, float2 egrad1 )		// quintic hermite with start/end position and acceleration of 0.0
			{
				const float3 C0 = float3( -15.0, 8.0, 7.0 );
				const float3 C1 = float3( 6.0, -3.0, -3.0 );
				const float3 C2 = float3( 10.0, -6.0, -4.0 );
				float3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				return float4( egrad1, igrad0 ) * float4( h123.zz, 1.0, 1.0 ) + float4( egrad0, h123.xx ) * float4( float2( h123.y + x ), (igrad1 - igrad0) );	//	returns float4( out_ival.xy, out_igrad.xy )
			}
			void QuinticHermite( 	float x,
									float4 ival0, float4 ival1,			//	values are interpolated using the gradient arguments
									float4 igrad_x0, float4 igrad_x1, 	//	gradients are interpolated using eval gradients of 0.0
									float4 igrad_y0, float4 igrad_y1,
									float4 egrad0, float4 egrad1, 		//	our evaluation gradients
									out float4 out_ival, out float4 out_igrad_x, out float4 out_igrad_y )	// quintic hermite with start/end acceleration of 0.0
			{
				const float3 C0 = float3( -15.0, 8.0, 7.0 );
				const float3 C1 = float3( 6.0, -3.0, -3.0 );
				const float3 C2 = float3( 10.0, -6.0, -4.0 );
				float3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				out_ival = ival0 + (ival1 - ival0) * h123.xxxx + egrad0 * float4( h123.y + x ) + egrad1 * h123.zzzz;
				out_igrad_x = igrad_x0 + (igrad_x1 - igrad_x0) * h123.xxxx;	//	NOTE: gradients of 0.0
				out_igrad_y = igrad_y0 + (igrad_y1 - igrad_y0) * h123.xxxx;	//	NOTE: gradients of 0.0
			}
			void QuinticHermite( 	float x,
									float4 igrad_x0, float4 igrad_x1, 	//	gradients are interpolated using eval gradients of 0.0
									float4 igrad_y0, float4 igrad_y1,
									float4 egrad0, float4 egrad1, 		//	our evaluation gradients
									out float4 out_ival, out float4 out_igrad_x, out float4 out_igrad_y )	// quintic hermite with start/end position and acceleration of 0.0
			{
				const float3 C0 = float3( -15.0, 8.0, 7.0 );
				const float3 C1 = float3( 6.0, -3.0, -3.0 );
				const float3 C2 = float3( 10.0, -6.0, -4.0 );
				float3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				out_ival = egrad0 * float4( h123.y + x ) + egrad1 * h123.zzzz;
				out_igrad_x = igrad_x0 + (igrad_x1 - igrad_x0) * h123.xxxx;	//	NOTE: gradients of 0.0
				out_igrad_y = igrad_y0 + (igrad_y1 - igrad_y0) * h123.xxxx;	//	NOTE: gradients of 0.0
			}
			float QuinticHermiteDeriv( float x, float ival0, float ival1, float egrad0, float egrad1 )	// gives the derivative of quintic hermite with start/end acceleration of 0.0
			{
				const float3 C0 = float3( 30.0, -15.0, -15.0 );
				const float3 C1 = float3( -60.0, 32.0, 28.0 );
				const float3 C2 = float3( 30.0, -18.0, -12.0 );
				float3 h123 = ( ( ( C1 + C0 * x ) * x ) + C2 ) * ( x*x );
				return dot( float3( (ival1 - ival0), egrad0, egrad1 ), h123.xyz + float3( 0.0, 1.0, 0.0 ) );
			}

			//
			//	Hermite3D
			//	Return value range of -1.0->1.0
			//	http://briansharpe.files.wordpress.com/2012/01/hermitesample.jpg
			//
			float Hermite3D( float3 P )
			{
				//	establish our grid cell and unit position
				float3 Pi = floor(P);
				float3 Pf = P - Pi;

				//	calculate the hash.
				float4 hash_gradx0, hash_grady0, hash_gradz0, hash_gradx1, hash_grady1, hash_gradz1;
				FAST32_hash_3D( Pi, hash_gradx0, hash_grady0, hash_gradz0, hash_gradx1, hash_grady1, hash_gradz1 );

				//	scale the hash values
				hash_gradx0 = ( hash_gradx0 - 0.49999);
				hash_grady0 = ( hash_grady0 - 0.49999);
				hash_gradz0 = ( hash_gradz0 - 0.49999);
				hash_gradx1 = ( hash_gradx1 - 0.49999);
				hash_grady1 = ( hash_grady1 - 0.49999);
				hash_gradz1 = ( hash_gradz1 - 0.49999);

			#if 1
				//	normalize gradients
				float4 norm0 = rsqrt( hash_gradx0 * hash_gradx0 + hash_grady0 * hash_grady0 + hash_gradz0 * hash_gradz0 );
				hash_gradx0 *= norm0;
				hash_grady0 *= norm0;
				hash_gradz0 *= norm0;
				float4 norm1 = rsqrt( hash_gradx1 * hash_gradx1 + hash_grady1 * hash_grady1 + hash_gradz1 * hash_gradz1 );
				hash_gradx1 *= norm1;
				hash_grady1 *= norm1;
				hash_gradz1 *= norm1;
				const float FINAL_NORM_VAL = 1.8475208614068024464292760976063;
			#else
				//	unnormalized gradients
				const float FINAL_NORM_VAL = (1.0/0.46875);  // = 1.0 / ( 0.5 * 0.3125 * 3.0 )
			#endif

				//	evaluate the hermite
				float4 ival_results, igrad_results_x, igrad_results_y;
				QuinticHermite( Pf.z, hash_gradx0, hash_gradx1, hash_grady0, hash_grady1, hash_gradz0, hash_gradz1, ival_results, igrad_results_x, igrad_results_y );
				float4 qh_results = QuinticHermite( Pf.y, float4(ival_results.xy, igrad_results_x.xy), float4(ival_results.zw, igrad_results_x.zw), float4( igrad_results_y.xy, 0.0, 0.0 ), float4( igrad_results_y.zw, 0.0, 0.0 ) );
				return QuinticHermite( Pf.x, qh_results.x, qh_results.y, qh_results.z, qh_results.w ) * FINAL_NORM_VAL;
			}

			//
			// 3D Fractional Brownian Motion
			//
			float fBM(float3 p, int octaves, float3 offset, float3 scale, float3 turbulence, float turbulencePower, float frequency, float amplitude, float lacunarity, float persistence)
			{
				float sum = 0;
				for (int i = 0; i < 20; i++)
				{
					if(i >= octaves) break;
					float h = Hermite3D((float3(p.x*scale.x+turbulence.x*turbulencePower, p.y*scale.y+turbulence.y*turbulencePower, p.z*scale.z+turbulence.z*turbulencePower)+offset) * frequency);
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
				float h = fBM(float3(i.worldPos.xyz), _Octaves, _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _Lacunarity, _Persistence);

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
