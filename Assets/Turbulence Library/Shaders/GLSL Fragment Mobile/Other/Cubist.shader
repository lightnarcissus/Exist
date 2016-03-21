//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/Mobile/Other/Cubist" 
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
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.0)
		_Contribution("Contribution", Float) = 0.45
		_Normalize("Normalize", Range(-1, 1)) = -1.0
		_AnimSpeed("Anim Speed", Float) = 0.0
		
		_RangeClamp("Range Clamp", Vector) = (-1.5, 0.5, 0.0)
	}

	SubShader 
	{
		Pass
		{
			// Additive blending - Add result to whatever is on the screen
			// Blend One One
		
			GLSLPROGRAM

			precision mediump float;

			uniform vec4 _Time;
			uniform float _Frequency;
			uniform float _Amplitude;
			uniform vec3 _NoiseOffset;
			uniform float _Contribution;
			uniform vec2 _RangeClamp;
			uniform float _Normalize;
			uniform float _AnimSpeed;


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
									out vec4 lowz_hash_3,
									out vec4 highz_hash_0,
									out vec4 highz_hash_1,
									out vec4 highz_hash_2,
									out vec4 highz_hash_3	)		//	generates 4 random numbers for each of the 8 cell corners
			{
				//    gridcell is assumed to be an integer coordinate

				//	TODO: 	these constants need tweaked to find the best possible noise.
				//			probably requires some kind of brute force computational searching or something....
				const vec2 OFFSET = vec2( 50.0, 161.0 );
				const float DOMAIN = 69.0;
				const vec4 SOMELARGEFLOATS = vec4( 635.298681, 682.357502, 668.926525, 588.255119 );
				const vec4 ZINC = vec4( 48.500388, 65.294118, 63.934599, 63.279683 );

				//	truncate the domain
				gridcell.xyz = gridcell.xyz - floor(gridcell.xyz * ( 1.0 / DOMAIN )) * DOMAIN;
				vec3 gridcell_inc1 = step( gridcell, vec3( DOMAIN - 1.5 ) ) * ( gridcell + 1.0 );

				//	calculate the noise
				vec4 P = vec4( gridcell.xy, gridcell_inc1.xy ) + OFFSET.xyxy;
				P *= P;
				P = P.xzxz * P.yyww;
				lowz_hash_3.xyzw = vec4( 1.0 / ( SOMELARGEFLOATS.xyzw + gridcell.zzzz * ZINC.xyzw ) );
				highz_hash_3.xyzw = vec4( 1.0 / ( SOMELARGEFLOATS.xyzw + gridcell_inc1.zzzz * ZINC.xyzw ) );
				lowz_hash_0 = fract( P * lowz_hash_3.xxxx );
				highz_hash_0 = fract( P * highz_hash_3.xxxx );
				lowz_hash_1 = fract( P * lowz_hash_3.yyyy );
				highz_hash_1 = fract( P * highz_hash_3.yyyy );
				lowz_hash_2 = fract( P * lowz_hash_3.zzzz );
				highz_hash_2 = fract( P * highz_hash_3.zzzz );
				lowz_hash_3 = fract( P * lowz_hash_3.wwww );
				highz_hash_3 = fract( P * highz_hash_3.wwww );
			}

			vec3 Interpolation_C2( vec3 x ) 
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
			float Cubist3D( vec3 P, vec2 range_clamp )	// range_clamp.x = low, range_clamp.y = 1.0/(high-low).  suggest value low=-2.0  high=1.0
			{
				//	establish our grid cell and unit position
				vec3 Pi = floor(P);
				vec3 Pf = P - Pi;
				vec3 Pf_min1 = Pf - 1.0;

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
				vec4 hashx0, hashy0, hashz0, hash_value0, hashx1, hashy1, hashz1, hash_value1;
				FAST32_hash_3D( Pi, hashx0, hashy0, hashz0, hash_value0, hashx1, hashy1, hashz1, hash_value1 );

				//	calculate the gradients
				vec4 grad_x0 = hashx0 - 0.49999;
				vec4 grad_y0 = hashy0 - 0.49999;
				vec4 grad_z0 = hashz0 - 0.49999;
				vec4 grad_x1 = hashx1 - 0.49999;
				vec4 grad_y1 = hashy1 - 0.49999;
				vec4 grad_z1 = hashz1 - 0.49999;
				vec4 grad_results_0 = inversesqrt( grad_x0 * grad_x0 + grad_y0 * grad_y0 + grad_z0 * grad_z0 ) * ( vec2( Pf.x, Pf_min1.x ).xyxy * grad_x0 + vec2( Pf.y, Pf_min1.y ).xxyy * grad_y0 + Pf.zzzz * grad_z0 );
				vec4 grad_results_1 = inversesqrt( grad_x1 * grad_x1 + grad_y1 * grad_y1 + grad_z1 * grad_z1 ) * ( vec2( Pf.x, Pf_min1.x ).xyxy * grad_x1 + vec2( Pf.y, Pf_min1.y ).xxyy * grad_y1 + Pf_min1.zzzz * grad_z1 );

				//	invert the gradient to convert from perlin to cubist
				grad_results_0 = ( hash_value0 - 0.5 ) * ( 1.0 / grad_results_0 );
				grad_results_1 = ( hash_value1 - 0.5 ) * ( 1.0 / grad_results_1 );

				//	blend the gradients and return
				vec3 blend = Interpolation_C2( Pf );
				vec4 res0 = mix( grad_results_0, grad_results_1, blend.z );
				vec2 res1 = mix( res0.xy, res0.zw, blend.y );
				float final = mix( res1.x, res1.y, blend.x );

				//	the 1.0/grad calculation pushes the result to a possible to +-infinity.  Need to clamp to keep things sane
				return clamp( ( final - range_clamp.x ) * range_clamp.y, 0.0, 1.0 );
				// return smoothstep( 0.0, 1.0, ( final - range_clamp.x ) * range_clamp.y );		//	experiments.  smoothstep doesn't look as good, but does remove some discontinuities....
			}

			//
			// 3D fractional Brownian Motion
			//
			float fBM(vec3 p, vec3 offset, float frequency, float amplitude, vec2 rangeClamp)
			{
				float h = 0.0;
				h = Cubist3D((p+offset) * frequency, rangeClamp);
				h += h*amplitude;
				return h;
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
					position.y = fBM(vec3(position.xz, _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _RangeClamp);
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
				float h = fBM(vec3(vec2(position.xz), _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _RangeClamp);

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
