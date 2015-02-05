using UnityEngine;
using System.Collections;

public class InfluenceZone : MonoBehaviour {
    private Terrain terrain;

    void OnMouseDown () {
        GameObject unit = GameManager.instance.unitInPlacement;

        if (null != unit) {
            terrain.PlaceInTileMap (unit);
        }
    }

    void Start () {
        terrain = GameObject.Find ("Terrain").GetComponent<Terrain> ();
    }
}
