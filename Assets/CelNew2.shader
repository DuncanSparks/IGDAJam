 Shader "Custom/Custom Toon" {
     Properties {
             _MainTex ("Texture", 2D) = "white" {}
             _ShadowTreshold ("Shadow Treshold", Float) = 1
         }
         SubShader {
         Tags
         {
         "RenderType" = "Opaque"
         }
         CGPROGRAM
           #pragma surface surf WrapLambert
 
           float _ShadowTreshold;
 
           half4 LightingWrapLambert (SurfaceOutput s, half3 lightDir, half atten) {
               half NdotL = dot (s.Normal, lightDir);
               half diff = NdotL * 0.5 + 0.5;
               half4 c;
               c.rgb = s.Albedo * _LightColor0.rgb * (round(saturate (diff * (atten * _ShadowTreshold))*2)/2);
 //             c.rgb = s.Albedo * _LightColor0.rgb * (diff.atten);
               c.a = s.Alpha;
               return c;
           }
   
         struct Input {
             float2 uv_MainTex;
         };
         
         sampler2D _MainTex;
         
         void surf (Input IN, inout SurfaceOutput o) {
             o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
         }
         ENDCG
         }
         Fallback "Diffuse"
     }
	 