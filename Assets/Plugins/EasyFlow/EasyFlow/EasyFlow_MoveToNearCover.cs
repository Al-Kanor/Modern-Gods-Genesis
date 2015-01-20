using UnityEngine;
using System.Collections;

namespace NAsoft_EasyFlow
{
	public partial class EasyFlow : MonoBehaviour
	{
		public void MoveToNearCover()
		{
			Vector3 nearPosition = FindNearPosition(flowPosition);
			flowPosition = nearPosition;
			UpdateCover();
		}
		
		private Cover FindNearCover(Vector3 targetPosition)
		{
			Cover nearCover = null;
			float nearDistance = float.MaxValue;
			float gapDistance = 0.0f;
			
			foreach (Cover cover in coverList)
			{
				gapDistance = (cover.GetPosition() - targetPosition).sqrMagnitude;
				if (gapDistance <= nearDistance)
				{
					nearDistance = gapDistance;
					nearCover = cover;
				}
			}

			return nearCover;
		}
		
		private Vector3 FindNearPosition(Vector3 targetPosition)
		{
			Cover nearCover = FindNearCover(targetPosition);
			Vector3 nearPosition = nearCover.position;
			return nearPosition;
		}
	}
}