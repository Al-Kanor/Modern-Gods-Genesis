using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {
    #region Attributs publics
    public GameObject SanctuaryPrefab;
    public GameObject InfluenceZonePrefab;
    #endregion

    #region Attributs privés
    private TileMap tileMap;
    private int currentUnitX;
    private int currentUnitY;
    #endregion

    #region Méthodes publiques
    public void ActivateInfluenceZones () {
        ToggleInfluenceZones ();
    }
    
    public void DesactivateInfluenceZones () {
        ToggleInfluenceZones (false);
    }

    public void MoveUnits () {
        if (null != tileMap.tiles[currentUnitX, currentUnitY].Placeable && null != tileMap.tiles[currentUnitX, currentUnitY].Placeable.GetComponent<Unit> ()) {
            Unit unit = tileMap.tiles[currentUnitX, currentUnitY].Placeable.GetComponent<Unit> ();
            if (unit.IsToP1) {
                Vector3 pos = unit.transform.position;
                int targetX = currentUnitX;
                int targetY = currentUnitY + unit.moves;
                if (targetX >= 0 && targetX < tileMap.nbColumns && targetY >= 0 && targetY < tileMap.nbLines && null == tileMap.tiles[targetX, targetY].Placeable) {
                    unit.Move ();

                    tileMap.tiles[currentUnitX, currentUnitY + unit.Moves].Placeable = tileMap.tiles[currentUnitX, currentUnitY].Placeable;
                    tileMap.tiles[currentUnitX, currentUnitY].Placeable = null;
                }
            }
        }

        currentUnitX++;

        if (currentUnitX >= tileMap.nbColumns) {
            if (currentUnitY <= 0) {
                GameManager.instance.GetComponent<GameManager> ().action = GameManager.Action.END_OF_TURN;
                currentUnitX = 0;
                currentUnitY = tileMap.nbLines - 1;
            }
            else {
                currentUnitX = 0;
                currentUnitY--;
            }
        }
    }

    // Place l'objet en paramètre dans le TileMap
    public void PlaceInTileMap (GameObject placeable) {
        // Conversion world position => TileMap position
        int x = (int)Mathf.Round (placeable.transform.position.x);
        int y = (int)Mathf.Round (placeable.transform.position.z);  // Attention le y dans le TileMap correpond au z en world
        tileMap.PlacePlaceable (placeable, x, y);
        placeable.GetComponent<Placeable> ().IsPlaced = true;

        if (null != placeable.GetComponent<Unit> ()) {
            placeable.GetComponent<Unit> ().card.SetActive (true);
        }

        GameManager.instance.unitInPlacement = null;
        Camera.main.GetComponent<Camera> ().orthographic = false;
        DesactivateInfluenceZones ();
    }
    #endregion

    #region Méthodes privées
    void CreateInfluenceZones (GameObject building) {
        for (int i = 0; i < building.GetComponent<Building> ().influence; ++i) {
            for (int x = -1; x <= 1; ++x) {
                for (int z = -1; z <= 1; ++z) {
                    if (x != 0 || z != 0) {
                        GameObject influenceZone = (GameObject) Instantiate (
                            InfluenceZonePrefab, building.transform.position + new Vector3 (x, 0, z), Quaternion.identity
                        );
                        influenceZone.transform.SetParent (building.transform.GetChild(0));
                    }
                }
            }
        }
    }

    void Start () {
        // Création du TileMap
        tileMap = new TileMap (5, 10);
        currentUnitX = 0;
        currentUnitY = tileMap.nbLines - 1;

        // Création et placement des sanctuaires
        GameObject sanctuaryP1 = (GameObject)Instantiate (SanctuaryPrefab, new Vector3 (2, 0.5f, 0), Quaternion.identity);
        GameObject sanctuaryP2 = (GameObject)Instantiate (SanctuaryPrefab, new Vector3 (2, 0.5f, 9), Quaternion.identity);
        PlaceInTileMap (sanctuaryP1);
        PlaceInTileMap (sanctuaryP2);
        CreateInfluenceZones (sanctuaryP1);
        CreateInfluenceZones (sanctuaryP2);
    }

    void ToggleInfluenceZones (bool activate = true) {
        for (int i = 0; i < tileMap.nbColumns; ++i) {
            for (int j = 0; j < tileMap.nbLines; ++j) {
                GameObject placeable = tileMap.tiles[i, j].Placeable;
                if (null != placeable && null != placeable.GetComponent<Building> ()) {
                    tileMap.tiles[i, j].Placeable.transform.GetChild (0).gameObject.SetActive (activate);
                }
            }
        }
    }
    #endregion
}
