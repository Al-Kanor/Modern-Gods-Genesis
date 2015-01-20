using UnityEngine;
using System.Collections;

public class MushroomScript : MonoBehaviour {
    public float force = 1000;

    void OnCollisionEnter (Collision other) {
        if (null != other.gameObject.rigidbody) {
            other.gameObject.rigidbody.AddForce (Vector3.up * force);
        }
    }
}
