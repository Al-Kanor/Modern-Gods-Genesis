using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	void FixedUpdate () {
        gameObject.GetComponent<Camera> ().orthographic = null != GameManager.instance.unitInPlacement;
	}
}
