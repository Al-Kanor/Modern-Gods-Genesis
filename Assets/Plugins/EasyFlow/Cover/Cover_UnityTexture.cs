using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NAsoft_EasyFlow
{
	public class Cover_UnityTexture : Cover
	{
		private Vector2 size = Vector2.zero;

		public override void SetTexture(Texture texture)
		{
			renderer.sharedMaterial.mainTexture = texture;
		}
		
		public override void SetSize(Vector2 size)
		{
			this.size = size;
		}
		
		public override void UpdateAlpha(Vector3 flowPosition)
		{
			float alpha = CalcAlpha(flowPosition);
			renderer.sharedMaterial.SetColor("_Color", new Color(1.0f,1.0f,1.0f,alpha));
		}

		public override void UpdateScale(Vector3 flowPosition)
		{
			transform.localScale = CalcScale(flowPosition) * size;
		}

		public override void UpdateDepth(Vector3 flowPosition)
		{
			depth = CalcDepth(flowPosition);
			renderer.sortingOrder = depth;
		}
	}
}