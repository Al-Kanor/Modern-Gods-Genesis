using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public enum Action {
        END_OF_TURN,
        MOVE_UNITS,
        THINKING,
        UNIT_IN_PLACEMENT
    };

    public Action action = Action.THINKING;

    public GameObject unitInPlacement = null;

    private bool isP1Turn = true;
    private Terrain terrain;

    public bool IsP1Turn {
        get { return isP1Turn; }
    }

    // Singleton
    static GameManager m_instance;
    static public GameManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }
        
        DontDestroyOnLoad (this);
    }

    public void EndOfTurn () {
        action = Action.MOVE_UNITS;
        //terrain.MoveUnits ();
        //isP1Turn = !isP1Turn;
        //Camera.main.GetComponent<MainCamera> ().TurnBack ();
    }

    void FixedUpdate () {
        if (Action.MOVE_UNITS == action) {
            terrain.MoveUnits ();
        }
    }

    public void GoToBattle () {

    }

    public void GoToMainMenu () {

    }

    public void GoToPauseMenu () {

    }

    void Start () {
        terrain = GameObject.Find ("Terrain").GetComponent<Terrain> ();
    }
}
