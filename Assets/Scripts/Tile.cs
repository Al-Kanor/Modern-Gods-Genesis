using UnityEngine;
using System.Collections;

public class Tile {
    #region Attributs privés
    private InfluenceZone influenceZone = new InfluenceZone();
    private GameObject placeable = null;    // Unité ou bâtiment sur la case
    #endregion

    #region Accesseurs
    public InfluenceZone InfluenceZone {
        get { return influenceZone; }
    }

    public GameObject Placeable {
        get { return placeable; }
        set { placeable = value; }
    }
    #endregion
}
