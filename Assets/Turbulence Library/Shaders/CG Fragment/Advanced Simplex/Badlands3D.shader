//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/CG/Advacned Simplex/Badlands3D" 
{
	Properties 
	{
		_Octaves ("Octaves", Range(0, 20)) = 10
		_LowColor("Low Color", Vector) = (0.0, 0.0, 0.0, 1.0)
		_HighColor("High Color", Vector) = (1.0, 1.0, 1.0, 1.0)
		_Texturing("Texturing", Range(-1, 1)) = -1.0
		_LowTexture("Low Texture", 2D) = "" {} 
		_HighTexture("High Texture", 2D) = "" {}
		_TurbulenceMapX("Turbulence Map X", 2D) = "black" {}
		_TurbulenceMapY("Turbulence Map Y", 2D) = "black" {}
		_TurbulenceMapZ("Turbulence Map Z", 2D) = "black" {}
		_TurbulencePower("Turbulence Power", Float) = 1.0
		_Frequency ("Frequency", Float) = 0.25
		_Amplitude ("Amplitude", Float) = 0.1
		_Lacunarity ("Lacunarity", Float) = 1.92
		_Persistence ("Persistence", Float) = 0.75
		_NoiseOffset ("Noise Offset", Vector) = (0.0, 0.0, 0.0)
		_NoiseScale ("Noise Scale", Vector) = (1.0, 1.0, 1.0)
		_Contribution("Contribution", Float) = 0.5
		_Normalize("Normalize", Range(-1, 1)) = -1.0
		_Floor ("Floor", Float) = 0.5
		_Powered("Powered", Range(-1, 1)) = 1.0
		_RidgePower("Ridge Power", Range(1.0, 8.0)) = 1.0
		_RidgeOffset("Ridge Offset", Float) = 0.3
		_Warp("Warp", Float) = 0.15
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
			#pragma vertex vert
			#pragma fragment frag
			
			int _Octaves;
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
			float _Lacunarity;
			float _Persistence;
			float _Floor;
			int _Powered;
			float _RidgePower;
			float _RidgeOffset;
			float _Warp;

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
			void FAST32_hash_3D(float3 gridcell,
								float3 v1_mask,		//	user definable v1 and v2.  ( 0's and 1's )
								float3 v2_mask,
								out float4 hash_0,
								out float4 hash_1,
								out float4 hash_2	)		//	generates 3 random numbers for each of the 4 3D cell corners.  cell corners:  v0=0,0,0  v3=1,1,1  the other two are user definable
			{
				//    gridcell is assumed to be an integer coordinate

				//	TODO: 	these constants need tweaked to find the best possible noise.
				//			probably requires some kind of brute force computational searching or something....
				const float2 OFFSET = float2( 50.0, 161.0 );
				const float DOMAIN = 69.0;
				const float3 SOMELARGEFLOATS = float3( 635.298681, 682.357502, 668.926525 );
				const float3 ZINC = float3( 48.500388, 65.294118, 63.934599 );

				//	truncate the domain
				gridcell.xyz = gridcell.xyz - floor(gridcell.xyz * ( 1.0 / DOMAIN )) * DOMAIN;
				float3 gridcell_inc1 = step( gridcell, float3( DOMAIN - 1.5 ) ) * ( gridcell + 1.0 );

				//	compute x*x*y*y for the 4 corners
				float4 P = float4( gridcell.xy, gridcell_inc1.xy ) + OFFSET.xyxy;
				P *= P;
				float4 V1xy_V2xy = lerp( P.xyxy, P.zwzw, float4( v1_mask.xy, v2_mask.xy ) );		//	apply mask for v1 and v2
				P = float4( P.x, V1xy_V2xy.xz, P.z ) * float4( P.y, V1xy_V2xy.yw, P.w );

				//	get the lowz and highz mods
				float3 lowz_mods = float3( 1.0 / ( SOMELARGEFLOATS.xyz + gridcell.zzz * ZINC.xyz ) );
				float3 highz_mods = float3( 1.0 / ( SOMELARGEFLOATS.xyz + gridcell_inc1.zzz * ZINC.xyz ) );

				//	apply mask for v1 and v2 mod values
				v1_mask = ( v1_mask.z < 0.5 ) ? lowz_mods : highz_mods;
				v2_mask = ( v2_mask.z < 0.5 ) ? lowz_mods : highz_mods;

				//	compute the final hash
				hash_0 = frac( P * float4( lowz_mods.x, v1_mask.x, v2_mask.x, highz_mods.x ) );
				hash_1 = frac( P * float4( lowz_mods.y, v1_mask.y, v2_mask.y, highz_mods.y ) );
				hash_2 = frac( P * float4( lowz_mods.z, v1_mask.z, v2_mask.z, highz_mods.z ) );
			}

			//
			//	Given an arbitrary 3D point this calculates the 4 vectors from the corners of the simplex pyramid to the point
			//	It also returns the integer grid index information for the corners
			//
			void Simplex3D_GetCornerVectors( 	float3 P,					//	input point
												out float3 Pi,			//	integer grid index for the origin
												out float3 Pi_1,			//	offsets for the 2nd and 3rd corners.  ( the 4th = Pi + 1.0 )
												out float3 Pi_2,
												out float4 v1234_x,		//	vectors from the 4 corners to the intput point
												out float4 v1234_y,
												out float4 v1234_z )
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
				Pi = floor( P + dot( P, float3( SKEWFACTOR) ) );
				float3 x0 = P - Pi + dot(Pi, float3( UNSKEWFACTOR ) );
				float3 g = step(x0.yzx, x0.xyz);
				float3 l = 1.0 - g;
				Pi_1 = min( g.xyz, l.zxy );
				Pi_2 = max( g.xyz, l.zxy );
				float3 x1 = x0 - Pi_1 + UNSKEWFACTOR;
				float3 x2 = x0 - Pi_2 + SKEWFACTOR;
				float3 x3 = x0 - SIMPLEX_CORNER_POS;

				//	pack them into a parallel-friendly arrangement
				v1234_x = float4( x0.x, x1.x, x2.x, x3.x );
				v1234_y = float4( x0.y, x1.y, x2.y, x3.y );
				v1234_z = float4( x0.z, x1.z, x2.z, x3.z );
			}

			//
			//	Calculate the weights for the 3D simplex surflet
			//
			float4 Simplex3D_GetSurfletWeights( 	float4 v1234_x,
												float4 v1234_y,
												float4 v1234_z )
			{
				//	perlins original implementation uses the surlet falloff formula of (0.6-x*x)^4.
				//	This is buggy as it can cause discontinuities along simplex faces.  (0.5-x*x)^3 solves this and gives an almost identical curve

				//	evaluate surflet. f(x)=(0.5-x*x)^3
				float4 surflet_weights = v1234_x * v1234_x + v1234_y * v1234_y + v1234_z * v1234_z;
				surflet_weights = max(0.5 - surflet_weights, 0.0);		//	0.5 here represents the closest distance (squared) of any simplex pyramid corner to any of its planes.  ie, SIMPLEX_PYRAMID_HEIGHT^2
				return surflet_weights*surflet_weights*surflet_weights;
			}

			//
			//	SimplexPerlin3D_Deriv
			//	SimplexPerlin3D noise with derivatives
			//	returns float3( value, xderiv, yderiv, zderiv )
			//
			float4 SimplexPerlin3D_Deriv(float3 P)
			{
				//	calculate the simplex vector and index math
				float3 Pi;
				float3 Pi_1;
				float3 Pi_2;
				float4 v1234_x;
				float4 v1234_y;
				float4 v1234_z;
				Simplex3D_GetCornerVectors( P, Pi, Pi_1, Pi_2, v1234_x, v1234_y, v1234_z );

				//	generate the random vectors
				//	( various hashing methods listed in order of speed )
				float4 hash_0;
				float4 hash_1;
				float4 hash_2;
				FAST32_hash_3D( Pi, Pi_1, Pi_2, hash_0, hash_1, hash_2 );
				//SGPP_hash_3D( Pi, Pi_1, Pi_2, hash_0, hash_1, hash_2 );
				hash_0 -= 0.49999;
				hash_1 -= 0.49999;
				hash_2 -= 0.49999;

				//	normalize random gradient vectors
				float4 norm = rsqrt( hash_0 * hash_0 + hash_1 * hash_1 + hash_2 * hash_2 );
				hash_0 *= norm;
				hash_1 *= norm;
				hash_2 *= norm;

				//	evaluate gradients
				float4 grad_results = hash_0 * v1234_x + hash_1 * v1234_y + hash_2 * v1234_z;

				//	evaluate the surflet f(x)=(0.5-x*x)^3
				float4 m = v1234_x * v1234_x + v1234_y * v1234_y + v1234_z * v1234_z;
				m = max(0.5 - m, 0.0);		//	The 0.5 here is SIMPLEX_PYRAMID_HEIGHT^2
				float4 m2 = m*m;
				float4 m3 = m*m2;

				//	calc the deriv
				float4 temp = -6.0 * m2 * grad_results;
				float xderiv = dot( temp, v1234_x ) + dot( m3, hash_0 );
				float yderiv = dot( temp, v1234_y ) + dot( m3, hash_1 );
				float zderiv = dot( temp, v1234_z ) + dot( m3, hash_2 );

				const float FINAL_NORMALIZATION = 37.837227241611314102871574478976;	//	scales the final result to a strict 1.0->-1.0 range

				//	sum with the surflet and return
				return float4( dot( m3, grad_results ), xderiv, yderiv, zderiv ) * FINAL_NORMALIZATION;
			}

			float4 ridge(float3 p, int powered, float ridgePower, float offset)
			{
				// Powered Ridge
				if(powered > 0)
				{
					return pow(offset - abs(4*SimplexPerlin3D_Deriv(p)), ridgePower);
				}
				else
				{
					return offset - abs(4*SimplexPerlin3D_Deriv(p));
				}
			}

			//
			// 3D Fractional Brownian Motion
			//
			float fBM(float3 p, int octaves, float floorV, float3 offset, float3 scale, float3 turbulence, float turbulencePower, float frequency, float amplitude, float lacunarity, float persistence, int powered, float ridgePower, float ridgeOffset, float warp)
			{
				float sum = floorV;
				float bias = 0.0;
				float3 dsum = float3(0.0, 0.0, 0.0);
				for (int i = 0; i < 20; i++)
				{
					if(i >= octaves) break;
					float4 n = 0.25 * (0 + ridge((float3(p.x*scale.x+turbulence.x*turbulencePower, p.y*scale.y+turbulence.y*turbulencePower, p.z*scale.z+turbulence.z*turbulencePower)+offset+warp*dsum)*frequency, powered, ridgePower, ridgeOffset));
					sum += amplitude * n.y * n.z * n.w;
					dsum += amplitude * n.yzw * -n.x;
					bias -= amplitude;
					frequency *= lacunarity;
					amplitude *= persistence * saturate(sum);
				}
				sum += 0.5 * bias;
				return sum;
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
				float h = fBM(float3(i.worldPos.xyz), _Octaves, _Floor, _NoiseOffset, _NoiseScale, turbulence, _TurbulencePower, _Frequency, _Amplitude, _Lacunarity, _Persistence, _Powered, _RidgePower, _RidgeOffset, _Warp);

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
