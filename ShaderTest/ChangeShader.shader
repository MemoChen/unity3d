// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
//
//使用定点的世界坐标
//

Shader "Custom/ChangeShader" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
	    _Color1("Color 1", Color) = (1, 1, 1, 1)
		_Color2("Color 2", Color) = (1, 1, 1, 1)
		_BorderColor("边界颜色", Color) = (1, 1, 1, 1)
		_BorderThick("边界厚度", Range(0.01, 3)) = 0.1
		_Bulge("边界凸出程度", Range(0.01, 0.3)) = 0.08
		_CullPos("裁剪球位置", Range(0, 3)) = 3
		_CullRadius("裁剪球半径", Range(0.1, 5)) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert vertex:Myvert

		sampler2D _MainTex;
		fixed4 _Color1;
		fixed4 _Color2;
		fixed4 _BorderColor;
		float _BorderThick;
		float _Bulge;
		float _CullPos;
		float _CullRadius;

		struct Input {
			float2 uv_MainTex;
			float3 worldSpacePos;
		};

		inline float GetDis(float3 pos) {
			return distance(pos, float3(_CullPos, _CullPos, _CullPos));
		}
		//为了使用顶点坐标，我们需要使用顶点函数，将顶点坐标传入Input结果，再传入surf中进行处理。
		//这里的unity_Object2World是Unity Shader内置的一个变量，表示从局部坐标到世界坐标的变换矩阵，我们用顶点的局部坐标与该矩阵相乘，得到的就是顶点的世界坐标。
		void Myvert(inout appdata_full v, out Input IN) {
			UNITY_INITIALIZE_OUTPUT(Input, IN);
			IN.worldSpacePos = mul(unity_ObjectToWorld, v.vertex);
			if (abs(GetDis(IN.worldSpacePos.xyz) - _CullRadius) <= _BorderThick / 2)
			{
				v.vertex.xyz += v.normal*_Bulge;
			}
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 tint;
			if (abs(GetDis(IN.worldSpacePos.xyz) - _CullRadius) <= _BorderThick / 2)
			{
				tint = _BorderColor;
			}
			else if(GetDis(IN.worldSpacePos.xyz)>_CullRadius)
			{
			tint = _Color1;
			}
			else
			{
			tint = _Color2;
			}
			half4 c = tex2D(_MainTex,IN.uv_MainTex);
			o.Albedo = tint.rgb*c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
