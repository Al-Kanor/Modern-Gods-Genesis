using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	void FixedUpdate () {
        transform.Translate (Vector3.forward * 10 * Time.fixedDeltaTime);
	}
}
