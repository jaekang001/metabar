Shader "Custom/2DWaterShader"  {
    Properties{
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
        _TransitionTex("Transition Texture", 2D) = "white" {}
        _Cutoff("Cutoff", Range(0, 1)) = 0
        [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
        _Rotation("Rotation", Range(-180, 180)) = 0
    }

        SubShader{
            Tags {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
                "PreviewType" = "Plane"
                "CanUseSpriteAtlas" = "True"
            }

            Cull Off
            Lighting Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile _ PIXELSNAP_ON
                #include "UnityCG.cginc"

                struct appdata_t {
                    float4 vertex   : POSITION;
                    float4 color    : COLOR;
                    float2 texcoord : TEXCOORD0;
                };

                struct v2f {
                    float4 vertex   : SV_POSITION;
                    fixed4 color : COLOR;
                    float2 texcoord  : TEXCOORD0;
                };

                fixed4 _Color;
                float _Cutoff;
                sampler2D _TransitionTex;
                float _Rotation;

                v2f vert(appdata_t IN) {
                    v2f OUT;
                    OUT.vertex = UnityObjectToClipPos(IN.vertex);
                    OUT.texcoord = IN.texcoord;
                    OUT.color = IN.color * _Color;
                    #ifdef PIXELSNAP_ON
                    OUT.vertex = UnityPixelSnap(OUT.vertex);
                    #endif

                    // Apply rotation
                    float2 pivot = float2(0.5, 0.5);
                    float radian = _Rotation * 3.14159 / 180;
                    float2 dir = float2(cos(radian), sin(radian));
                    float2 rotatedUV = float2(dot(dir, IN.texcoord - pivot), dot(float2(-dir.y, dir.x), IN.texcoord - pivot)) + pivot;
                    OUT.texcoord = rotatedUV;

                    return OUT;
                }

                sampler2D _MainTex;
                sampler2D _AlphaTex;
                float _AlphaSplitEnabled;

                fixed4 SampleSpriteTexture(float2 uv) {
                    fixed4 color = tex2D(_MainTex, uv);

                    #if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
                    if (_AlphaSplitEnabled)
                        color.a = tex2D(_AlphaTex, uv).r;
                    #endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

                    return color;
                }

                fixed4 frag(v2f IN) : SV_Target {
                    fixed4 c = SampleSpriteTexture(IN.texcoord) * IN.color;

                    fixed4 transit = tex2D(_TransitionTex, IN.texcoord);
                    if (transit.b > _Cutoff)
                        c.a = 0;

                    return c;
                }
                ENDCG
            }
        }
}
