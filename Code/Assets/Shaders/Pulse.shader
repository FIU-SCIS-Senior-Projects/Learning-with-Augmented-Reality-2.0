Shader "Custom/Pulse" {
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		
		#include "UnityPBSLighting.cginc"

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input 
		{
			float2 uv_MainTex;
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		float _ConstructY;
		fixed4 _ConstructColor;
		int building;

		void surf(Input IN, inout SurfaceOutputStandard o) 
		{

			if (IN.worldPos.y < _ConstructY)
			{
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				o.Alpha = c.a;

				building = 0;
			}
			else
			{
				o.Albedo = _ConstructColor.rgb;
				o.Alpha = _ConstructColor.a;

				building = 0;
			}

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
		}

		#pragma surface surf Unlit fullforwardshadows
		inline half4 LightingUnlit(SurfaceOutput s, half3 lightDir, half atten)
		{
			return _ConstructColor;
		}

		/*inline half4 LightingUnlit(SurfaceOutputStandard s, half3 lightDir, UnityGI gi)
		{
			return _ConstructColor;
		}		*/

		#pragma surface surf Custom
		inline half4 LightingCustom(SurfaceOutputStandard s, half3 lightDir, UnityGI gi)
		{
			if (!building)
			{
				return LightingStandard(s, lightDir, gi); //Unity5 PBR
			}
			return _ConstructColor; //Unlit
		}

		inline void LightingCustom_GI(SurfaceOutputStandard s, UnityGIInput data, inout UnityGI gi)
		{
			LightingStandard_GI(s, data, gi);
		}

		ENDCG
	}
	FallBack "Diffuse"
}
