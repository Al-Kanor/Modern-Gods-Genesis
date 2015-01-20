using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NAsoft_EasyFlow
{
	public partial class EasyFlow_UnityTexture : EasyFlow
	{
		protected override void CreateCover()
		{
			GameObject coverPrefab = Resources.Load<GameObject>("Prefab/Prefab_UnityTexture");
			GameObject coverObject = GameObject.Instantiate(coverPrefab) as GameObject;
			coverObject.transform.SetParent(panel);
			coverObject.renderer.sharedMaterial = new Material(Resources.Load<Material>("Prefab/Material_UnityTexture"));
			
			Cover_UnityTexture newCover = coverObject.GetComponent<Cover_UnityTexture>();
			coverList.Add(newCover);
		}

		protected override void InitPanelDepth()
		{
			//panel.SetSiblingIndex((int)saveData.panelDepth);
			//Vector3 pos = panel.localPosition;
			//pos.z = saveData.panelDepth;
			//panel.localPosition = pos;
		}
	}
}