using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
    public float speed = 1000;

	void Update () {
        if (Input.GetButtonDown ("Jump")) {
            rigidbody.AddForce (Vector3.up * speed * Time.deltaTime);
        }
	}
}
