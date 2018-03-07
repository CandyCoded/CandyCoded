Shader "CandyCoded/Tiled Texture" {
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
        [MaterialToggle] _WorldSpace ("Use World Space", Float) = 0
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

            fixed4 _Color;
            uniform sampler2D _MainTex;
            float4 _MainTex_ST;
            float _WorldSpace;

            v2f vert (appdata v)
            {

                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                if (_WorldSpace == 1) {

                    float scaleX = length(mul(unity_ObjectToWorld, float2(1.0, 0.0))) + (_MainTex_ST.x - 1);
                    float scaleY = length(mul(unity_ObjectToWorld, float2(0.0, 1.0))) + (_MainTex_ST.y - 1);

                    float2 worldXY = mul(unity_ObjectToWorld, v.vertex).xy / float2(scaleX, scaleY);

                    o.uv = TRANSFORM_TEX(worldXY, _MainTex);

                } else {

                    o.uv = v.texcoord;

                }

                return o;

            }

            half4 frag(v2f i) : COLOR
            {

                float scaleX = length(mul(unity_ObjectToWorld, float2(1.0, 0.0))) + (_MainTex_ST.x - 1);
                float scaleY = length(mul(unity_ObjectToWorld, float2(0.0, 1.0))) + (_MainTex_ST.y - 1);

                half4 c = tex2D(_MainTex, fmod(i.uv * float2(scaleX, scaleY), 1)) * _Color;

                return c;

            }

            ENDCG
        }
    }
}
