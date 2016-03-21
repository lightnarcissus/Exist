//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/Operator/Blend" 
{
	Properties 
	{
		_HeightMap1("Height Map 1", 2D) = ""{}
		_HeightMap2("Height Map 2", 2D) = ""{}
		_ControlMap("Control Map", 2D) = ""{}
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
			
            sampler2D _HeightMap1;
			float4 _HeightMap1_ST;
            sampler2D _HeightMap2;
			float4 _HeightMap2_ST;
			sampler2D _ControlMap;
			float4 _ControlMap_ST;

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
				float4 heightmap1, heightmap2, alpha;
				heightmap1 = tex2D(_HeightMap1, _HeightMap1_ST.xy * i.texcoord + _HeightMap1_ST.zw);
				heightmap2 = tex2D(_HeightMap2, _HeightMap2_ST.xy * i.texcoord + _HeightMap2_ST.zw);
				alpha = (tex2D(_ControlMap, _ControlMap_ST.xy * i.texcoord + _ControlMap_ST.zw) + 1.0)/2.0;
				
				return lerp(heightmap1, heightmap2, alpha);
			}

			ENDCG
		}
	} 
	FallBack "VertexLit"
}
