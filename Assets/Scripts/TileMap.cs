using UnityEngine;
using System.Collections;

public class TileMap {
    public Tile[,] tiles;
    public int nbLines;
    public int nbColumns;

    public void PlaceUnit(GameObject unit, int line, int column) {
        tiles[line, column].Unit = unit;
    }

    public TileMap (int _nbColumns, int _nbLines) {
        nbLines = _nbLines;
        nbColumns = _nbColumns;

        tiles = new Tile[nbColumns, nbLines];
        for (int x = 0; x < nbColumns; ++x) {
            for (int y = 0; y < nbLines; ++y) {
                tiles[x, y] = new Tile(0, 0);
            }
        }
    }
}
