Shader "EasyFlow/UnlitAlpha"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Transparency (A)", 2D) = "white" {}
    }

    Category
    {
        ZWrite On
        Cull Off
        SubShader
        {
            Tags { "Queue" = "Transparent" }
            Pass
            {
                Blend SrcAlpha OneMinusSrcAlpha
				Material
				{
					Diffuse [_Color]
				}
                Lighting Off
                SetTexture [_MainTex]
                {
                    constantColor [_Color]
					//combine texture * primary double, texture * primary
                    Combine texture * constant, texture * constant 
                } 
            }
        } 
    }
}