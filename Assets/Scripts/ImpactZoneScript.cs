using UnityEngine;
using System.Collections;

public class ImpactZoneScript : MonoBehaviour {
    void OnTriggerEnter (Collider other) {
        GameObject.Destroy (other.gameObject);
    }
}
