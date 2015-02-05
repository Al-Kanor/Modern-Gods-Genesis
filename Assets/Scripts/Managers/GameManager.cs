using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    #region Enum publics
    public enum ActionEnum {
        END_OF_TURN,
        MOVE_UNITS,
        THINKING,
        UNIT_IN_PLACEMENT
    };
    #endregion

    #region Attributs publics
    public GameObject unitInPlacement = null;
    #endregion

    #region Attributs privés
    private ActionEnum action = ActionEnum.THINKING;
    private bool isP1Turn = true;
    #endregion

    #region Accesseurs
    public ActionEnum Action {
        get { return action; }
        set {
            switch (value) {
                case ActionEnum.THINKING:
                    unitInPlacement = null;
                    Camera.main.GetComponent<Camera> ().orthographic = false;
                    Terrain.instance.DesactivateInfluenceZones ();
                    break;
                case ActionEnum.UNIT_IN_PLACEMENT:
                    Camera.main.GetComponent<Camera> ().orthographic = true;
                    Terrain.instance.ActivateInfluenceZones ();
                    break;
            }

            action = value;
        }
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
        
    }
    #endregion
}
