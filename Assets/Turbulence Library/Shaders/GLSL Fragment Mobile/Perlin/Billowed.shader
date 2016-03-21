//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/Mobile/Perlin/Billowed" 
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
		_Powered("Powered", Range(-1, 1)) = 1.0
		_BillowPower("Billow Power", Range(1.0, 8.0)) = 1.5
	}

	SubShader 
	{
		Pass
		{
			// Additive blending - Add result to whatever is on the screen
			//Blend One One
		
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
			uniform int _Powered;
			uniform float _BillowPower;

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

			vec3 Interpolation_C2( vec3 x ) 
			{ 
				return x * x * x * (x * (x * 6.0 - 15.0) + 10.0); 
			}

			//
			//	Perlin Noise 3D  ( gradient noise )
			//	Return value range of -1.0->1.0
			//	http://briansharpe.files.wordpress.com/2011/11/perlinsample.jpg
			//
			float Perlin3D( vec3 P )
			{
				//	establish our grid cell and unit position
				vec3 Pi = floor(P);
				vec3 Pf = P - Pi;
				vec3 Pf_min1 = Pf - 1.0;

			#if 1
				//
				//	classic noise.
				//	requires 3 random values per point.  with an efficent hash function will run faster than improved noise
				//

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
				vec4 hashx0, hashy0, hashz0, hashx1, hashy1, hashz1;
				FAST32_hash_3D( Pi, hashx0, hashy0, hashz0, hashx1, hashy1, hashz1 );
				//SGPP_hash_3D( Pi, hashx0, hashy0, hashz0, hashx1, hashy1, hashz1 );

				//	calculate the gradients
				vec4 grad_x0 = hashx0 - 0.49999;
				vec4 grad_y0 = hashy0 - 0.49999;
				vec4 grad_z0 = hashz0 - 0.49999;
				vec4 grad_x1 = hashx1 - 0.49999;
				vec4 grad_y1 = hashy1 - 0.49999;
				vec4 grad_z1 = hashz1 - 0.49999;
				vec4 grad_results_0 = inversesqrt( grad_x0 * grad_x0 + grad_y0 * grad_y0 + grad_z0 * grad_z0 ) * ( vec2( Pf.x, Pf_min1.x ).xyxy * grad_x0 + vec2( Pf.y, Pf_min1.y ).xxyy * grad_y0 + Pf.zzzz * grad_z0 );
				vec4 grad_results_1 = inversesqrt( grad_x1 * grad_x1 + grad_y1 * grad_y1 + grad_z1 * grad_z1 ) * ( vec2( Pf.x, Pf_min1.x ).xyxy * grad_x1 + vec2( Pf.y, Pf_min1.y ).xxyy * grad_y1 + Pf_min1.zzzz * grad_z1 );

			#if 1
				//	Classic Perlin Interpolation
				vec3 blend = Interpolation_C2( Pf );
				vec4 res0 = mix( grad_results_0, grad_results_1, blend.z );
				vec2 res1 = mix( res0.xy, res0.zw, blend.y );
				float final = mix( res1.x, res1.y, blend.x );
				final *= 1.1547005383792515290182975610039;		//	(optionally) scale things to a strict -1.0->1.0 range    *= 1.0/sqrt(0.75)
				return final;
			#else
				//	Classic Perlin Surflet
				//	http://briansharpe.wordpress.com/2012/03/09/modifications-to-classic-perlin-noise/
				Pf *= Pf;
				Pf_min1 *= Pf_min1;
				vec4 vecs_len_sq = vec4( Pf.x, Pf_min1.x, Pf.x, Pf_min1.x ) + vec4( Pf.yy, Pf_min1.yy );
				float final = dot( Falloff_Xsq_C2( min( vec4( 1.0 ), vecs_len_sq + Pf.zzzz ) ), grad_results_0 ) + dot( Falloff_Xsq_C2( min( vec4( 1.0 ), vecs_len_sq + Pf_min1.zzzz ) ), grad_results_1 );
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
				vec4 hash_lowz, hash_highz;
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
				vec4 grad_results_0_0 = vec2( Pf.x, Pf_min1.x ).xyxy * sign( hash_lowz );
				hash_lowz = abs( hash_lowz ) - 0.25;
				vec4 grad_results_0_1 = vec2( Pf.y, Pf_min1.y ).xxyy * sign( hash_lowz );
				vec4 grad_results_0_2 = Pf.zzzz * sign( abs( hash_lowz ) - 0.125 );
				vec4 grad_results_0 = grad_results_0_0 + grad_results_0_1 + grad_results_0_2;

				hash_highz -= 0.5;
				vec4 grad_results_1_0 = vec2( Pf.x, Pf_min1.x ).xyxy * sign( hash_highz );
				hash_highz = abs( hash_highz ) - 0.25;
				vec4 grad_results_1_1 = vec2( Pf.y, Pf_min1.y ).xxyy * sign( hash_highz );
				vec4 grad_results_1_2 = Pf_min1.zzzz * sign( abs( hash_highz ) - 0.125 );
				vec4 grad_results_1 = grad_results_1_0 + grad_results_1_1 + grad_results_1_2;

				//	blend the gradients and return
				vec3 blend = Interpolation_C2( Pf );
				vec4 res0 = mix( grad_results_0, grad_results_1, blend.z );
				vec2 res1 = mix( res0.xy, res0.zw, blend.y );
				return mix( res1.x, res1.y, blend.x ) * (2.0 / 3.0);	//	(optionally) mult by (2.0/3.0) to scale to a strict -1.0->1.0 range

			#endif

			}

			float billow(vec3 p, int powered, float billowPower)
			{
				// Powered Billow
				if(powered > 0)
				{
					return pow(abs(4.0*Perlin3D(p)), billowPower);
				}
				else
				{
					return abs(4.0*Perlin3D(p));
				}
			}

			//
			// 3D fractional Brownian Motion
			//
			float fBM(vec3 p, vec3 offset, float frequency, float amplitude, float lacunarity, float persistence, int powered, float billowPower)
			{
				float sum = 0.0;
				float bias = 0.0;
				for (int i = 0; i < OCTAVES; i++)
				{
					float h = 0.5 * (1.0 + billow((p+offset)*frequency, powered, billowPower));
					sum += h*amplitude;
					bias -= amplitude;
					frequency *= lacunarity;
					amplitude *= persistence;
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
					position.y = fBM(vec3(position.xz, _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _Lacunarity, _Persistence, _Powered, _BillowPower);
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
				float h = fBM(vec3(vec2(position.xz), _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _Lacunarity, _Persistence, _Powered, _BillowPower);

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
