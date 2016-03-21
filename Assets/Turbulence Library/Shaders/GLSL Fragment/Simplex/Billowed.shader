//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/GLSL/Simplex/Billowed" 
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
		_BillowPower("Billow Power", Range(1.0, 8.0)) = 1.2
	}

	SubShader 
	{
		Pass
		{
			// Additive blending - Add result to whatever is on the screen
			//Blend One One
		
			GLSLPROGRAM
				
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
			void FAST32_hash_3D(vec3 gridcell,
								vec3 v1_mask,		//	user definable v1 and v2.  ( 0's and 1's )
								vec3 v2_mask,
								out vec4 hash_0,
								out vec4 hash_1,
								out vec4 hash_2	)		//	generates 3 random numbers for each of the 4 3D cell corners.  cell corners:  v0=0,0,0  v3=1,1,1  the other two are user definable
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

				//	compute x*x*y*y for the 4 corners
				vec4 P = vec4( gridcell.xy, gridcell_inc1.xy ) + OFFSET.xyxy;
				P *= P;
				vec4 V1xy_V2xy = mix( P.xyxy, P.zwzw, vec4( v1_mask.xy, v2_mask.xy ) );		//	apply mask for v1 and v2
				P = vec4( P.x, V1xy_V2xy.xz, P.z ) * vec4( P.y, V1xy_V2xy.yw, P.w );

				//	get the lowz and highz mods
				vec3 lowz_mods = vec3( 1.0 / ( SOMELARGEFLOATS.xyz + gridcell.zzz * ZINC.xyz ) );
				vec3 highz_mods = vec3( 1.0 / ( SOMELARGEFLOATS.xyz + gridcell_inc1.zzz * ZINC.xyz ) );

				//	apply mask for v1 and v2 mod values
				v1_mask = ( v1_mask.z < 0.5 ) ? lowz_mods : highz_mods;
				v2_mask = ( v2_mask.z < 0.5 ) ? lowz_mods : highz_mods;

				//	compute the final hash
				hash_0 = fract( P * vec4( lowz_mods.x, v1_mask.x, v2_mask.x, highz_mods.x ) );
				hash_1 = fract( P * vec4( lowz_mods.y, v1_mask.y, v2_mask.y, highz_mods.y ) );
				hash_2 = fract( P * vec4( lowz_mods.z, v1_mask.z, v2_mask.z, highz_mods.z ) );
			}

			//
			//	Given an arbitrary 3D point this calculates the 4 vectors from the corners of the simplex pyramid to the point
			//	It also returns the integer grid index information for the corners
			//
			void Simplex3D_GetCornerVectors( 	vec3 P,					//	input point
												out vec3 Pi,			//	integer grid index for the origin
												out vec3 Pi_1,			//	offsets for the 2nd and 3rd corners.  ( the 4th = Pi + 1.0 )
												out vec3 Pi_2,
												out vec4 v1234_x,		//	vectors from the 4 corners to the intput point
												out vec4 v1234_y,
												out vec4 v1234_z )
			{
				//
				//	Simplex math from Stefan Gustavson's and Ian McEwan's work at...
				//	http://github.com/ashima/webgl-noise
				//

				//	simplex math constants
				const float SKEWFACTOR = 1.0/3.0;
				const float UNSKEWFACTOR = 1.0/6.0;
				const float SIMPLEX_CORNER_POS = 0.5;
				const float SIMPLEX_PYRAMID_HEIGHT = 0.70710678118654752440084436210485;	// sqrt( 0.5 )	height of simplex pyramid.

				P *= SIMPLEX_PYRAMID_HEIGHT;		// scale space so we can have an approx feature size of 1.0  ( optional )

				//	Find the vectors to the corners of our simplex pyramid
				Pi = floor( P + dot( P, vec3( SKEWFACTOR) ) );
				vec3 x0 = P - Pi + dot(Pi, vec3( UNSKEWFACTOR ) );
				vec3 g = step(x0.yzx, x0.xyz);
				vec3 l = 1.0 - g;
				Pi_1 = min( g.xyz, l.zxy );
				Pi_2 = max( g.xyz, l.zxy );
				vec3 x1 = x0 - Pi_1 + UNSKEWFACTOR;
				vec3 x2 = x0 - Pi_2 + SKEWFACTOR;
				vec3 x3 = x0 - SIMPLEX_CORNER_POS;

				//	pack them into a parallel-friendly arrangement
				v1234_x = vec4( x0.x, x1.x, x2.x, x3.x );
				v1234_y = vec4( x0.y, x1.y, x2.y, x3.y );
				v1234_z = vec4( x0.z, x1.z, x2.z, x3.z );
			}

			//
			//	Calculate the weights for the 3D simplex surflet
			//
			vec4 Simplex3D_GetSurfletWeights( 	vec4 v1234_x,
												vec4 v1234_y,
												vec4 v1234_z )
			{
				//	perlins original implementation uses the surlet falloff formula of (0.6-x*x)^4.
				//	This is buggy as it can cause discontinuities along simplex faces.  (0.5-x*x)^3 solves this and gives an almost identical curve

				//	evaluate surflet. f(x)=(0.5-x*x)^3
				vec4 surflet_weights = v1234_x * v1234_x + v1234_y * v1234_y + v1234_z * v1234_z;
				surflet_weights = max(0.5 - surflet_weights, 0.0);		//	0.5 here represents the closest distance (squared) of any simplex pyramid corner to any of its planes.  ie, SIMPLEX_PYRAMID_HEIGHT^2
				return surflet_weights*surflet_weights*surflet_weights;
			}

			//
			//	SimplexPerlin3D  ( simplex gradient noise )
			//	Perlin noise over a simplex (tetrahedron) grid
			//	Return value range of -1.0->1.0
			//	http://briansharpe.files.wordpress.com/2012/01/simplexperlinsample.jpg
			//
			//	Implementation originally based off Stefan Gustavson's and Ian McEwan's work at...
			//	http://github.com/ashima/webgl-noise
			//
			float SimplexPerlin3D(vec3 P)
			{
				//	calculate the simplex vector and index math
				vec3 Pi;
				vec3 Pi_1;
				vec3 Pi_2;
				vec4 v1234_x;
				vec4 v1234_y;
				vec4 v1234_z;
				Simplex3D_GetCornerVectors( P, Pi, Pi_1, Pi_2, v1234_x, v1234_y, v1234_z );

				//	generate the random vectors
				//	( various hashing methods listed in order of speed )
				vec4 hash_0;
				vec4 hash_1;
				vec4 hash_2;
				FAST32_hash_3D( Pi, Pi_1, Pi_2, hash_0, hash_1, hash_2 );
				//SGPP_hash_3D( Pi, Pi_1, Pi_2, hash_0, hash_1, hash_2 );
				hash_0 -= 0.49999;
				hash_1 -= 0.49999;
				hash_2 -= 0.49999;

				//	evaluate gradients
				vec4 grad_results = inversesqrt( hash_0 * hash_0 + hash_1 * hash_1 + hash_2 * hash_2 ) * ( hash_0 * v1234_x + hash_1 * v1234_y + hash_2 * v1234_z );

				//	Normalization factor to scale the final result to a strict 1.0->-1.0 range
				//	x = sqrt( 0.75 ) * 0.5
				//	NF = 1.0 / ( x * ( ( 0.5 ? x*x ) ^ 3 ) * 2.0 )
				//	http://briansharpe.wordpress.com/2012/01/13/simplex-noise/#comment-36
				const float FINAL_NORMALIZATION = 37.837227241611314102871574478976;

				//	sum with the surflet and return
				return dot( Simplex3D_GetSurfletWeights( v1234_x, v1234_y, v1234_z ), grad_results ) * FINAL_NORMALIZATION;
			}

			float billow(vec3 p, int powered, float billowPower)
			{
				// Powered Billow
				if(powered > 0)
				{
					return pow(abs(4.0*SimplexPerlin3D(p)), billowPower);
				}
				else
				{
					return abs(4.0*SimplexPerlin3D(p));
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
