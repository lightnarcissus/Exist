//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/GLSL/Voronoi/Manhattan/Difference32" 
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
			// Blend One One
		
			GLSLPROGRAM

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
			//	hash = fmod( coord.x * coord.x * coord.y * coord.y, SOMELARGEFLOAT ) / SOMELARGEFLOAT
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
			
			float Cellular3D(vec3 xyz) 
			{
				int xi = int(floor(xyz.x));
				int yi = int(floor(xyz.y));
				int zi = int(floor(xyz.z));
 
				float xf = xyz.x - float(xi);
				float yf = xyz.y - float(yi);
				float zf = xyz.z - float(zi);
 
				float dist1 = 9999999.0;
				float dist2 = 9999999.0;
				float dist3 = 9999999.0;
				float dist4 = 9999999.0;
				vec3 cell;
 
				for (int z = -1; z <= 1; z++) {
					for (int y = -1; y <= 1; y++) {
						for (int x = -1; x <= 1; x++) {
							cell = FAST32_hash_3D_Cell(vec3(xi + x, yi + y, zi + z)).xyz;
							cell.x += (float(x) - xf);
							cell.y += (float(y) - yf);
							cell.z += (float(z) - zf);
							float dist = 0.0;
							dist = abs(cell.x) + abs(cell.y) + abs(cell.z);
							dist *= dist;
							if (dist < dist1) 
							{
								dist4 = dist3;
								dist3 = dist2;
								dist2 = dist1;
								dist1 = dist;
							}
							else if (dist < dist2) 
							{
								dist4 = dist3;
								dist3 = dist2;
								dist2 = dist;
							}
							else if (dist < dist3) 
							{
								dist4 = dist3;
								dist3 = dist;
							}
							else if (dist < dist4) 
							{
								dist4 = dist;
							}
						}
					}
				}
 
				return dist3 - dist2;	//	scale return value from 0.0->1.333333 to 0.0->1.0  	(2/3)^2 * 3  == (12/9) == 1.333333
			}

			//
			// 3D fractional Brownian Motion
			//
			float fBM(vec3 p, vec3 offset, float frequency, float amplitude)
			{
				float h = 0.0;
				h = Cellular3D((p+offset) * frequency);
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
