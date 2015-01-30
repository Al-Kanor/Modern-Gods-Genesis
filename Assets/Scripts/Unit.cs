using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    public GameObject card;

    private bool isPlaced = false;
    private bool isToP1;

    public bool IsPlaced {
        get { return isPlaced; }
        set { isPlaced = value; }
    }

    public bool IsToP1 {
        get { return isToP1; }
    }

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

    void Start () {
        isToP1 = GameManager.instance.GetComponent<GameManager> ().IsP1Turn;
    }
}