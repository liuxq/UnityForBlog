using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class ColorsGUI: ShaderGUI {

    private static bool bRed = false;
    private static bool bGreen = false;
    private static bool bBlue = false;

	public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
	{
        // render the default gui
        base.OnGUI(materialEditor, properties);

        Material targetMat = materialEditor.target as Material;

        bRed = Array.IndexOf(targetMat.shaderKeywords, "RED") != -1;
        bGreen = Array.IndexOf(targetMat.shaderKeywords, "GREEN") != -1;
        bBlue = Array.IndexOf(targetMat.shaderKeywords, "BLUE") != -1;

        EditorGUI.BeginChangeCheck();

        bRed = EditorGUILayout.Toggle("红", bRed);
        bGreen = EditorGUILayout.Toggle("绿", bGreen);
        bBlue = EditorGUILayout.Toggle("蓝", bBlue);

        if (EditorGUI.EndChangeCheck())
        {
            if (bRed) 
                targetMat.EnableKeyword("RED");
            else
                targetMat.DisableKeyword("RED");
            if (bGreen)
                targetMat.EnableKeyword("GREEN");
            else
                targetMat.DisableKeyword("GREEN");
            if (bBlue)
                targetMat.EnableKeyword("BLUE");
            else
                targetMat.DisableKeyword("BLUE");
        }
	}
}
