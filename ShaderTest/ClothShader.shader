//
//混合效果
//

Shader "Custom/ClothShader" {
	Properties {
		_MainTex("Base (RGB)",2D)="White"{}
	    _Maintex2("Another Texture",2D)="white"{}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		
		#pragma surface surf Lambert

		sampler2D _MainTex;
	    sampler2D _MainTex2;

		struct Input {
			float2 uv_MainTex;
		};


		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 c2 = tex2D(_MainTex2, IN.uv_MainTex);
			o.Albedo = c.rgb*(1.0 - c2.a) + c2.rgb*c2.a;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
