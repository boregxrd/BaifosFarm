Shader "Custom/DegradadoSuelo"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex("Noise Texture", 2D) = "white" {}
        _NoiseForce("Noise Force", Range(0, 500)) = 10
        _NoiseScale("Noise Scale", Vector) = (10, 10, 0, 0)
        _ColorFrom ("Color From", Color) = (1, 0, 1, 1)
        _ColorTo ("Color To", Color) = (1, 1, 0, 1)
        _RadiusMultiplier ("Radius", Range(0, 5)) = 1
        _GradientPivot ("Position", Vector) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        sampler2D _NoiseTex;
        float _NoiseForce;
        float2 _NoiseScale;
        float4 _ColorFrom;
        float4 _ColorTo;
        float _RadiusMultiplier;
        float4 _GradientPivot;

        struct Input
        {
            float2 uv_MainTex;
        };

        float3 getNoise(float2 uv)
        {
            return tex2D(_NoiseTex, uv * _NoiseScale) / _NoiseForce;
        }

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            float2 pixelPoint = IN.uv_MainTex;
            float xDist = pow(pixelPoint.x - _GradientPivot.x, 2);
            float yDist = pow(pixelPoint.y - _GradientPivot.y, 2);
            float dist = sqrt(xDist + yDist) / _RadiusMultiplier;
            dist = clamp(dist, 0, 1);

            fixed4 col = lerp(_ColorFrom, _ColorTo, dist);
            col.rgb += getNoise(IN.uv_MainTex);

            o.Albedo = col.rgb;
            o.Alpha = col.a; // Ensure alpha is 1 for opaque
        }
        ENDCG
    }
    FallBack "Diffuse"
}
