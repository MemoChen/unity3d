//
//屏幕特效
//屏幕特效另一个比较特殊的地方是它不能用Surface Shader，
//为了使用屏幕特效，我们需要Unity Shader的另一种形式：
//Vertex & FragMent Shader，或者叫可编程Shader。
//
//

Shader "Custom/ImageEffect"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color("Color",Color) = (1,1,1,1)
	}
		SubShader
		{
			Tags{"RenderType" = "Opaque"}
			LOD 200

			Pass
			{
				CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fast
				#include "UnityCG.cginc"

				uniform sampler2D _MainTex;
		        uniform fixed _Color;
		//通过定义_MainTex，我们可以使用RenderTexture中的信息，
		//也就是待处理的画面。通过v2f_img中的uv分量可以得到具体的颜色值。
		//v2f_img的定义可以在UnityCG.cginc中找到。

			fixed4 frag (v2f_img v) : COLOR
			{
				fixed4 c= tex2D(_MainTex, v.uv);								
			return _Color*c;
			}
			ENDCG
		}
	}
			FallBack "Diffuse"
}
