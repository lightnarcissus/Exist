//
// Turbulence Library - GPU Noise Generator
// Developped by J�r�mie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/Mobile/Voronoi/Length/SimplexF1" 
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
	}

	SubShader 
	{
		Pass
		{
			// Additive blending - Add result to whatever is on the screen
			//Blend One One
			
			GLSLPROGRAM

			precision mediump float;
		
			uniform vec4 _Time;
			uniform float _Frequency;
			uniform float _Amplitude;
			uniform vec3 _NoiseOffset;
			uniform float _Contribution;
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

			//	convert a 0.0->1.0 sample to a -1.0->1.0 sample weighted towards the extremes
			vec4 Cellular_weight_samples( vec4 samples )
			{
				samples = samples * 2.0 - 1.0;
				//return (1.0 - samples * samples) * sign(samples);	// square
				return (samples * samples * samples) - sign(samples);	// cubic (even more variance)
			}

			//
			//	SimplexCellular3D
			//	cellular noise over a simplex (tetrahedron) grid
			//	Return value range of 0.0->~1.0
			//	http://briansharpe.files.wordpress.com/2012/01/simplexcellularsample.jpg
			//
			//	TODO:  scaling of return value to strict 0.0->1.0 range
			//
			float SimplexCellular3D( vec3 P )
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
				vec4 hash_x;
				vec4 hash_y;
				vec4 hash_z;
				FAST32_hash_3D( Pi, Pi_1, Pi_2, hash_x, hash_y, hash_z );

				//	push hash values to extremes of jitter window
				const float INV_SIMPLEX_PYRAMID_HEIGHT = 1.4142135623730950488016887242097;	//	1.0 / sqrt( 0.5 )   This scales things so to a nice 0.0->1.0 range
				const float JITTER_WINDOW = ( 0.0597865779345250670558198111 * INV_SIMPLEX_PYRAMID_HEIGHT) ;		// this will guarentee no artifacts.
				hash_x = Cellular_weight_samples( hash_x ) * JITTER_WINDOW;
				hash_y = Cellular_weight_samples( hash_y ) * JITTER_WINDOW;
				hash_z = Cellular_weight_samples( hash_z ) * JITTER_WINDOW;

				//	offset the vectors.
				v1234_x *= INV_SIMPLEX_PYRAMID_HEIGHT;
				v1234_y *= INV_SIMPLEX_PYRAMID_HEIGHT;
				v1234_z *= INV_SIMPLEX_PYRAMID_HEIGHT;
				v1234_x += hash_x;
				v1234_y += hash_y;
				v1234_z += hash_z;

				//	calc the distance^2 to the closest point
				vec4 distsq = v1234_x*v1234_x + v1234_y*v1234_y + v1234_z*v1234_z;
				return min( min( distsq.x, distsq.y ), min( distsq.z, distsq.w ) );
			}

			//
			// 3D fractional Brownian Motion
			//
			float fBM(vec3 p, vec3 offset, float frequency, float amplitude)
			{
				float h = 0.0;
				h = SimplexCellular3D(p * frequency + offset);
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
					position.y = fBM(vec3(position.xz, _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude);
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
				float h = fBM(vec3(vec2(position.xz), _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude);

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
