//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/CG/Voronoi/MultiVoronoi3D" 
{
	Properties 
	{
		_LowColor("Low Color", Vector) = (0.0, 0.0, 0.0, 1.0)
		_HighColor("High Color", Vector) = (1.0, 1.0, 1.0, 1.0)
		_Texturing("Texturing", Range(-1, 1)) = -1.0
		_LowTexture("Low Texture", 2D) = "" {} 
		_HighTexture("High Texture", 2D) = "" {}
		_TurbulenceMapX("Turbulence Map X", 2D) = "black" {}
		_TurbulenceMapY("Turbulence Map Y", 2D) = "black" {}
		_TurbulenceMapZ("Turbulence Map Z", 2D) = "black" {}
		_TurbulencePower("Turbulence Power", Float) = 1.0
		_Frequency ("Frequency", Float) = 1.0
		_Amplitude ("Amplitude", Float) = 1.0
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.0)
		_NoiseScale ("Noise Scale", Vector) = (1.0, 1.0, 1.0)
		_Contribution("Contribution", Float) = 0.45
		_Normalize("Normalize", Range(-1, 1)) = -1.0
		
		_CellType("Cell Type", Range(0, 9)) = 0
		_DistanceFunction("Distance Function", Range(0, 7)) = 0
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
			//#pragma exclude_renderers  
			//#pragma only_renderers opengl
			#pragma vertex vert
			#pragma fragment frag
			
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
			float3 _NoiseScale;
			float _Contribution;
			int _Normalize;
			
			int _CellType;
			int _DistanceFunction;
			
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
			float4 FAST32_hash_3D_Cell( float3 gridcell )	//	generates 4 different random numbers for the single given cell point
			{
				//    gridcell is assumed to be an integer coordinate

				//	TODO: 	these constants need tweaked to find the best possible noise.
				//			probably requires some kind of brute force computational searching or something....
				const float2 OFFSET = float2( 50.0, 161.0 );
				const float DOMAIN = 69.0;
				const float4 SOMELARGEFLOATS = float4( 635.298681, 682.357502, 668.926525, 588.255119 );
				const float4 ZINC = float4( 48.500388, 65.294118, 63.934599, 63.279683 );

				//	truncate the domain
				gridcell.xyz = gridcell - floor(gridcell * ( 1.0 / DOMAIN )) * DOMAIN;
				gridcell.xy += OFFSET.xy;
				gridcell.xy *= gridcell.xy;
				return frac( ( gridcell.x * gridcell.y ) * ( 1.0 / ( SOMELARGEFLOATS + gridcell.zzzz * ZINC ) ) );
			}
			
			float Cellular3D(float3 xyz, int cellType, int distanceFunction) 
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
				float3 cell;
 
				for (int z = -1; z <= 1; z++) {
					for (int y = -1; y <= 1; y++) {
						for (int x = -1; x <= 1; x++) {
							cell = FAST32_hash_3D_Cell(float3(xi + x, yi + y, zi + z)).xyz;
							cell.x += (float(x) - xf);
							cell.y += (float(y) - yf);
							cell.z += (float(z) - zf);
							float dist = 0.0;
							if(distanceFunction <= 1)
							{
								dist = sqrt(dot(cell, cell));
							}
							else if(distanceFunction > 1 && distanceFunction <= 2)
							{
								dist = dot(cell, cell);
							}
							else if(distanceFunction > 2 && distanceFunction <= 3)
							{
								dist = abs(cell.x) + abs(cell.y) + abs(cell.z);
								dist *= dist;
							}
							else if(distanceFunction > 3 && distanceFunction <= 4)
							{
								dist = max(abs(cell.x), max(abs(cell.y), abs(cell.z)));
								dist *= dist;
							}
							else if(distanceFunction > 4 && distanceFunction <= 5)
							{
								dist = dot(cell, cell) + cell.x*cell.y + cell.x*cell.z + cell.y*cell.z;	
							}
							else if(distanceFunction > 5 && distanceFunction <= 6)
							{
								dist = pow(cell.x*cell.x*cell.x*cell.x + cell.y*cell.y*cell.y*cell.y + cell.z*cell.z*cell.z*cell.z, 0.25);
							}
							else if(distanceFunction > 6 && distanceFunction <= 7)
							{
								dist = sqrt(abs(cell.x)) + sqrt(abs(cell.y)) + sqrt(abs(cell.z));
								dist *= dist;
							}
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
 
				if(cellType <= 1)	// F1
					return dist1;	//	scale return value from 0.0->1.333333 to 0.0->1.0  	(2/3)^2 * 3  == (12/9) == 1.333333
				else if(cellType > 1 && cellType <= 2)	// F2
					return dist2;
				else if(cellType > 2 && cellType <= 3)	// F3
					return dist3;
				else if(cellType > 3 && cellType <= 4)	// F4
					return dist4;
				else if(cellType > 4 && cellType <= 5)	// F2 - F1 
					return dist2 - dist1;
				else if(cellType > 5 && cellType <= 6)	// F3 - F2 
					return dist3 - dist2;
				else if(cellType > 6 && cellType <= 7)	// F1 + F2/2
					return dist1 + dist2/2.0;
				else if(cellType > 7 && cellType <= 8)	// F1 * F2
					return dist1 * dist2;
				else if(cellType > 8 && cellType <= 9)	// Crackle
					return max(1.0, 10*(dist2 - dist1));
			}

			//
			// 3D fracional Brownian Motion
			//
			float fBM(float3 p, float3 offset, float3 scale, float3 turbulence, float turbulencePower, float frequency, float amplitude, int cellType, int distanceFunction)
			{
				float h = 0.0;
				h = Cellular3D((float3(p.x*scale.x+turbulence.x*turbulencePower, p.y*scale.y+turbulence.y*turbulencePower, p.z*scale.z+turbulence.z*turbulencePower)+offset) * frequency, cellType, distanceFunction);
				h += h*amplitude;
				return h;
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
				float h = fBM(float3(i.worldPos.xyz), _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _CellType, _DistanceFunction);

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
