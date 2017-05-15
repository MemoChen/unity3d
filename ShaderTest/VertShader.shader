///
///平面扭曲
///首先在vert函数中修改了模型顶点的y值，实现了y值随时间变化的效果(可以回忆一下UV动画)，
///同时将Input中的顶点颜色赋值。在surf中，对vert传入的颜色，计算出片段颜色。
///需要注意的是我们有一句Cull Off，它是在CGPROGRAM和CGEND外面的，也就是说它不是Cg代码。
///那么这句是做什么的呢？默认情况下，网格的背面是不会被绘制的(因为一般情况下看不见)，
///但是我们这个例子中，当平面扭动的时候可以看到网格背面。如果没有Cull Off，
///就会看到网格背面是透明的，Cull Off就是关闭隐藏表面消除。
///



Shader "Custom/VertShader" {
	Properties {	
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		Cull Off
		
		CGPROGRAM
		#pragma surface surf Lambert vertex:MyVert


		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float4 vertCol;
		};
		void MyVert(inout appdata_full v,out Input IN) {
			//Shader的默认渲染目标是DirectX 11，必须手动初始化Input。
			//我们可以在Edit->Project Setting->Player界面设置，选择Other Setting，
			//可以找到use Direct3D 11的选项。如果我们不想改或者确实需要Direct3D 11，
			//也可以直接用Unity给的方式初始化一下：
			UNITY_INITIALIZE_OUTPUT(Input, IN);
			
			v.vertex.y = sin(_Time.y + v.vertex.x);
			float absh = abs(v.vertex.y);
			IN.vertCol = float4(absh, absh, absh, 1.0);
		}

		void surf (Input IN, inout SurfaceOutput o) {
			
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = IN.vertCol.rgb;			
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
