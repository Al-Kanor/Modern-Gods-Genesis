using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    #region Attributs publics
    public GameObject influenceZonePrefab;
    #endregion

    #region Attributs privés
    private Placeable placeable = null;    // Unité ou bâtiment sur la case
    private InfluenceZone influenceZone;
    #endregion

    #region Accesseurs
    public InfluenceZone InfluenceZone {
        get { return influenceZone; }
    }

    public Placeable Placeable {
        get { return placeable; }
        set { placeable = value; }
    }
    #endregion

    #region Méthodes privées
    void Awake () {
        influenceZone = influenceZonePrefab.GetComponent<InfluenceZone> ();
    }

    void Start () {

    }
    #endregion
}
