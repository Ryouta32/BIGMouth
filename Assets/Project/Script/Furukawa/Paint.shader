Shader "Video/UnlitShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        [ToggleOff] _Mirror("Mirror", Float) = 0
        [Enum(0deg,0,90deg,1, 180deg,2, 270deg,3)] _RotType("Rotate Type", Float) = 0
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" "Queue" = "Geometry+10" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float _Mirror;
                float _RotType;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    float2 edtuv = TRANSFORM_TEX(v.uv, _MainTex);
                    float tmp;
                    if (_RotType == 0) {}
                    else if (_RotType == 1) { tmp = edtuv.x; edtuv.x = 1 - edtuv.y; edtuv.y = tmp; }
                    else if (_RotType == 2) { edtuv.x = 1 - edtuv.x; edtuv.y = 1 - edtuv.y; }
                    else if (_RotType == 3) { tmp = edtuv.x; edtuv.x = edtuv.y; edtuv.y = 1 - tmp; }
                    if (_Mirror == 1) { edtuv.x = 1 - edtuv.x; }
                    o.uv = edtuv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // sample the texture
                    float4 col = tex2D(_MainTex, i.uv);
                    return col;
                }
                ENDCG
            }
        }
}
