//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/Mobile/Advanced Perlin/Swiss" 
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
		_Warp("Warp", Float) = 0.02
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
			//	PerlinSurflet3D_Deriv
			//	Perlin Surflet 3D noise with derivatives
			//	returns vec4( value, xderiv, yderiv, zderiv )
			//
			vec4 PerlinSurflet3D_Deriv( vec3 P )
			{
				//	establish our grid cell and unit position
				vec3 Pi = floor(P);
				vec3 Pf = P - Pi;
				vec3 Pf_min1 = Pf - 1.0;

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
				vec4 hashx0, hashy0, hashz0, hashx1, hashy1, hashz1;
				FAST32_hash_3D( Pi, hashx0, hashy0, hashz0, hashx1, hashy1, hashz1 );
				//SGPP_hash_3D( Pi, hashx0, hashy0, hashz0, hashx1, hashy1, hashz1 );

				//	calculate the gradients
				vec4 grad_x0 = hashx0 - 0.49999;
				vec4 grad_y0 = hashy0 - 0.49999;
				vec4 grad_z0 = hashz0 - 0.49999;
				vec4 norm_0 = inversesqrt( grad_x0 * grad_x0 + grad_y0 * grad_y0 + grad_z0 * grad_z0 );
				grad_x0 *= norm_0;
				grad_y0 *= norm_0;
				grad_z0 *= norm_0;
				vec4 grad_x1 = hashx1 - 0.49999;
				vec4 grad_y1 = hashy1 - 0.49999;
				vec4 grad_z1 = hashz1 - 0.49999;
				vec4 norm_1 = inversesqrt( grad_x1 * grad_x1 + grad_y1 * grad_y1 + grad_z1 * grad_z1 );
				grad_x1 *= norm_1;
				grad_y1 *= norm_1;
				grad_z1 *= norm_1;
				vec4 grad_results_0 = vec2( Pf.x, Pf_min1.x ).xyxy * grad_x0 + vec2( Pf.y, Pf_min1.y ).xxyy * grad_y0 + Pf.zzzz * grad_z0;
				vec4 grad_results_1 = vec2( Pf.x, Pf_min1.x ).xyxy * grad_x1 + vec2( Pf.y, Pf_min1.y ).xxyy * grad_y1 + Pf_min1.zzzz * grad_z1;

				//	get lengths in the x+y plane
				vec3 Pf_sq = Pf*Pf;
				vec3 Pf_min1_sq = Pf_min1*Pf_min1;
				vec4 vecs_len_sq = vec2( Pf_sq.x, Pf_min1_sq.x ).xyxy + vec2( Pf_sq.y, Pf_min1_sq.y ).xxyy;

				//	evaluate the surflet
				vec4 m_0 = vecs_len_sq + Pf_sq.zzzz;
				m_0 = max(1.0 - m_0, 0.0);
				vec4 m2_0 = m_0*m_0;
				vec4 m3_0 = m_0*m2_0;

				vec4 m_1 = vecs_len_sq + Pf_min1_sq.zzzz;
				m_1 = max(1.0 - m_1, 0.0);
				vec4 m2_1 = m_1*m_1;
				vec4 m3_1 = m_1*m2_1;

				//	calc the deriv
				vec4 temp_0 = -6.0 * m2_0 * grad_results_0;
				float xderiv_0 = dot( temp_0, vec2( Pf.x, Pf_min1.x ).xyxy ) + dot( m3_0, grad_x0 );
				float yderiv_0 = dot( temp_0, vec2( Pf.y, Pf_min1.y ).xxyy ) + dot( m3_0, grad_y0 );
				float zderiv_0 = dot( temp_0, Pf.zzzz ) + dot( m3_0, grad_z0 );

				vec4 temp_1 = -6.0 * m2_1 * grad_results_1;
				float xderiv_1 = dot( temp_1, vec2( Pf.x, Pf_min1.x ).xyxy ) + dot( m3_1, grad_x1 );
				float yderiv_1 = dot( temp_1, vec2( Pf.y, Pf_min1.y ).xxyy ) + dot( m3_1, grad_y1 );
				float zderiv_1 = dot( temp_1, Pf_min1.zzzz ) + dot( m3_1, grad_z1 );

				const float FINAL_NORMALIZATION = 2.3703703703703703703703703703704;	//	scales the final result to a strict 1.0->-1.0 range
				return vec4( dot( m3_0, grad_results_0 ) + dot( m3_1, grad_results_1 ) , vec3(xderiv_0,yderiv_0,zderiv_0) + vec3(xderiv_1,yderiv_1,zderiv_1) ) * FINAL_NORMALIZATION;
			}

			vec4 ridge(vec3 p, float ridgePower, float offset)
			{
				return offset - abs(4.0 * PerlinSurflet3D_Deriv(p));
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
					vec4 n = 0.5 * (1.0 + ridge((p+offset+warp*dsum) * frequency, ridgePower, ridgeOffset));
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
