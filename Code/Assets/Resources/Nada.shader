Shader "Custom/Nada" 
{
	Properties
	{
		_Color("Tint Color", Color) = (1.0, 1.0, 1.0, 0.5)
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" }
		//LOD 200
		ZWrite Off

		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			//#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
			//#pragma target 3.0

			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma vertex vert
			#pragma fragment frag

			uniform fixed4 _Color;

			struct vertexInput
			{
				float4 vertex : POSITION;
			};

			struct fragmentInput
			{
				float4 pos : SV_POSITION;
				float4 color : COLOR0;
			};

			fragmentInput vert(vertexInput i)
			{
				fragmentInput o;
				o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
				o.color = _Color;

				return o;
			}

			half4 frag(fragmentInput i) : COLOR
			{
				return i.color;
			}

			ENDCG
		}
	}

	FallBack "Diffuse"
}
