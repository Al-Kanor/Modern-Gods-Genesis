using UnityEngine;
using UnityEditor;
using System.Collections;

namespace NAsoft_EasyFlow
{
	public class Common : ScriptableObject
	{
		static void OnEnable()
		{
			EditorApplication.projectWindowChanged += UpdateDefineNGUI;
		}
		static void OnDisable()
		{
			EditorApplication.projectWindowChanged -= UpdateDefineNGUI;
		}

		public static void UpdateDefineNGUI()
		{
			BuildTargetGroup currentTarget = EditorUserBuildSettings.selectedBuildTargetGroup;
			string str = PlayerSettings.GetScriptingDefineSymbolsForGroup(currentTarget);
			
			if (IsNGUIImport())
			{
				PlayerSettings.SetScriptingDefineSymbolsForGroup(currentTarget, AppendString(str, "NGUI_USED"));
			}
			else
			{
				str = PlayerSettings.GetScriptingDefineSymbolsForGroup(currentTarget);
				PlayerSettings.SetScriptingDefineSymbolsForGroup(currentTarget, RemoveString(str, "NGUI_USED"));
			}
		}
		
		private static string AppendString(string originStr, string appendStr)
		{
			if (originStr.Length == 0)
				return appendStr;
			else
			{
				if (originStr.Contains(appendStr) == false)
					return string.Format("{0};{1}", originStr, appendStr);
				else
					return originStr;
			}
		}
		
		private static string RemoveString(string originStr, string removeStr)
		{
			if (originStr.Length > 0)
			{
				if (originStr.Contains(removeStr))
				{
					int index = originStr.IndexOf(removeStr);
					return originStr.Remove(index, removeStr.Length);
				}
			}
			return originStr;
		}
		
		private static bool IsNGUIImport()
		{
			// Check files : NGUIHelp.cs, NGUITools.cs
			System.Type type1 = System.Type.GetType("NGUIHelp");
			System.Type type2 = System.Type.GetType("NGUITools");
			return ((type1 != null) || (type2 != null));
		}
	}
}