using UnityEngine;
using System.Collections;

public class Tile {
    #region Attributs privés
    private int x;
    private int y;
    private Influence influence;
    private GameObject placeable;    // Unité ou bâtiment sur la case
    #endregion

    #region Accesseurs
    public GameObject Placeable {
        get { return placeable; }
        set { placeable = value; }
    }

    public Tile (int _x, int _y) {
        x = _x;
        y = _y;
        placeable = null;
    }
    #endregion
}
