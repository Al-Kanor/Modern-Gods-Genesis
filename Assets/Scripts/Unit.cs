using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    public bool isPlaced = false;

    void FixedUpdate () {
        if (!isPlaced) {
            transform.position = InputManager.MouseWorldPosition();
        }
    }
}