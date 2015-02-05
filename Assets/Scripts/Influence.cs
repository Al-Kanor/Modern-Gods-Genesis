using UnityEngine;
using System.Collections;

public class Influence : MonoBehaviour {
    #region Attribut privés
    private bool isToP1 = false;
    private bool isToP2 = false;
    #endregion

    #region Méthodes publiques
    public bool IsActive () {
        return isToP1 || isToP2;
    }
    #endregion
}
