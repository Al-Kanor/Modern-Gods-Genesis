using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MatchUI : MonoBehaviour {
    #region Attributs publics
    public GameObject bricksUI;
    public GameObject goldUI;
    public GameObject orbsUI;
    #endregion

    #region Attributs privés
    #endregion

    #region Singleton
    static MatchUI m_instance;
    static public MatchUI instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }

        DontDestroyOnLoad (this);
    }
    #endregion

    #region Méthodes publiques
    public void UpdateResources () {
        bricksUI.GetComponent<Text> ().text = "" + GameManager.instance.ActivePlayer.Bricks;
        goldUI.GetComponent<Text> ().text = "" + GameManager.instance.ActivePlayer.Gold;
        orbsUI.GetComponent<Text> ().text = "" + GameManager.instance.ActivePlayer.Orbs;
    }
    #endregion

    #region Méthodes privées
    void Start () {
        
    }
    #endregion
}