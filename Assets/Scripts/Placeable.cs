using UnityEngine;
using System.Collections;

public class Placeable : MonoBehaviour {
    #region Attributs privés
    private bool isPlaced = false;
    private bool isToP1;
    #endregion

    #region Accesseurs
    public bool IsPlaced {
        get { return isPlaced; }
        set { isPlaced = value; }
    }

    public bool IsToP1 {
        get { return isToP1; }
    }
    #endregion

    #region Méthodes publiques
    
    #endregion

    #region Méthodes privées
    void Clamp () {
        transform.position = new Vector3 (
            Mathf.Round (transform.position.x),
            transform.position.y,
            Mathf.Round (transform.position.z)
        );
    }

     virtual protected void FixedUpdate () {
        if (!isPlaced) {
            transform.position = InputManager.MouseWorldPosition ();
            Clamp ();
        }
    }

    void Start () {
        isToP1 = GameManager.instance.GetComponent<GameManager> ().IsP1Turn;
    }
    #endregion
}
