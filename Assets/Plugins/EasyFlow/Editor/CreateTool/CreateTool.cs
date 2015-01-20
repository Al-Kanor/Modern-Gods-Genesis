using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

namespace NAsoft_EasyFlow
{
	public enum LIST_MODE
	{
		Line,
		Rectangle,
	}

	public partial class CreateTool : EditorWindow
	{
		static CreateTool window;

		static LIST_MODE listMode;
		static COVER_MODE coverMode;
		
		[MenuItem("Window/Easy Flow/Create Tool &%1", false, 1)]
		public static void OpenWindow()
		{
			window = (CreateTool)EditorWindow.GetWindow(typeof(CreateTool), false, "EF:CreateTool", true);
			window.autoRepaintOnSceneChange = true;
			window.minSize = new Vector2(440.0f, 145.0f);
		}
		
		private void OnEnable()
		{
			Reset();
		}
		private void OnSelectionChange()
		{
			Reset();
		}
		private void OnFocus()
		{
			Reset();
		}
		private void OnLostFocus()
		{
		}
		private void OnDisable()
		{
		}

		private void OnProjectChange()
		{
			Repaint();
		}

		private void Reset()
		{
			Common.UpdateDefineNGUI();

			listMode = LIST_MODE.Line;
			coverMode = COVER_MODE.Disabled;
			
			Repaint();
		}

	}
}