﻿using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
    #region Attributs publics
    public float speed = 10;
    #endregion

    #region Attributs privés
    private float boundX;
    private float boundZ;
    #endregion

    #region Méthodes publiques
    #endregion

    #region Méthodes privées
    void FixedUpdate () {
        #region Déplacement
        float h = 0;
        float v = 0;

        if (Input.mousePosition.x <= 0 && transform.localPosition.x > -boundX) {
            h = -1;
        }
        else if (Input.mousePosition.x >= Screen.width && transform.localPosition.x < boundX) {
            h = 1;
        }

        if (Input.mousePosition.y <= 0 && transform.localPosition.z > -boundZ) {
            v = -1;
        }
        else if (Input.mousePosition.y >= Screen.height && transform.localPosition.z < boundZ) {
            v = 1;
        }

        gameObject.transform.Translate (new Vector3 (h, v, 0) * speed * Time.deltaTime);
        #endregion
    }

    void Start () {
        boundX = 2;
        boundZ = 5;
    }
    #endregion
}
