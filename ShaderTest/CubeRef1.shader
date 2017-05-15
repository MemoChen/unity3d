///
///反光材质
///利用天空盒实现简单的反光效果
///
///

Shader "Custom/CubeRef1" {
	Properties {
		_MainTint("Main Color", Color) = (1, 1, 1, 1)
		_MainTex("Base (RGB)", 2D) = "white" {}
	    _CubeMap("Cube Map", CUBE) = ""{}
	    _ReflPower("Refl Power", Range(0, 1)) = 0.5
		_FresnelPower("Frensnel Power", Range(0.1, 5)) = 2
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		samplerCUBE _CubeMap;
		fixed4 _MainTint;
		fixed _ReflPower;
		fixed _FresnelPower;

		//菲涅尔效果
		//当我们观察物体表面的角度(相对于法线)越大时，看到的反射效果也越明显。
		struct Input {
			float2 uv_MainTex;
			float3 worldRefl;
			float3 viewDir;

		};
		//用viewDir这个变量，我们可以轻松表示出观察物体表面角度的变化。
		//利用这种变化我们可以实现出很多效果，比如边缘发光，随视角变化的颜色衰减等
		
		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			fixed diff = 1.0 - saturate(dot(o.Normal, normalize(IN.viewDir)));
			diff = pow(diff, _FresnelPower);
			
			o.Albedo = _MainTint.rgb * c.rgb;
			o.Emission = texCUBE(_CubeMap, IN.worldRefl).rgb*diff*_ReflPower;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
