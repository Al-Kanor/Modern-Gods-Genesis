using UnityEngine;
using System.Collections;

public class TileMap : MonoBehaviour {
    #region Attributs publics
    public GameObject tilePrefab;
    public GameObject sanctuaryPrefab;
    #endregion

    #region Attributs privés
    private Tile[,] tiles;
    private int nbLines = 10;
    private int nbColumns = 5;
    private int currentUnitX;
    private int currentUnitY;
    #endregion

    #region Accesseurs
    public int NbColumns {
        get { return nbColumns; }
        set { nbColumns = value; }
    }

    public int NbLines {
        get { return nbLines; }
        set { nbLines = value; }
    }
    #endregion

    #region Singleton
    static TileMap m_instance;
    static public TileMap instance { get { return m_instance; } }
    #endregion

    #region Méthodes publiques
    public void ActivateInfluenceZones () {
        ToggleInfluenceZones (true);
    }

    public void DesactivateInfluenceZones () {
        ToggleInfluenceZones (false);
    }
    #endregion

    // Lance la production de tous les bâtiments du joueur actif
    public void LaunchProduction () {
        for (int x = 0; x < nbColumns; ++x) {
            for (int z = 0; z < nbLines; ++z) {
                if (null != tiles[x, z].Placeable && null != tiles[x, z].Placeable.gameObject.GetComponent<Building> () && tiles[x, z].Placeable.IsToP1 == GameManager.instance.IsP1Turn) {
                    Building building = tiles[x, z].Placeable.gameObject.GetComponent<Building> ();
                    GameManager.instance.ActivePlayer.AddResources (building.bricksProduction, building.goldProduction, building.orbsProduction);
                }
            }
        }
    }

    #region Méthodes privées
    void Awake () {
        #region Singleton
        if (null == instance) {
            m_instance = this;
        }
        #endregion

        // Création des tiles
        tiles = new Tile[nbColumns, nbLines];
        for (int x = 0; x < nbColumns; ++x) {
            for (int z = 0; z < nbLines; ++z) {
                tiles[x, z] = ((GameObject)Instantiate (tilePrefab, new Vector3 (x, 0, z), Quaternion.identity)).GetComponent<Tile> ();
                tiles[x, z].name = "Tile" + x + z;
                tiles[x, z].transform.SetParent (transform);
            }
        }
    }

    // Créé toutes les zones d'influence du joueur actif. Si un bâtiment est passé en paramètre,
    // ne créé que les zones d'influence de ce bâtiment
    void CreateInfluenceZones (Building building = null) {
        if (null != building) {
            for (int x = -building.influence; x <= building.influence; ++x) {
                for (int z = -building.influence; z <= building.influence; ++z) {
                    float newX = building.transform.position.x + x;
                    float newZ = building.transform.position.z + z;
                    if ((x != 0 || z != 0) && newX >= 0 && newX < nbColumns && newZ >= 0 && newZ < nbLines) {
                        // Conversion world position => TileMap position
                        int tileMapX = (int)Mathf.Round (newX);
                        int tileMapZ = (int)Mathf.Round (newZ);

                        // Attention : Les zones d'influence peuvent être mises à true mais pas à false ici !
                        // En effet si la case est sous l'influence d'un autre bâtiment ou risque de lui affecter
                        // une mauvaise valeur
                        if (building.GetComponent<Building> ().IsToP1) {
                            tiles[tileMapX, tileMapZ].InfluenceZone.IsToP1 = true;
                        }
                        else {
                            tiles[tileMapX, tileMapZ].InfluenceZone.IsToP2 = true;
                        }

                        /*
                        GameObject influenceZone = (GameObject)Instantiate (
                            tileMap.tiles[tileMapX, tileMapZ].InfluenceZonePrefab, new Vector3 (newX, 0, newZ), Quaternion.identity
                        );*/
                    }
                }
            }
        }
        else {
            // TODO: Créer les zones d'influences de tous les bâtiments du joueur actif
        }
    }

    void FixedUpdate () {
        if (GameManager.ActionEnum.MOVE_UNITS == GameManager.instance.Action) {
            MoveUnits ();
        }
    }

    void MoveUnits () {
        if (null != tiles[currentUnitX, currentUnitY].Placeable && tiles[currentUnitX, currentUnitY].Placeable is Unit) {
            Unit unit = (Unit) tiles[currentUnitX, currentUnitY].Placeable;
            if (unit.IsToP1) {
                Vector3 pos = unit.transform.position;
                int targetX = currentUnitX;
                int targetY = currentUnitY + unit.moves;
                if (targetX >= 0 && targetX < nbColumns && targetY >= 0 && targetY < nbLines && null == tiles[targetX, targetY].Placeable) {
                    unit.Move ();

                    tiles[currentUnitX, currentUnitY + unit.Moves].Placeable = tiles[currentUnitX, currentUnitY].Placeable;
                    tiles[currentUnitX, currentUnitY].Placeable = null;
                }
            }
        }

        currentUnitX++;

        if (currentUnitX >= nbColumns) {
            if (currentUnitY <= 0) {
                GameManager.instance.GetComponent<GameManager> ().Action = GameManager.ActionEnum.END_OF_TURN;
                currentUnitX = 0;
                currentUnitY = nbLines - 1;
            }
            else {
                currentUnitX = 0;
                currentUnitY--;
            }
        }
    }

    // Place l'objet en paramètre dans le TileMap, si forcePlacement vaut false alors l'objet doit être placé sur une zone d'influence
    void Place (Placeable placeable, bool forcePlacement = false) {
        // Conversion world position => TileMap position
        int x = (int)Mathf.Round (placeable.transform.position.x);
        int z = (int)Mathf.Round (placeable.transform.position.z);
        bool isWellPlaced = false;

        if (null == tiles[x, z].Placeable && (tiles[x, z].InfluenceZone.IsToP1 || forcePlacement)) {    // L'emplacement est valide
            tiles[x, z].Placeable = placeable;
            placeable.transform.SetParent (tiles[x, z].transform);
            isWellPlaced = true;
        }

        if (null != placeable.Card) {   // Le placeable a été posé par une carte
            placeable.Card.gameObject.SetActive (true);
        }

        if (!isWellPlaced) {    // Le placeable n'a pas pu être placé
            GameObject.Destroy (placeable.gameObject);
        }

        GameManager.instance.Action = GameManager.ActionEnum.THINKING;
    }

    void OnMouseDown () {
        Placeable placeable = GameManager.instance.placeableInPlacement;

        if (null != placeable) {
            Place (placeable);
        }
    }

    void PlaceInitialSanctuaries () {
        Building sanctuaryP1 = ((GameObject)Instantiate (sanctuaryPrefab.GetComponent<Card> ().placeablePrefab, new Vector3 (2, 0.5f, 0), Quaternion.identity)).GetComponent<Building> ();
        Building sanctuaryP2 = ((GameObject)Instantiate (sanctuaryPrefab.GetComponent<Card> ().placeablePrefab, new Vector3 (2, 0.5f, 9), Quaternion.identity)).GetComponent<Building> ();
        sanctuaryP2.IsToP1 = false;
        Place (sanctuaryP1, true);
        Place (sanctuaryP2, true);
        CreateInfluenceZones (sanctuaryP1);
        CreateInfluenceZones (sanctuaryP2);
    }
    
    void Start () {
        currentUnitX = 0;
        currentUnitY = nbLines - 1;

        PlaceInitialSanctuaries ();
    }

    void ToggleInfluenceZones (bool activate) {
        for (int x = 0; x < nbColumns; ++x) {
            for (int z = 0; z < nbLines; ++z) {
                if (tiles[x, z].InfluenceZone.IsToP1) {
                    tiles[x, z].influenceZonePrefab.GetComponent<MeshRenderer> ().enabled = activate;
                }
            }
        }
    }
    #endregion
}
