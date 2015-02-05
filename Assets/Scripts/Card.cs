using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    #region Attributs publics
    public GameObject unitPrefab;
    #endregion

    #region Méthodes privées
    void OnMouseDown() {
        GameObject unit = (GameObject) Instantiate(unitPrefab, InputManager.MouseWorldPosition(), Quaternion.identity);
        unit.GetComponent<Unit> ().card = gameObject;
        GameManager.instance.unitInPlacement = unit;
        GameManager.instance.Action = GameManager.ActionEnum.UNIT_IN_PLACEMENT;
        gameObject.SetActive (false);
    }
    #endregion
}
