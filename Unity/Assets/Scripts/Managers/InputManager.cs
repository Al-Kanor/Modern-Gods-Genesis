using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    #region Singleton
    static InputManager m_instance;
    static public InputManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }

        DontDestroyOnLoad(this);
    }
    #endregion

    #region Méthodes publiques
    public static Vector3 MouseWorldPosition () {
        Vector3 pos = Input.mousePosition;
        pos.z = 9.5f;
        pos = Camera.main.ScreenToWorldPoint(pos);
        return pos;
    }
    #endregion
}
