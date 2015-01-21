using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    // Singleton
    static GameManager m_instance;
    static public GameManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }

        DontDestroyOnLoad (this);
    }

    public void GoToBattle () {

    }

    public void GoToMainMenu () {

    }

    public void GoToPauseMenu () {

    }

    void Start () {
        Screen.showCursor = false;
    }
}
