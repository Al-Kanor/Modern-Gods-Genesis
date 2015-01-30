using UnityEngine;
using System.Collections;

public class Tile {
    private int x { get; set; }
    private int y { get; set; }
    //private int width { get; set;  }
    //private int height { get; set; }
    private GameObject unit;    // Unité ou bâtiment sur la case
    
    public GameObject Unit {
        get { return unit; }
        set { unit = value; }
    }

    public Tile (int _x, int _y) {
        x = _x;
        y = _y;
        unit = null;
    }
}
