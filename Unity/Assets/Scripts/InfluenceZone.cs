using UnityEngine;
using System.Collections;

public class InfluenceZone : MonoBehaviour {
    #region Attribut privés
    private bool isToP1 = false;
    private bool isToP2 = false;
    #endregion

    #region Accesseurs
    public bool IsToP1 {
        get { return isToP1; }
        set { isToP1 = value; }
    }

    public bool IsToP2 {
        get { return isToP2; }
        set { isToP2 = value; }
    }
    #endregion

    #region Méthodes publiques
    public bool IsActive () {
        return isToP1 || isToP2;
    }
    #endregion
}
