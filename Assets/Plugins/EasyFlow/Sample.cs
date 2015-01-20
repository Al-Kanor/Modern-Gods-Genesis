using UnityEngine;
using System.Collections.Generic;

public class Sample : MonoBehaviour
{
	public List<GameObject> list;

	public void OnButton(int num)
	{
		if(list == null || list.Count <= num)
			return;

		foreach(GameObject obj in list)
			obj.SetActive(false);
		list[num].SetActive(true);
	}
}
