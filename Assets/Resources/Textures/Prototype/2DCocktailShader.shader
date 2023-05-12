Shader "Custom/2DCocktailShader"  {
    Properties{
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
        _LayerTex("Layer Texture", 2D) = "white" {}
        _Cutoff1("Cutoff 1", Range(0, 1)) = 0
        _Cutoff2("Cutoff 2", Range(0, 1)) = 0
        _Cutoff3("Cutoff 3", Range(0, 1)) = 0
        _LayerColor1("Layer Color 1", Color) = (1, 1, 1, 1)
        _LayerColor2("Layer Color 2", Color) = (1, 1, 1, 1)
        _LayerColor3("Layer Color 3", Color) = (1, 1, 1, 1)
        [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
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
                float _Cutoff1;
                float _Cutoff2;
                float _Cutoff3;
                fixed4 _LayerColor1;
                fixed4 _LayerColor2;
                fixed4 _LayerColor3;
                sampler2D _LayerTex;

                v2f vert(appdata_t IN) {
                    v2f OUT;
                    OUT.vertex = UnityObjectToClipPos(IN.vertex);
                    OUT.texcoord = IN.texcoord;
                    OUT.color = IN.color * _Color;
                    #ifdef PIXELSNAP_ON
                    OUT.vertex = UnityPixelSnap(OUT.vertex);
                    #endif

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
                    fixed4 baseColor = SampleSpriteTexture(IN.texcoord);
                    fixed4 layerColor = tex2D(_LayerTex, IN.texcoord);

                    if (layerColor.r <= _Cutoff1) {
                        baseColor.rgb = baseColor.rgb * _LayerColor1.rgb;
                        baseColor.a *= _LayerColor1.a;
                    }
                    else if (layerColor.r > _Cutoff1 && layerColor.r <= _Cutoff2) {
                        baseColor.rgb = baseColor.rgb * _LayerColor2.rgb;
                        baseColor.a *= _LayerColor2.a;
                    }
                    else if (layerColor.r > _Cutoff2 && layerColor.r <= _Cutoff3) {
                        baseColor.rgb = baseColor.rgb * _LayerColor3.rgb;
                        baseColor.a *= _LayerColor3.a;
                    }
                    else {
                        baseColor.a = 0;
                    }

                    return baseColor * IN.color;
                }
                    ENDCG
        }
        }
}
