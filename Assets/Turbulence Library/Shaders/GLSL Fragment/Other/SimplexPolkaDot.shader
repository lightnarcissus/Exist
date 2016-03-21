//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/GLSL/Other/SimplexPolkaDot" 
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
		
		_Radius("Radius", Range(0.0, 1.0)) = 1.0
		_MaxDimness("Max Dimness", Range(0.0, 1.0)) = 0.5
	}

	SubShader 
	{
		Pass
		{
			// Additive blending - Add result to whatever is on the screen
			//Blend One One
			
			GLSLPROGRAM
		
			uniform vec4 _Time;
			uniform float _Frequency;
			uniform float _Amplitude;
			uniform vec3 _NoiseOffset;
			uniform float _Contribution;
			uniform float _Normalize;
			uniform float _AnimSpeed;
			uniform float _Radius;
			uniform float _MaxDimness;

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
			vec4 FAST32_hash_3D( 	vec3 gridcell,
									vec3 v1_mask,		//	user definable v1 and v2.  ( 0's and 1's )
									vec3 v2_mask )		//	generates 1 random number for each of the 4 3D cell corners.  cell corners:  v0=0,0,0  v3=1,1,1  the other two are user definable
			{
				//    gridcell is assumed to be an integer coordinate

				//	TODO: 	these constants need tweaked to find the best possible noise.
				//			probably requires some kind of brute force computational searching or something....
				const vec2 OFFSET = vec2( 50.0, 161.0 );
				const float DOMAIN = 69.0;
				const float SOMELARGEFLOAT = 635.298681;
				const float ZINC = 48.500388;

				//	truncate the domain
				gridcell.xyz = gridcell.xyz - floor(gridcell.xyz * ( 1.0 / DOMAIN )) * DOMAIN;
				vec3 gridcell_inc1 = step( gridcell, vec3( DOMAIN - 1.5 ) ) * ( gridcell + 1.0 );

				//	compute x*x*y*y for the 4 corners
				vec4 P = vec4( gridcell.xy, gridcell_inc1.xy ) + OFFSET.xyxy;
				P *= P;
				vec4 V1xy_V2xy = mix( P.xyxy, P.zwzw, vec4( v1_mask.xy, v2_mask.xy ) );		//	apply mask for v1 and v2
				P = vec4( P.x, V1xy_V2xy.xz, P.z ) * vec4( P.y, V1xy_V2xy.yw, P.w );

				//	get the z mod vals
				vec2 V1z_V2z = vec2( v1_mask.z < 0.5 ? gridcell.z : gridcell_inc1.z, v2_mask.z < 0.5 ? gridcell.z : gridcell_inc1.z );
				vec4 mod_vals = vec4( 1.0 / ( SOMELARGEFLOAT + vec4( gridcell.z, V1z_V2z, gridcell_inc1.z ) * ZINC ) );

				//	compute the final hash
				return fract( P * mod_vals );
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
			//	SimplexPolkaDot3D
			//	polkadots over a simplex (tetrahedron) grid
			//	Return value range of 0.0->1.0
			//	http://briansharpe.files.wordpress.com/2012/01/simplexpolkadotsample.jpg
			//
			float SimplexPolkaDot3D( 	vec3 P,
										float radius, 		//	radius range is 0.0->1.0
										float max_dimness )	//	the maximal dimness of a dot ( 0.0->1.0   0.0 = all dots bright,  1.0 = maximum variation )
			{
				//	calculate the simplex vector and index math
				vec3 Pi;
				vec3 Pi_1;
				vec3 Pi_2;
				vec4 v1234_x;
				vec4 v1234_y;
				vec4 v1234_z;
				Simplex3D_GetCornerVectors( P, Pi, Pi_1, Pi_2, v1234_x, v1234_y, v1234_z );

				//	calculate the hash
				vec4 hash = FAST32_hash_3D( Pi, Pi_1, Pi_2 );

				//	apply user controls
				const float INV_SIMPLEX_TRI_HALF_EDGELEN = 2.3094010767585030580365951220078;	// scale to a 0.0->1.0 range.  2.0 / sqrt( 0.75 )
				radius = INV_SIMPLEX_TRI_HALF_EDGELEN/radius;
				v1234_x *= radius;
				v1234_y *= radius;
				v1234_z *= radius;

				//	return a smooth falloff from the closest point.  ( we use a f(x)=(1.0-x*x)^3 falloff )
				vec4 point_distance = max( vec4( 0.0 ), 1.0 - ( v1234_x*v1234_x + v1234_y*v1234_y + v1234_z*v1234_z ) );
				point_distance = point_distance*point_distance*point_distance;
				return dot( 1.0 - hash * max_dimness, point_distance );
			}

			//
			// 3D fractional Brownian Motion
			//
			float fBM(vec3 p, vec3 offset, float frequency, float amplitude, float radius, float maxDimness)
			{
				float h = 0.0;
				h = SimplexPolkaDot3D(p * frequency + offset, radius, maxDimness);
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
					position.y = fBM(vec3(position.xz, _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _Radius, _MaxDimness);
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
				float h = fBM(vec3(vec2(position.xz), _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _Radius, _MaxDimness);

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
