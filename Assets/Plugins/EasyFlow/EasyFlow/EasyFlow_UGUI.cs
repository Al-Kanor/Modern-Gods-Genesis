using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace NAsoft_EasyFlow
{
	[RequireComponent (typeof(RectTransform))]
	public partial class EasyFlow_UGUI : EasyFlow
	{
		protected override void CreateCover()
		{
			GameObject coverObject = new GameObject();
			coverObject.transform.SetParent(panel);
			
			coverObject.AddComponent<RectTransform>();
			
			Canvas canvas = coverObject.AddComponent<Canvas>();
			canvas.overrideSorting = false;/////true;
			
			coverObject.AddComponent<CanvasRenderer>();
			coverObject.AddComponent<RawImage>();
			
			Cover_UGUI newCover = coverObject.AddComponent<Cover_UGUI>();
			coverList.Add(newCover);
		}

		protected override void InitPanelDepth()
		{
			Canvas canvas = panel.GetComponent<Canvas>();
			canvas.sortingOrder = (int)saveData.panelDepth;
		}
	}
}