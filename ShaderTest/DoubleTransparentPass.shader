// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

///
///多Pass渲染
///为了实现正反面的不同渲染
///我们需要两个Pass进行渲染
///第一个使用Cull Back语句，只渲染正面
///第二个用Cull Front语句，只渲染背面
///



Shader "Custom/DoubleTransparentPass" {
	Properties{
		_FrontColor("Front Color",Color) = (1,1,1,1)
		_BackColor("Back color",Color) = (1,1,1,1)
	}
		SubShader{
				Tags { "Queue" = "Transparent" }
				LOD 200

		Pass{
				Blend SrcAlpha OneMinusSrcAlpha
				ZWrite Off
				Cull Front
				CGPROGRAM
			 #pragma vertex vert
			 #pragma fragment frag
			 #include "UnityCG.cginc"

			 uniform float4 _BackColor;
			 float4 vert(float4 vertPos:POSITION) :SV_POSITION
			 {
				return UnityObjectToClipPos(vertPos);
			 }
			 float4 frag(float4 vertPos:SV_POSITION) : COLOR
			 {
				return _BackColor;
			 }
				 ENDCG
		}
			Pass{
					  Blend SrcAlpha OneMinusSrcAlpha
					  ZWrite Off
					  Cull Back
					  CGPROGRAM
		 #pragma vertex vert
		 #pragma fragment frag
		 #include "UnityCG.cginc"

			 uniform float4 _FrontColor;
			 float4 vert(float4 vertPos : POSITION) :SV_POSITION
			 {
				 return UnityObjectToClipPos(vertPos);
			 }
			 float4 frag(float4 vertPos:SV_POSITION) : COLOR
			 {
				 return _FrontColor;
			 }
				 ENDCG
		 }

	}
		FallBack "Diffuse"
}
