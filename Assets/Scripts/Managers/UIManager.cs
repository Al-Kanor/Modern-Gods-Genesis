using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
    #region Attributs privés
    #endregion

    #region Singleton
    static UIManager m_instance;
    static public UIManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }

        DontDestroyOnLoad (this);
    }
    #endregion
}
