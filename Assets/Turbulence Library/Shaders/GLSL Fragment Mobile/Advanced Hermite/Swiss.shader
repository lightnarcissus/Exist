//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/Mobile/Advanced Hermite/Swiss" 
{
	Properties 
	{
		_LowColor("Low Color", Vector) = (0.0, 0.0, 0.0, 1.0)
		_HighColor("High Color", Vector) = (1.0, 1.0, 1.0, 1.0)
		_Texturing("Texturing", Range(-1, 1)) = -1.0
		_LowTexture("Low Texture", 2D) = "" {} 
		_HighTexture("High Texture", 2D) = "" {}
		_Displace("Displace", Range(-1, 1)) = -1.0
		_Frequency ("Frequency", Float) = 1.0
		_Amplitude ("Amplitude", Float) = 1.0
		_Lacunarity ("Lacunarity", Float) = 1.92
		_Persistence ("Persistence", Float) = 0.75
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.0)
		_Contribution("Contribution", Float) = 0.45
		_Normalize("Normalize", Range(-1, 1)) = -1.0
		_AnimSpeed("Anim Speed", Float) = 0.0
		
		_RidgePower("Ridge Power", Range(1.0, 8.0)) = 1.0
		_RidgeOffset("Ridge Offset", Float) = 1.0
		_Warp("Warp", Float) = 0.01
	}
	
	SubShader 
	{
		Pass
		{
			// Additive blending - Add result to whatever is on the screen
			// Blend One One
			
			GLSLPROGRAM

			precision mediump float;

			const int OCTAVES = 12; 
			
			uniform vec4 _Time;
			uniform float _Frequency;
			uniform float _Amplitude;
			uniform vec3 _NoiseOffset;
			uniform float _Contribution;
			uniform float _Normalize;
			uniform float _AnimSpeed;
			uniform float _Lacunarity;
			uniform float _Persistence;
			
			uniform float _RidgePower;
			uniform float _RidgeOffset;
			uniform float _Warp;

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
			void FAST32_hash_3D( 	vec3 gridcell,
									out vec4 lowz_hash_0,
									out vec4 lowz_hash_1,
									out vec4 lowz_hash_2,
									out vec4 highz_hash_0,
									out vec4 highz_hash_1,
									out vec4 highz_hash_2	)		//	generates 3 random numbers for each of the 8 cell corners
			{
				//    gridcell is assumed to be an integer coordinate

				//	TODO: 	these constants need tweaked to find the best possible noise.
				//			probably requires some kind of brute force computational searching or something....
				const vec2 OFFSET = vec2( 50.0, 161.0 );
				const float DOMAIN = 69.0;
				const vec3 SOMELARGEFLOATS = vec3( 635.298681, 682.357502, 668.926525 );
				const vec3 ZINC = vec3( 48.500388, 65.294118, 63.934599 );

				//	truncate the domain
				gridcell.xyz = gridcell.xyz - floor(gridcell.xyz * ( 1.0 / DOMAIN )) * DOMAIN;
				vec3 gridcell_inc1 = step( gridcell, vec3( DOMAIN - 1.5 ) ) * ( gridcell + 1.0 );

				//	calculate the noise
				vec4 P = vec4( gridcell.xy, gridcell_inc1.xy ) + OFFSET.xyxy;
				P *= P;
				P = P.xzxz * P.yyww;
				vec3 lowz_mod = vec3( 1.0 / ( SOMELARGEFLOATS.xyz + gridcell.zzz * ZINC.xyz ) );
				vec3 highz_mod = vec3( 1.0 / ( SOMELARGEFLOATS.xyz + gridcell_inc1.zzz * ZINC.xyz ) );
				lowz_hash_0 = fract( P * lowz_mod.xxxx );
				highz_hash_0 = fract( P * highz_mod.xxxx );
				lowz_hash_1 = fract( P * lowz_mod.yyyy );
				highz_hash_1 = fract( P * highz_mod.yyyy );
				lowz_hash_2 = fract( P * lowz_mod.zzzz );
				highz_hash_2 = fract( P * highz_mod.zzzz );
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
				const vec3 C0 = vec3( -15.0, 8.0, 7.0 );
				const vec3 C1 = vec3( 6.0, -3.0, -3.0 );
				const vec3 C2 = vec3( 10.0, -6.0, -4.0 );
				vec3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				return ival0 + dot( vec3( (ival1 - ival0), egrad0, egrad1 ), h123.xyz + vec3( 0.0, x, 0.0 ) );
			}
			vec4 QuinticHermite( float x, vec4 ival0, vec4 ival1, vec4 egrad0, vec4 egrad1 )		// quintic hermite with start/end acceleration of 0.0
			{
				const vec3 C0 = vec3( -15.0, 8.0, 7.0 );
				const vec3 C1 = vec3( 6.0, -3.0, -3.0 );
				const vec3 C2 = vec3( 10.0, -6.0, -4.0 );
				vec3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				return ival0 + (ival1 - ival0) * h123.xxxx + egrad0 * vec4( h123.y + x ) + egrad1 * h123.zzzz;
			}
			vec4 QuinticHermite( float x, vec2 igrad0, vec2 igrad1, vec2 egrad0, vec2 egrad1 )		// quintic hermite with start/end position and acceleration of 0.0
			{
				const vec3 C0 = vec3( -15.0, 8.0, 7.0 );
				const vec3 C1 = vec3( 6.0, -3.0, -3.0 );
				const vec3 C2 = vec3( 10.0, -6.0, -4.0 );
				vec3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				return vec4( egrad1, igrad0 ) * vec4( h123.zz, 1.0, 1.0 ) + vec4( egrad0, h123.xx ) * vec4( vec2( h123.y + x ), (igrad1 - igrad0) );	//	returns vec4( out_ival.xy, out_igrad.xy )
			}
			void QuinticHermite( 	float x,
									vec4 ival0, vec4 ival1,			//	values are interpolated using the gradient arguments
									vec4 igrad_x0, vec4 igrad_x1, 	//	gradients are interpolated using eval gradients of 0.0
									vec4 igrad_y0, vec4 igrad_y1,
									vec4 egrad0, vec4 egrad1, 		//	our evaluation gradients
									out vec4 out_ival, out vec4 out_igrad_x, out vec4 out_igrad_y )	// quintic hermite with start/end acceleration of 0.0
			{
				const vec3 C0 = vec3( -15.0, 8.0, 7.0 );
				const vec3 C1 = vec3( 6.0, -3.0, -3.0 );
				const vec3 C2 = vec3( 10.0, -6.0, -4.0 );
				vec3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				out_ival = ival0 + (ival1 - ival0) * h123.xxxx + egrad0 * vec4( h123.y + x ) + egrad1 * h123.zzzz;
				out_igrad_x = igrad_x0 + (igrad_x1 - igrad_x0) * h123.xxxx;	//	NOTE: gradients of 0.0
				out_igrad_y = igrad_y0 + (igrad_y1 - igrad_y0) * h123.xxxx;	//	NOTE: gradients of 0.0
			}
			void QuinticHermite( 	float x,
									vec4 igrad_x0, vec4 igrad_x1, 	//	gradients are interpolated using eval gradients of 0.0
									vec4 igrad_y0, vec4 igrad_y1,
									vec4 egrad0, vec4 egrad1, 		//	our evaluation gradients
									out vec4 out_ival, out vec4 out_igrad_x, out vec4 out_igrad_y )	// quintic hermite with start/end position and acceleration of 0.0
			{
				const vec3 C0 = vec3( -15.0, 8.0, 7.0 );
				const vec3 C1 = vec3( 6.0, -3.0, -3.0 );
				const vec3 C2 = vec3( 10.0, -6.0, -4.0 );
				vec3 h123 = ( ( ( C0 + C1 * x ) * x ) + C2 ) * ( x*x*x );
				out_ival = egrad0 * vec4( h123.y + x ) + egrad1 * h123.zzzz;
				out_igrad_x = igrad_x0 + (igrad_x1 - igrad_x0) * h123.xxxx;	//	NOTE: gradients of 0.0
				out_igrad_y = igrad_y0 + (igrad_y1 - igrad_y0) * h123.xxxx;	//	NOTE: gradients of 0.0
			}
			float QuinticHermiteDeriv( float x, float ival0, float ival1, float egrad0, float egrad1 )	// gives the derivative of quintic hermite with start/end acceleration of 0.0
			{
				const vec3 C0 = vec3( 30.0, -15.0, -15.0 );
				const vec3 C1 = vec3( -60.0, 32.0, 28.0 );
				const vec3 C2 = vec3( 30.0, -18.0, -12.0 );
				vec3 h123 = ( ( ( C1 + C0 * x ) * x ) + C2 ) * ( x*x );
				return dot( vec3( (ival1 - ival0), egrad0, egrad1 ), h123.xyz + vec3( 0.0, 1.0, 0.0 ) );
			}

			//
			//	Hermite3D_Deriv
			//	Hermite3D noise with derivatives
			//	returns vec3( value, xderiv, yderiv, zderiv )
			//
			vec4 Hermite3D_Deriv( vec3 P )
			{
				//	establish our grid cell and unit position
				vec3 Pi = floor(P);
				vec3 Pf = P - Pi;

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
				vec4 hash_gradx0, hash_grady0, hash_gradz0, hash_gradx1, hash_grady1, hash_gradz1;
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
				vec4 norm0 = inversesqrt( hash_gradx0 * hash_gradx0 + hash_grady0 * hash_grady0 + hash_gradz0 * hash_gradz0 );
				hash_gradx0 *= norm0;
				hash_grady0 *= norm0;
				hash_gradz0 *= norm0;
				vec4 norm1 = inversesqrt( hash_gradx1 * hash_gradx1 + hash_grady1 * hash_grady1 + hash_gradz1 * hash_gradz1 );
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
				vec4 ival_results_z, igrad_results_x_z, igrad_results_y_z;
				QuinticHermite( Pf.z, hash_gradx0, hash_gradx1, hash_grady0, hash_grady1, hash_gradz0, hash_gradz1, ival_results_z, igrad_results_x_z, igrad_results_y_z );

				vec4 ival_results_y, igrad_results_x_y, igrad_results_z_y;
				QuinticHermite( Pf.y, 	vec4( hash_gradx0.xy, hash_gradx1.xy ), vec4( hash_gradx0.zw, hash_gradx1.zw ),
										vec4( hash_gradz0.xy, hash_gradz1.xy ), vec4( hash_gradz0.zw, hash_gradz1.zw ),
										vec4( hash_grady0.xy, hash_grady1.xy ), vec4( hash_grady0.zw, hash_grady1.zw ),
										ival_results_y, igrad_results_x_y, igrad_results_z_y );

				//	drop things from two dimensions to one
				vec4 qh_results_x = QuinticHermite( Pf.y, vec4(ival_results_z.xy, igrad_results_x_z.xy), vec4(ival_results_z.zw, igrad_results_x_z.zw), vec4( igrad_results_y_z.xy, 0.0, 0.0 ), vec4( igrad_results_y_z.zw, 0.0, 0.0 ) );
				vec4 qh_results_y = QuinticHermite( Pf.x, vec4(ival_results_z.xz, igrad_results_y_z.xz), vec4(ival_results_z.yw, igrad_results_y_z.yw), vec4( igrad_results_x_z.xz, 0.0, 0.0 ), vec4( igrad_results_x_z.yw, 0.0, 0.0 ) );
				vec4 qh_results_z = QuinticHermite( Pf.x, vec4(ival_results_y.xz, igrad_results_z_y.xz), vec4(ival_results_y.yw, igrad_results_z_y.yw), vec4( igrad_results_x_y.xz, 0.0, 0.0 ), vec4( igrad_results_x_y.yw, 0.0, 0.0 ) );

				//	for each hermite curve calculate the derivative
				float deriv_x = QuinticHermiteDeriv( Pf.x, qh_results_x.x, qh_results_x.y, qh_results_x.z, qh_results_x.w );
				float deriv_y = QuinticHermiteDeriv( Pf.y, qh_results_y.x, qh_results_y.y, qh_results_y.z, qh_results_y.w );
				float deriv_z = QuinticHermiteDeriv( Pf.z, qh_results_z.x, qh_results_z.y, qh_results_z.z, qh_results_z.w );

				//	and also the final noise value off any one of them
				float finalpos = QuinticHermite( Pf.x, qh_results_x.x, qh_results_x.y, qh_results_x.z, qh_results_x.w );

				//	normalize and return results! :)
				return vec4( finalpos, deriv_x, deriv_y, deriv_z ) * FINAL_NORM_VAL;
			}

			vec4 ridge(vec3 p, float ridgePower, float offset)
			{
				return offset - abs(4.0*Hermite3D_Deriv(p));
			}

			//
			// 3D fractional Brownian Motion
			//
			float fBM(vec3 p, vec3 offset, float frequency, float amplitude, float lacunarity, float persistence, float ridgePower, float ridgeOffset, float warp)
			{
				float sum = 0.0;
				float bias = 0.0;
				vec3 dsum = vec3(0.0, 0.0, 0.0);
				for (int i = 0; i < OCTAVES; i++)
				{
					vec4 n = 0.5 * (1.0 + ridge((p+offset+warp*dsum)*frequency, ridgePower, ridgeOffset));
					sum += n.x*amplitude;
					dsum += amplitude * n.yzw * -n.x;
					bias -= amplitude;
					frequency *= lacunarity;
					amplitude *= persistence * clamp(sum, 0.0, 1.0);
				}
				sum += 0.5 * bias;
				return sum;
			}

			#ifdef VERTEX

			uniform float _Displace;
			varying vec4 position;
			varying vec2 texCoord;

			void main()
			{	
				position = gl_Vertex;
				if(_Displace > 0.0)
				{
					position.y = fBM(vec3(position.xz, _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _Lacunarity, _Persistence, _RidgePower, _RidgeOffset, _Warp);
				}
				gl_Position = gl_ModelViewProjectionMatrix * position;
				texCoord = gl_MultiTexCoord0.xy;
			}

			#endif

			#ifdef FRAGMENT

			uniform vec4 _LowColor;
			uniform vec4 _HighColor;
			uniform float _Texturing;
			uniform sampler2D _LowTexture;
			uniform vec4 _LowTexture_ST;
			uniform sampler2D _HighTexture;
			uniform vec4 _HighTexture_ST;
			varying vec4 position;
			varying vec2 texCoord;

			void main()
			{
				float h = fBM(vec3(vec2(position.xz), _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _Lacunarity, _Persistence, _RidgePower, _RidgeOffset, _Warp);

				if(_Normalize > 0.0)
				{
					// set range to (0, 1)
					h = h*0.5 + 0.5;
				}
				
				// do the accumulation with the previous fixed-point height
				h = h*_Contribution;
				
				vec4 color;
				
				if(_Texturing > 0.0)
				{
					color = mix(_LowColor * texture2D(_LowTexture, _LowTexture_ST.xy * texCoord + _LowTexture_ST.zw), _HighColor * texture2D(_HighTexture, _HighTexture_ST.xy * texCoord + _HighTexture_ST.zw), h);
				}
				else
				{
					color = mix(_LowColor, _HighColor, h);
				}
				
				gl_FragColor = vec4(color.r, color.g, color.b, h);
			}

			#endif

			ENDGLSL
		}
	} 
	FallBack "VertexLit"
}
