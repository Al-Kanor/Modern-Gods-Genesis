using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {
    private TileMap tileMap;

    void OnMouseDown () {
        /*if (GameManager.Action.UNIT_IN_PLACEMENT == GameManager.instance.action) {
            GameManager.instance.action = GameManager.Action.THINKING;
        }*/

        GameObject unit = GameManager.instance.unitInPlacement;

        if (null != unit) {
            PlaceUnitInTileMap (unit);
            unit.GetComponent<Unit>().isPlaced = true;
            unit.GetComponent<Unit> ().card.SetActive (true);
            GameManager.instance.unitInPlacement = null;
        }
    }

    // Place l'objet en paramètre dans le TileMap
    void PlaceUnitInTileMap (GameObject unit) {
        // Conversion world position => TileMap position
        int x = (int) Mathf.Round (unit.transform.position.x);
        int y = (int) Mathf.Round (unit.transform.position.z);  // Attention le y dans le TileMap correpond au z en world
        tileMap.PlaceUnit (unit, x, y);
    }

    void Start () {
        tileMap = new TileMap(5, 10);
    }
}
