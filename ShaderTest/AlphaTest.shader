///
///透明材质
///使用AlphaTest实现透明效果
///种实现透明的方式是利用裁剪。
///这种方式的基本原理就是利用片段的透明度和我们给定的一个透明度做对比，
///当片段的透明度大于给定透明度时就表现为不透明，否则就是透明(其实是被丢掉)。
///因此这种方式作出的效果除了完全透明的部分就是完全不透明的部分。
///


Shader "Custom/AlphaTest" {
	Properties{
		_MainColor("Main Color", Color) = (1, 1, 1, 1)
		_MainTex("Base (RGB)", 2D) = "white" {}
		_TestVal("Test Value", Range(0, 1)) = 0.5
	}
		SubShader{
			Tags { "Queue" = "Transparent" "RenderType" = "Opaque" }
			LOD 200

			//要使用AlphaTest，需要在#pragma后面添加alphatest:xxx，这个xxx就是我们给定的透明度。
			CGPROGRAM
			#pragma surface surf Lambert alphatest:_TestVal

		fixed4 _MainColor;
		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = _MainColor.rgb*c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
		}
			FallBack "Diffuse"
}
//这种AlphaTest看上去比半透明的方式更有效率，事实上，
//大部分情况确实如此。一个例外是在移动设备上，AlphaTest在移动设备上效率非常低，甚至不如第一种半透明的方式。