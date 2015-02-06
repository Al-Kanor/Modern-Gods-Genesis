using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    #region Attributs publics
    public GameObject placeablePrefab;
    #endregion

    #region Méthodes privées
    void OnMouseDown() {
      //  laceablePrefabClone = Instantiate (placeablePrefab, InputManager.MouseWorldPosition(), Quaternion.identity);
        //placeablePrefab.SetActive (true);
//        placeablePrefab.transform.position = InputManager.MouseWorldPosition ();
        //Placeable placeable = placeablePrefab.GetComponent<Placeable> ();
        Placeable placeable = ((GameObject) Instantiate (placeablePrefab, InputManager.MouseWorldPosition (), Quaternion.identity)).GetComponent<Placeable>();
        placeable.gameObject.SetActive (true);
        placeable.Card = this;
        GameManager.instance.placeableInPlacement = placeable;
        GameManager.instance.Action = GameManager.ActionEnum.UNIT_IN_PLACEMENT;
        gameObject.SetActive (false);
    }
    #endregion
}
