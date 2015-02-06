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

    #region Singleton
    static Terrain m_instance;
    static public Terrain instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }
    }
    #endregion

    #region Méthodes publiques
    public void ActivateInfluenceZones () {
        ToggleInfluenceZones (true);
    }

    public void DesactivateInfluenceZones () {
        ToggleInfluenceZones (false);
    }
    #endregion

    #region Méthodes privées
    void CreateInfluenceZones (GameObject building) {
        int influence = building.GetComponent<Building> ().influence;
        for (int x = -influence; x <= influence; ++x) {
            for (int z = -influence; z <= influence; ++z) {
                float newX = building.transform.position.x + x;
                float newZ = building.transform.position.z + z;
                if ((x != 0 || z != 0) && newX >= 0 && newX < tileMap.nbColumns && newZ >= 0 && newZ < tileMap.nbLines) {
                    GameObject influenceZone = (GameObject) Instantiate (
                        InfluenceZonePrefab, new Vector3 (newX, 0, newZ), Quaternion.identity
                    );

                    // Conversion world position => TileMap position
                    int tileMapX = (int)Mathf.Round (newX);
                    int tileMapY = (int)Mathf.Round (newZ);  // Attention le y dans le TileMap correpond au z en world
                    tileMap.tiles[tileMapX, tileMapY].InfluenceZone.IsToP1 = building.GetComponent<Building>().IsToP1;
                }
            }
        }
    }

    void FixedUpdate () {
        if (GameManager.ActionEnum.MOVE_UNITS == GameManager.instance.Action) {
            MoveUnits ();
        }
    }

    void MoveUnits () {
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
                GameManager.instance.GetComponent<GameManager> ().Action = GameManager.ActionEnum.END_OF_TURN;
                currentUnitX = 0;
                currentUnitY = tileMap.nbLines - 1;
            }
            else {
                currentUnitX = 0;
                currentUnitY--;
            }
        }
    }

    // Place l'objet en paramètre dans le TileMap, si forcePlacement vaut false alors l'objet doit être placé sur une zone d'influence
    void PlaceInTileMap (GameObject placeable, bool forcePlacement = false) {
        // Conversion world position => TileMap position
        int x = (int)Mathf.Round (placeable.transform.position.x);
        int y = (int)Mathf.Round (placeable.transform.position.z);  // Attention le y dans le TileMap correpond au z en world
        if (null == tileMap.tiles[x, y].Placeable && (tileMap.tiles[x, y].InfluenceZone.IsToP1 || forcePlacement)) {
            tileMap.Place (placeable, x, y);
            placeable.GetComponent<Placeable> ().card.SetActive (true);
        }
        else {
            placeable.GetComponent<Placeable> ().card.SetActive (true);
            GameObject.Destroy (placeable);
        }
        GameManager.instance.Action = GameManager.ActionEnum.THINKING;
    }
    
    void OnMouseDown () {
        GameObject unit = GameManager.instance.unitInPlacement;

        if (null != unit) {
            PlaceInTileMap (unit);
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
        //sanctuaryP1.GetComponent<Building> ().IsToP1 = true;
        sanctuaryP2.GetComponent<Building> ().IsToP1 = false;
        PlaceInTileMap (sanctuaryP1, true);
        PlaceInTileMap (sanctuaryP2, true);
        CreateInfluenceZones (sanctuaryP1);
        CreateInfluenceZones (sanctuaryP2);
    }

    void ToggleInfluenceZones (bool activate) {
        for (int i = 0; i < tileMap.nbColumns; ++i) {
            for (int j = 0; j < tileMap.nbLines; ++j) {
                GameObject placeable = tileMap.tiles[i, j].Placeable;
                if (null != placeable && null != placeable.GetComponent<Building> ()) {
                    //tileMap.tiles[i, j].Placeable.transform.GetChild (0).gameObject.SetActive (activate);
                }
            }
        }
    }
    #endregion
}
