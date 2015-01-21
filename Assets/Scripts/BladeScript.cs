using UnityEngine;
using System.Collections;

public class BladeScript : MonoBehaviour {
    void OnTriggerEnter (Collider other) {
        GameObject.Destroy (other.gameObject);
    }
}
