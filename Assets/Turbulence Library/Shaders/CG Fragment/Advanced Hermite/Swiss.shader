//
// Turbulence Library - GPU Noise Generator
// Developped by J�r�mie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/CG/Advanced Hermite/Swiss" 
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
		_Frequency ("Frequency", Float) = 0.25
		_Amplitude ("Amplitude", Float) = 1.0
		_Lacunarity ("Lacunarity", Float) = 1.92
		_Persistence ("Persistence", Float) = 0.65
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.0)
		_NoiseScale ("Noise Scale", Vector) = (1.0, 1.0, 1.0)
		_Contribution("Contribution", Float) = 0.5
		_Normalize("Normalize", Range(-1, 1)) = -1.0
		_AnimSpeed("Anim Speed", Float) = 0.0
		_Powered("Powered", Range(-1, 1)) = -1.0
		_RidgePower("Ridge Power", Range(1.0, 8.0)) = 1.0
		_RidgeOffset("Ridge Offset", Float) = 1.0
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
			//	Hermite3D_Deriv
			//	Hermite3D noise with derivatives
			//	returns float3( value, xderiv, yderiv, zderiv )
			//
			float4 Hermite3D_Deriv( float3 P )
			{
				//	establish our grid cell and unit position
				float3 Pi = floor(P);
				float3 Pf = P - Pi;

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
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

				//
				//	NOTE:  This stuff can be optimized further.
				//	But it also appears the compiler is doing a lot of that automatically for us anyway
				//

				//	drop things from three dimensions to two
				float4 ival_results_z, igrad_results_x_z, igrad_results_y_z;
				QuinticHermite( Pf.z, hash_gradx0, hash_gradx1, hash_grady0, hash_grady1, hash_gradz0, hash_gradz1, ival_results_z, igrad_results_x_z, igrad_results_y_z );

				float4 ival_results_y, igrad_results_x_y, igrad_results_z_y;
				QuinticHermite( Pf.y, 	float4( hash_gradx0.xy, hash_gradx1.xy ), float4( hash_gradx0.zw, hash_gradx1.zw ),
										float4( hash_gradz0.xy, hash_gradz1.xy ), float4( hash_gradz0.zw, hash_gradz1.zw ),
										float4( hash_grady0.xy, hash_grady1.xy ), float4( hash_grady0.zw, hash_grady1.zw ),
										ival_results_y, igrad_results_x_y, igrad_results_z_y );

				//	drop things from two dimensions to one
				float4 qh_results_x = QuinticHermite( Pf.y, float4(ival_results_z.xy, igrad_results_x_z.xy), float4(ival_results_z.zw, igrad_results_x_z.zw), float4( igrad_results_y_z.xy, 0.0, 0.0 ), float4( igrad_results_y_z.zw, 0.0, 0.0 ) );
				float4 qh_results_y = QuinticHermite( Pf.x, float4(ival_results_z.xz, igrad_results_y_z.xz), float4(ival_results_z.yw, igrad_results_y_z.yw), float4( igrad_results_x_z.xz, 0.0, 0.0 ), float4( igrad_results_x_z.yw, 0.0, 0.0 ) );
				float4 qh_results_z = QuinticHermite( Pf.x, float4(ival_results_y.xz, igrad_results_z_y.xz), float4(ival_results_y.yw, igrad_results_z_y.yw), float4( igrad_results_x_y.xz, 0.0, 0.0 ), float4( igrad_results_x_y.yw, 0.0, 0.0 ) );

				//	for each hermite curve calculate the derivative
				float deriv_x = QuinticHermiteDeriv( Pf.x, qh_results_x.x, qh_results_x.y, qh_results_x.z, qh_results_x.w );
				float deriv_y = QuinticHermiteDeriv( Pf.y, qh_results_y.x, qh_results_y.y, qh_results_y.z, qh_results_y.w );
				float deriv_z = QuinticHermiteDeriv( Pf.z, qh_results_z.x, qh_results_z.y, qh_results_z.z, qh_results_z.w );

				//	and also the final noise value off any one of them
				float finalpos = QuinticHermite( Pf.x, qh_results_x.x, qh_results_x.y, qh_results_x.z, qh_results_x.w );

				//	normalize and return results! :)
				return float4( finalpos, deriv_x, deriv_y, deriv_z ) * FINAL_NORM_VAL;
			}

			float4 ridge(float3 p, int powered, float ridgePower, float offset)
			{
				// Powered Ridge
				if(powered > 0)
				{
					return pow(offset - abs(4*Hermite3D_Deriv(p)), ridgePower);
				}
				else
				{
					return offset - abs(4*Hermite3D_Deriv(p));
				}
			}

			//
			// 3D Fractional Brownian Motion
			//
			float fBM(float3 p, int octaves, float3 offset, float2 scale, float3 turbulence, float turbulencePower, float frequency, float amplitude, float lacunarity, float persistence, int powered, float ridgePower, float ridgeOffset, float warp)
			{
				float sum = 0.0;
				float bias = 0.0;
				float3 dsum = float3(0.0, 0.0, 0.0);
				for (int i = 0; i < 20; i++)
				{
					if(i >= octaves) break;
					float4 n = 0.5 * (1 + ridge((p+offset+warp*dsum)*frequency, powered, ridgePower, ridgeOffset));
					sum += n.x*amplitude;
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
				
				if(_Displace > 0.0)
				{
					float3 turbulence;
					turbulence.x = tex2D(_TurbulenceMapX, _TurbulenceMapX_ST.xy * o.texcoord + _TurbulenceMapX_ST.zw).x;
					turbulence.y = tex2D(_TurbulenceMapY, _TurbulenceMapY_ST.xy * o.texcoord + _TurbulenceMapY_ST.zw).x;
					turbulence.z = tex2D(_TurbulenceMapZ, _TurbulenceMapZ_ST.xy * o.texcoord + _TurbulenceMapZ_ST.zw).x;
					v.vertex.y = fBM(float3(v.texcoord.xy, _Time*_AnimSpeed), _Octaves, _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _Lacunarity, _Persistence, _Powered, _RidgePower, _RidgeOffset, _Warp);
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
				float h = fBM(float3(i.texcoord.xy, _Time*_AnimSpeed), _Octaves, _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _Lacunarity, _Persistence, _Powered, _RidgePower, _RidgeOffset, _Warp);

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
