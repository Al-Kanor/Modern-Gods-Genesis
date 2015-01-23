using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    //public enum State { };
    public enum Action {
        THINKING,
        UNIT_IN_PLACEMENT
    };

    //public Action action = Action.THINKING;

    public GameObject unitInPlacement = null;

    // Singleton
    static GameManager m_instance;
    static public GameManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }
        
        DontDestroyOnLoad (this);
    }

    public void FixedUpdate () {
        //Debug.Log(action);
    }

    public void GoToBattle () {

    }

    public void GoToMainMenu () {

    }

    public void GoToPauseMenu () {

    }

    void Start () {
        //Screen.showCursor = false;
    }
}
