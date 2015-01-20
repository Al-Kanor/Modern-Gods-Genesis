using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace NAsoft_EasyFlow
{
	public partial class CreateTool : EditorWindow
	{
		private void OnGUI()
		{
			GUISelectMode();
			GUISelectCreateMode();
			GUICreateButton();
		}

		private void GUISelectMode()
		{
			GUILayout.BeginVertical("HelpBox");
			{
				EditorGUILayout.LabelField("Select - EasyFlow Mode", new GUIStyle("BoldLabel"), GUILayout.ExpandWidth(true));
				GUILayout.BeginHorizontal();
				{
					if (GUILayout.Toggle(listMode == LIST_MODE.Line, "Line", "Button", GUILayout.ExpandWidth(true), GUILayout.Height(50.0f)))
						listMode = LIST_MODE.Line;
					
					EditorGUI.BeginDisabledGroup(true);
					{
						if (GUILayout.Toggle(listMode == LIST_MODE.Rectangle, "Rectangle", "Button", GUILayout.ExpandWidth(true), GUILayout.Height(50.0f)))
							listMode = LIST_MODE.Rectangle;
					}
					EditorGUI.EndDisabledGroup();
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.EndVertical();
			GUILayout.Space(5.0f);
		}


		private void GUISelectCreateMode()
		{
			GUILayout.BeginVertical("HelpBox");
			{
				EditorGUILayout.LabelField("Select - EasyFlow Object Type", new GUIStyle("BoldLabel"), GUILayout.ExpandWidth(true));
				
				EditorGUILayout.BeginHorizontal();
				{
#if NGUI_USED
					EditorGUI.BeginDisabledGroup(false);
#else
					EditorGUI.BeginDisabledGroup(true);
#endif
					{
						if (GUILayout.Toggle(coverMode == COVER_MODE.NGUI, "NGUI - UITexture", "Button", GUILayout.ExpandWidth(true), GUILayout.Height(50.0f)))
							coverMode = COVER_MODE.NGUI;
					}
					EditorGUI.EndDisabledGroup();
					
					//if (GUILayout.Toggle(coverMode == COVER_MODE.UGUI, "Unity 4.6 - UI", "Button", GUILayout.ExpandWidth(true), GUILayout.Height(50.0f)))
					//	coverMode = COVER_MODE.UGUI;
					
					if (GUILayout.Toggle(coverMode == COVER_MODE.UnityTexture, "Unity - Texture", "Button", GUILayout.ExpandWidth(true), GUILayout.Height(50.0f)))
						coverMode = COVER_MODE.UnityTexture;
				}
				EditorGUILayout.EndHorizontal();
			}
			GUILayout.EndVertical();
			GUILayout.Space(5.0f);
		}

		private void GUICreateButton()
		{
			EditorGUI.BeginDisabledGroup(coverMode == COVER_MODE.Disabled);
			{
				if (GUILayout.Button(string.Format("Create EasyFlow : {0}", coverMode), "LargeButton", GUILayout.ExpandWidth(true), GUILayout.Height(50.0f)))
					OnCreateBtn(coverMode);
			}
			EditorGUI.EndDisabledGroup();
		}
	}
}