using UnityEngine;
using System.Collections;

public class Placeable : MonoBehaviour {
    #region Attributs publics
    public GameObject card;
    #endregion

    #region Attributs privés
    private bool isToP1;
    #endregion

    #region Accesseurs
    public bool IsToP1 {
        get { return isToP1; }
        set { isToP1 = value; }
    }
    #endregion

    #region Méthodes publiques
    
    #endregion

    #region Méthodes privées
    void Awake () {
        isToP1 = GameManager.instance.GetComponent<GameManager> ().IsP1Turn;
    }
    
    void Clamp () {
        transform.position = new Vector3 (
            Mathf.Round (transform.position.x),
            transform.position.y,
            Mathf.Round (transform.position.z)
        );
    }

     virtual protected void FixedUpdate () {
         if (GameManager.ActionEnum.UNIT_IN_PLACEMENT == GameManager.instance.Action && gameObject == GameManager.instance.unitInPlacement) {
            transform.position = InputManager.MouseWorldPosition ();
            Clamp ();
        }
    }
    #endregion
}
