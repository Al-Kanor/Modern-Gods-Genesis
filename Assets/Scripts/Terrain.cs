using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {
    void OnMouseDown () {
        /*if (GameManager.Action.UNIT_IN_PLACEMENT == GameManager.instance.action) {
            GameManager.instance.action = GameManager.Action.THINKING;
        }*/

        GameObject unit = GameManager.instance.unitInPlacement;

        if (null != unit) {
            // TODO: Clamp de l'unité

            unit.GetComponent<Unit>().isPlaced = true;
        }
    }
}
