using PlayerIOClient;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    #region Enum publics
    public enum ActionEnum {
        BEGIN_OF_MATCH,
        BEGIN_OF_TURN,
        END_OF_TURN,
        MOVE_UNITS,
        THINKING,
        UNIT_IN_PLACEMENT
    };
    #endregion

    #region Attributs publics
    public Placeable placeableInPlacement = null;
    #endregion

    #region Attributs privés
    private ActionEnum action = ActionEnum.BEGIN_OF_MATCH;
    private Player p1;
    private Player p2;
    private bool isP1Turn = true;
    #endregion

    #region Accesseurs
    public ActionEnum Action {
        get { return action; }
        set {
            switch (value) {
                case ActionEnum.BEGIN_OF_TURN:
                    TileMap.instance.LaunchProduction ();
                    MatchUI.instance.UpdateResources ();
                    break;
                case ActionEnum.THINKING:
                    placeableInPlacement = null;
                    Camera.main.GetComponent<Camera> ().orthographic = false;
                    TileMap.instance.DesactivateInfluenceZones ();
                    break;
                case ActionEnum.UNIT_IN_PLACEMENT:
                    Camera.main.GetComponent<Camera> ().orthographic = true;
                    TileMap.instance.ActivateInfluenceZones ();
                    break;
            }

            action = value;
        }
    }

    public Player ActivePlayer {
        get { return isP1Turn ? p1 : p2; }
    }

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
        Action = ActionEnum.MOVE_UNITS;
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
        //Debug.Log (action);
        switch (action) {
            case ActionEnum.BEGIN_OF_MATCH:
                Action = ActionEnum.BEGIN_OF_TURN;
                break;
            case ActionEnum.BEGIN_OF_TURN:
                Action = ActionEnum.THINKING;
                break;
            case ActionEnum.END_OF_TURN:
                Action = ActionEnum.BEGIN_OF_TURN;
                break;
        }
    }

    void Start () {
        // Création des joueurs
        p1 = new Player ();
        p2 = new Player ();
    }
    #endregion
}
