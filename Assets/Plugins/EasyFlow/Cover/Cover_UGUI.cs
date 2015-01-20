using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NAsoft_EasyFlow
{
	public class Cover_UGUI : Cover
	{
		private RawImage m_rawImage;
		private RawImage rawImage
		{
			get
			{
				if (m_rawImage == null)
					m_rawImage = GetComponent<RawImage>();
				return m_rawImage;
			}
			set
			{
				m_rawImage = value;
			}
		}

		public override void SetTexture(Texture texture)
		{
			rawImage.texture = texture;
		}
		
		public override void SetSize(Vector2 size)
		{
			rawImage.rectTransform.sizeDelta = size;
		}
		
		public override void UpdateAlpha(Vector3 flowPosition)
		{
			float alpha = CalcAlpha(flowPosition);
			rawImage.CrossFadeAlpha(alpha, 0.0f, true);
		}
		
		public override void UpdateDepth(Vector3 flowPosition)
		{
			depth = CalcDepth(flowPosition);
			//rawImage.canvas.sortingOrder = depth;
			transform.SetSiblingIndex(depth);
		}
	}
}