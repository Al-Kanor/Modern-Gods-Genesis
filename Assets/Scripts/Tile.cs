using UnityEngine;
using System.Collections;

public class Tile {
    private int x { get; set; }
    private int y { get; set; }
    //private int width { get; set;  }
    //private int height { get; set; }
    private GameObject placeable;    // Unité ou bâtiment sur la case

    public GameObject Placeable {
        get { return placeable; }
        set { placeable = value; }
    }

    public Tile (int _x, int _y) {
        x = _x;
        y = _y;
        placeable = null;
    }
}
