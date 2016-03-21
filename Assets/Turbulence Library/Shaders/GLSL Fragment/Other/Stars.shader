//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/GLSL/Other/Stars" 
{
	Properties 
	{
		_LowColor("Low Color", Vector) = (0.0, 0.0, 0.0, 1.0)
		_HighColor("High Color", Vector) = (1.0, 1.0, 1.0, 1.0)
		_Texturing("Texturing", Range(-1, 1)) = -1.0
		_LowTexture("Low Texture", 2D) = "" {} 
		_HighTexture("High Texture", 2D) = "" {}
		_Displace("Displace", Range(-1, 1)) = -1.0
		_Frequency ("Frequency", Float) = 4.0
		_Amplitude ("Amplitude", Float) = 1.0
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.5)
		_Contribution("Contribution", Float) = 0.45
		_Normalize("Normalize", Range(-1, 1)) = -1.0
		_AnimSpeed("Anim Speed", Float) = 0.0
		
		_Radius("Radius", Range(0.0, 1.0)) = 0.5
		_Probability("Probability", Range(0.0, 1.0)) = 0.5
		_MaxDimness("Max Dimness", Range(0.0, 1.0)) = 0.5
	}

	SubShader 
	{
		Pass
		{
			// Additive blending - Add result to whatever is on the screen
			// Blend One One
		
			GLSLPROGRAM
		
			uniform vec4 _Time;
			uniform float _Frequency;
			uniform float _Amplitude;
			uniform vec3 _NoiseOffset;
			uniform float _Contribution;
			uniform float _Normalize;
			uniform float _AnimSpeed;
			
			uniform float _Radius;
			uniform float _Probability;
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
			vec4 FAST32_hash_3D_Cell( vec3 gridcell )	//	generates 4 different random numbers for the single given cell point
			{
				//    gridcell is assumed to be an integer coordinate

				//	TODO: 	these constants need tweaked to find the best possible noise.
				//			probably requires some kind of brute force computational searching or something....
				const vec2 OFFSET = vec2( 50.0, 161.0 );
				const float DOMAIN = 69.0;
				const vec4 SOMELARGEFLOATS = vec4( 635.298681, 682.357502, 668.926525, 588.255119 );
				const vec4 ZINC = vec4( 48.500388, 65.294118, 63.934599, 63.279683 );

				//	truncate the domain
				gridcell.xyz = gridcell - floor(gridcell * ( 1.0 / DOMAIN )) * DOMAIN;
				gridcell.xy += OFFSET.xy;
				gridcell.xy *= gridcell.xy;
				return fract( ( gridcell.x * gridcell.y ) * ( 1.0 / ( SOMELARGEFLOATS + gridcell.zzzz * ZINC ) ) );
			}

			//
			//	Falloff defined in XSquared
			//	( smoothly decrease from 1.0 to 0.0 as xsq increases from 0.0 to 1.0 )
			//	http://briansharpe.wordpress.com/2011/11/14/two-useful-interpolation-functions-for-noise-development/
			//
			float Falloff_Xsq_C1( float xsq ) { xsq = 1.0 - xsq; return xsq*xsq; }	// ( 1.0 - x*x )^2   ( Used by Humus for lighting falloff in Just Cause 2.  GPUPro 1 )
			float Falloff_Xsq_C2( float xsq ) { xsq = 1.0 - xsq; return xsq*xsq*xsq; }	// ( 1.0 - x*x )^3.   NOTE: 2nd derivative is 0.0 at x=1.0, but non-zero at x=0.0
			vec4 Falloff_Xsq_C2( vec4 xsq ) { xsq = 1.0 - xsq; return xsq*xsq*xsq; }

			//
			//	Stars3D
			//	http://briansharpe.files.wordpress.com/2011/12/starssample.jpg
			//
			//	procedural texture for creating a starry background.  ( looks good when combined with a nebula/space-like colour texture )
			//	NOTE:  Any serious game implementation should hard-code these parameter values for efficiency.
			//
			//	Return value range of 0.0->1.0
			//
			float Stars3D(	vec3 P,
							float probability_threshold,		//	probability a star will be drawn  ( 0.0->1.0 )
							float max_dimness,					//	the maximal dimness of a star ( 0.0->1.0   0.0 = all stars bright,  1.0 = maximum variation )
							float two_over_radius )				//	fixed radius for the stars.  radius range is 0.0->1.0  shader requires 2.0/radius as input.
			{
				//	establish our grid cell and unit position
				vec3 Pi = floor(P);
				vec3 Pf = P - Pi;

				//	calculate the hash.
				//	( various hashing methods listed in order of speed )
				vec4 hash = FAST32_hash_3D_Cell( Pi );

				//	user variables
				float VALUE = 1.0 - max_dimness * hash.z;

				//	calc the noise and return
				Pf *= two_over_radius;
				Pf -= ( two_over_radius - 1.0 );
				Pf += hash.xyz * ( two_over_radius - 2.0 );
				return ( hash.w < probability_threshold ) ? ( Falloff_Xsq_C1( min( dot( Pf, Pf ), 1.0 ) ) * VALUE ) : 0.0;
			}

			//
			// 3D fractional Brownian Motion
			//
			float fBM(vec3 p, vec3 offset, float frequency, float amplitude, float radius, float probability, float maxDimness)
			{
				float h = 0.0;
				h = Stars3D((p+offset) * frequency, probability, maxDimness, 2.0/radius);
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
					position.y = fBM(vec3(position.xz, _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _Radius, _Probability, _MaxDimness);
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
				float h = fBM(vec3(vec2(position.xz), _Time*_AnimSpeed), _NoiseOffset, _Frequency, _Amplitude, _Radius, _Probability, _MaxDimness);

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
