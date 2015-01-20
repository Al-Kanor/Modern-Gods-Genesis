using UnityEngine;
using System.Collections;

public class ServerManager : MonoBehaviour {
    // Singleton
    static ServerManager m_instance;
    static public ServerManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }

        DontDestroyOnLoad (this);
    }
}
