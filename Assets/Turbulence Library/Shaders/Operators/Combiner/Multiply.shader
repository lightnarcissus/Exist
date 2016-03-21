//
// Turbulence Library - GPU Noise Generator
// Developped by Jérémie St-Amand - jeremie.stamand@gmail.com
//

Shader "Noise/Operator/Multiply" 
{
	Properties 
	{
		_HeightMap1("Height Map 1", 2D) = ""{}
		_HeightMap2("Height Map 2", 2D) = ""{}
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
				o.texcoord = v.texcoord.xy;
				return o;
			}

			//
			// Fragment shader
			//

			float4 frag (v2f i) : COLOR
			{
				float4 heightmap1, heightmap2;
				heightmap1 = tex2D(_HeightMap1, _HeightMap1_ST.xy * i.texcoord + _HeightMap1_ST.zw);
				heightmap2 = tex2D(_HeightMap2, _HeightMap2_ST.xy * i.texcoord + _HeightMap2_ST.zw);
				
				return heightmap1 * heightmap2;
			}

			ENDCG
		}
	} 
	FallBack "VertexLit"
}
