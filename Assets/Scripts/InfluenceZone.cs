using UnityEngine;
using System.Collections;

public class InfluenceZone : MonoBehaviour {
    #region Attributs privés
    private Terrain terrain;
    #endregion

    #region Méthodes privées
    void OnMouseDown () {
        GameObject unit = GameManager.instance.unitInPlacement;

        if (null != unit) {
            terrain.PlaceInTileMap (unit);
        }
    }

    void Start () {
        terrain = GameObject.Find ("Terrain").GetComponent<Terrain> ();
    }
    #endregion
}
