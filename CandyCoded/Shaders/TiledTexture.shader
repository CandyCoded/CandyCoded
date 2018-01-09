Shader "CandyCoded/Tiled Texture" {
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD;
            };

            uniform sampler2D _MainTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;

                return o;
            }

            half4 frag(v2f i) : COLOR
            {

                float scaleX = length(mul(unity_ObjectToWorld, float2(1.0, 0.0)));
                float scaleY = length(mul(unity_ObjectToWorld, float2(0.0, 1.0)));

                half4 c = tex2D(_MainTex, fmod(i.uv * float2(scaleX, scaleY), 1));

                return c;
            }

            ENDCG
        }
    }
}
