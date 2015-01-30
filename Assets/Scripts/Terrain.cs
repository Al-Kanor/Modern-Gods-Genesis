using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {
    private TileMap tileMap;

    // Attributs de déplacement d'unités
    private int currentUnitX;
    private int currentUnitY;

    public void MoveUnits () {        
        if (null != tileMap.tiles[currentUnitX, currentUnitY].Unit) {
            Unit unit = tileMap.tiles[currentUnitX, currentUnitY].Unit.GetComponent<Unit> ();
            if (unit.IsToP1) {
                Vector3 pos = unit.transform.position;
                int targetX = currentUnitX;
                int targetY = currentUnitY + unit.moves;
                if (targetX >= 0 && targetX < tileMap.nbColumns && targetY >= 0 && targetY < tileMap.nbLines && null == tileMap.tiles[targetX, targetY].Unit) {
                    unit.Move ();

                    tileMap.tiles[currentUnitX, currentUnitY + unit.Moves].Unit = tileMap.tiles[currentUnitX, currentUnitY].Unit;
                    tileMap.tiles[currentUnitX, currentUnitY].Unit = null;
                }
            }
        }

        currentUnitX++;
        
        if (currentUnitX >= tileMap.nbColumns) {
            if (currentUnitY <= 0) {
                GameManager.instance.GetComponent<GameManager>().action = GameManager.Action.END_OF_TURN;
                currentUnitX = 0;
                currentUnitY = tileMap.nbLines - 1;
            }
            else {
                currentUnitX = 0;
                currentUnitY--;
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
        currentUnitX = 0;
        currentUnitY = tileMap.nbLines - 1;
    }
}
