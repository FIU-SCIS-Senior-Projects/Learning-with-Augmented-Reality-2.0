// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader ".ShderTalk/Test_Diffuse"
{
	Properties
	{
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white" {}
	}

	SubShader
	{
		Pass
		{
			Tags{ "LightMode" = "ForwardBase" }
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
					float2 texcoord : TEXCOORD0;
				};

				struct v2f
				{
					float4 pos : SV_POSITION;
					float3 normal : NORMAL;
					float2 texcoord : TEXCOORD0;
				};

				//PROPERTIES//

				float4 _Color;
				sampler2D _MainTex;
				float4 _LightColor0;
				float4 _MainTex_ST;

				
				//SHADERS//

				//Vertex Shader
				v2f vert(appdata IN)
				{
					v2f OUT;
					OUT.pos = mul(UNITY_MATRIX_MVP, IN.vertex);
					OUT.normal = mul(float4(IN.normal, 0.0), unity_ObjectToWorld).xyz;
					//OUT.normal = IN.normal;
					OUT.texcoord = TRANSFORM_TEX(IN.texcoord, _MainTex); //was = IN.texcoord; which made it flicker
					return OUT;
				}

				//Fragment Shader
				fixed4 frag(v2f IN) : COLOR
				{
					fixed4 texColor = tex2D(_MainTex, IN.texcoord);
					//return texColor;

					float3 normalDirection = normalize(IN.normal);
					float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
					float3 diffuse = _LightColor0.rgb * max(0.0, dot(normalDirection, lightDirection));  //max checks if dot product is negative number(up to -1) just give us 0 instead

					return _Color * texColor * float4(diffuse, 1);
					//return _Color;
				}
				ENDCG
		}
	}
}