// Upgrade NOTE: replaced '_Projector' with 'unity_Projector'
// Upgrade NOTE: replaced '_ProjectorClip' with 'unity_ProjectorClip'

Shader "Projector/Multiply" {
	Properties {
		_ShadowTex ("Cookie", 2D) = "gray" {}
	}
	Subshader {
		Tags {"Queue"="Transparent"}
		Pass {
			ZWrite Off
			ColorMask RGB
			Blend DstColor Zero
			Offset -1, -1

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#include "UnityCG.cginc"
			
			struct v2f {
				float4 uvShadow : TEXCOORD0;
				UNITY_FOG_COORDS(2)
				float4 pos : SV_POSITION;
				float4 normal : NORMAL;				
				float4 toProjector : VECTOR;
			};
			
			float4x4 unity_Projector;
			float4x4 unity_ProjectorClip;
			
			v2f vert (appdata_base v)
			{
				v2f o;
				o.toProjector = mul (unity_ProjectorClip, float4(0, 0, 1, 0));
				o.normal = mul(unity_ProjectorClip, mul (UNITY_MATRIX_M, v.normal));
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.uvShadow = mul (unity_Projector, v.vertex);
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}
			
			sampler2D _ShadowTex;
			sampler2D _FalloffTex;
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 texS;
				if (i.uvShadow.x < 0 || i.uvShadow.x > 1 || i.uvShadow.y < 0 || i.uvShadow.y > 1 || dot(i.toProjector, i.normal) <= 0) {
					texS = fixed4(1, 1, 1, 1);
				} else {
					texS = tex2Dproj (_ShadowTex, UNITY_PROJ_COORD(i.uvShadow));
				}
				texS.a = 1.0-texS.a;


				fixed4 res = texS;


				UNITY_APPLY_FOG_COLOR(i.fogCoord, res, fixed4(1,1,1,1));
				return res;
			}
			ENDCG
		}
	}
}
