using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    #region Enum publics
    public enum Action {
        END_OF_TURN,
        MOVE_UNITS,
        THINKING,
        UNIT_IN_PLACEMENT
    };
    #endregion

    #region Attributs publics
    public Action action = Action.THINKING;
    public GameObject unitInPlacement = null;
    #endregion

    #region Attributs privés
    private bool isP1Turn = true;
    private Terrain terrain;
    #endregion

    #region Accesseurs
    public bool IsP1Turn {
        get { return isP1Turn; }
    }
    #endregion

    #region Singleton
    static GameManager m_instance;
    static public GameManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }
        
        DontDestroyOnLoad (this);
    }
    #endregion

    #region Méthodes publiques
    public void EndOfTurn () {
        action = Action.MOVE_UNITS;
        //terrain.MoveUnits ();
        //isP1Turn = !isP1Turn;
        //Camera.main.GetComponent<MainCamera> ().TurnBack ();
    }

    public void GoToBattle () {

    }

    public void GoToMainMenu () {

    }

    public void GoToPauseMenu () {

    }

    #endregion

    #region Méthodes privées
    void FixedUpdate () {
        if (Action.MOVE_UNITS == action) {
            terrain.MoveUnits ();
        }
    }
   
    void Start () {
        terrain = GameObject.Find ("Terrain").GetComponent<Terrain> ();
    }
    #endregion
}
