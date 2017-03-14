Shader "Custom/Color" 
{
	SubShader 
	{
    	Pass 
    	{
            Cull Off
            ZWrite Off
			Lighting Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			#pragma shader_feature RED GREEN BLUE
	        //#pragma shader_feature GREEN
	        //#pragma shader_feature BLUE
			//#pragma multi_compile RED GREEN BLUE
			//#pragma multi_compile __ GREEN

			struct v2f 
			{
				fixed4 pos : SV_POSITION;
			};
			
			v2f vert (appdata_base v)
			{
				v2f o;
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				return o;
			}
			
			half4 frag(v2f i) : COLOR
			{
				fixed4 c = fixed4(0,0,0,1);
				#ifdef RED
				c += fixed4(1,0,0,1);
				#endif
				#ifdef GREEN
				c += fixed4(0,1,0,1);
				#endif
				#ifdef BLUE
				c += fixed4(0,0,1,1);
				#endif
				return c;
			}
			ENDCG
		}
	}

	CustomEditor "ColorsGUI"
}