Shader "Custom/ResizeAndPosition" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
			ZTest Always Cull Off ZWrite Off
		Fog { Mode off }
		Tags { "RenderType"="Opaque" } 
		LOD 200
		Pass {
		CGPROGRAM
		#pragma vertex vert 
		#pragma fragment frag 
		
		#include "UnityCG.cginc"
		sampler2D _MainTex;		
		half4 frag (v2f_img i) : COLOR
		{
			return half4(tex2D(_MainTex, i.texcoord).rgb, .5 );
		}
		ENDCG
		} 
	}
	FallBack "Diffuse"
}
