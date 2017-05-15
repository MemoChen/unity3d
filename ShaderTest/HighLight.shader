///
///利用贴图模拟不同部分的高光
///
///

Shader "Custom/HighLight" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SpecColor ("Specular Color", Color) = (1,1,1,1)
		_SpecularMap ("SpecularMap", 2D) = "white" {}
		_Gloss("Gloss",Range(0.01,10))=0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based , and enable shadows on all light types
		#pragma surface surf BlinnPhong

		sampler2D _MainTex;
		sampler2D _SpecularMap;
		float _SpecularPower;
		float _Gloss;

		struct Input {
			float2 uv_MainTex;
		};


		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			half4 s = tex2D(_SpecularMap, IN.uv_MainTex);
			o.Specular = s.r;
			o.Gloss = _Gloss;
			o.Albedo = c.rgb;			
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
