using UnityEngine;
using System.Collections;

public class Building : Placeable {
    #region Attributs publics
    public int load = 1;
    public int influence = 1;
    public int bricksProduction = 0;
    public int goldProduction = 0;
    public int orbsProduction = 0;
    #endregion

    #region Attributs privés
    private bool isOverloaded = false;
    #endregion

    #region Méthodes publiques
    public void Product () {

    }
    #endregion
}
