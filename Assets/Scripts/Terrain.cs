using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {
    private TileMap tileMap;

    public void MoveUnits () {
        // Traitement d'abord les plus proches du camp ennemi puis de gauche à droite
        for (int y = tileMap.nbLines - 1; y >= 0; --y) {
            for (int x = 0; x < tileMap.nbColumns; ++x) {
                if (null != tileMap.tiles[x, y].Unit && tileMap.tiles[x, y].Unit.GetComponent<Unit>().IsToP1) {
                    tileMap.tiles[x, y].Unit.transform.position += new Vector3 (0, 0, 1);
                    tileMap.tiles[x, y + 1].Unit = tileMap.tiles[x, y].Unit;
                    tileMap.tiles[x, y].Unit = null;
                }
            }
        }
    }

    void OnMouseDown () {
        GameObject unit = GameManager.instance.unitInPlacement;

        if (null != unit) {
            PlaceUnitInTileMap (unit);
            unit.GetComponent<Unit>().IsPlaced = true;
            unit.GetComponent<Unit> ().card.SetActive (true);
            GameManager.instance.unitInPlacement = null;
            Camera.main.GetComponent<Camera> ().orthographic = false;
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
