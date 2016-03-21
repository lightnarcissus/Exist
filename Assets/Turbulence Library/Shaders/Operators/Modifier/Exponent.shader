//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/Operator/Exponent" 
{
	Properties 
	{
		_HeightMap("Height Map", 2D) = ""{}
		_Exponent("Exponent", Float) = 1.0
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
			
            sampler2D _HeightMap;
			float4 _HeightMap_ST;
			float _Exponent;

			//
			// Vertex shader
			//
			
			struct v2f 
			{
				float4 position : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			v2f vert (appdata_base v)
			{
				v2f o;
				o.position = mul(UNITY_MATRIX_MVP, v.vertex);
				o.texcoord = v.texcoord.xy * 5.0;
				return o;
			}

			//
			// Fragment shader
			//

			float4 frag (v2f i) : COLOR
			{
				float4 heightmap;
				heightmap = tex2D(_HeightMap, _HeightMap_ST.xy * i.texcoord + _HeightMap_ST.zw);
				
				return pow(abs((heightmap + 1.0) / 2.0), _Exponent) * 2.0 - 1.0;
			}

			ENDCG
		}
	} 
	FallBack "VertexLit"
}
