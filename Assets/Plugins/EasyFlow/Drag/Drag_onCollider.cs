using UnityEngine;
using System.Collections;

namespace NAsoft_EasyFlow
{
	[RequireComponent (typeof(NAsoft_EasyFlow.EasyFlow))]
	public class Drag_onCollider : Drag
	{
		public void Awake()
		{
			easyflow = GetComponent<EasyFlow>();
		}

		public void OnGUI()
		{
			if (Event.current == null)
				return;

			if (easyflow == null ||
			    easyflow.saveData == null ||
			    easyflow.saveData.dragCamera == null ||
			    easyflow.saveData.dragCollider == null)
				return;

			Ray ray = easyflow.saveData.dragCamera.ScreenPointToRay(Event.current.mousePosition);
			RaycastHit hit;
			if (isBeginDrag || easyflow.saveData.dragCollider.Raycast(ray, out hit, float.MaxValue))
			{
				switch (Event.current.type)
				{
				case EventType.MouseDown:	OnMouseDown(Event.current.mousePosition);	break;
				case EventType.MouseDrag:	OnMouseDrag(Event.current.mousePosition);	break;
				case EventType.MouseUp:		OnMouseUp(Event.current.mousePosition);	break;
				}
			}
		}
	}
}