Shader "Custom/CubeShader" {
	Properties {		
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MoveAmount ("MoveAmount", Range(-1,1)) = 0		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf MyLight vertex:MyVert finalcolor:MyFinalColor 

		sampler2D _MainTex;
		float _MoveAmount;

		struct Input {
			float2 uv_MainTex;
			float4 vertColor;
		};
		//在MyVert中，我们修改了原来顶点的位置，
		//在Unity中拖动Shader中的MoveAmount，立方体就会发生变化
		void MyVert(inout appdata_full v, out Input IN)
		{
			UNITY_INITIALIZE_OUTPUT(Input, IN);
			v.vertex.xyz += v.normal * _MoveAmount;
			IN.vertColor = v.color;
		}

		void surf(Input IN,inout SurfaceOutput o)
		{
			float4 c;
			c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		inline fixed4 LightingMyLight(SurfaceOutput s,fixed3 lightDir,fixed atten)
		{
			fixed diff = max(0, dot(s.Normal, lightDir));

			fixed4 c;
			c.rgb=s.Albedo * _LightColor0.rgb * (diff * atten * 2);
			c.a = s.Alpha;
			return c;
		}

		//MyFinalColor函数中，直接用光照模型输出的颜色信息作为最终的颜色信息
		void MyFinalColor(Input IN, SurfaceOutput o, inout fixed4 color) {
			color = color;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
