using UnityEngine;
using System.Collections;

public class TileMap {
    #region Attributs publics
    public Tile[,] tiles;
    public int nbLines;
    public int nbColumns;
    #endregion

    #region Méthodes publiques
    public void PlacePlaceable(GameObject placeable, int line, int column) {
        tiles[line, column].Placeable = placeable;
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
    #endregion
}
