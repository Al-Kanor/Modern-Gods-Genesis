using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    public bool isPlaced = false;
    public GameObject card;

    void Clamp () {
        transform.position = new Vector3 (
            Mathf.Round (transform.position.x),
            transform.position.y,
            Mathf.Round (transform.position.z)
        );
    }

    void FixedUpdate () {
        if (!isPlaced) {
            transform.position = InputManager.MouseWorldPosition ();
            Clamp ();
        }
    }
}