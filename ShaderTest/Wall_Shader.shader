///
///
///法线贴图
///
///

Shader "Custom/Wall_Shader" {
	Properties{
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpTex("法线贴图",2D) = "bump"{}
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf MyLambert

		sampler2D _MainTex;
		sampler2D _BumpTex;

		struct Input {
			float2 uv_MainTex;
		};

		//在代码中定义了一幅新的贴图，
		//在surf方法中通过tex2D取得贴图的信息，
		//UnpackNormal方法将其转换为对应的法线值
		inline fixed4 LightingMyLambert(SurfaceOutput s, fixed3 lightDir, fixed atten) {
			fixed diff = max(0, dot(s.Normal, lightDir));
			fixed4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten * 2);
			c.a = s.Alpha;
			return c;
		}

		void surf(Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Normal = UnpackNormal(tex2D(_BumpTex, IN.uv_MainTex));
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
		FallBack "Diffuse"
}
