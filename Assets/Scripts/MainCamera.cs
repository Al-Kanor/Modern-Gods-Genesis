using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
    public float speed = 10;

    private float boundX;
    private float boundZ;

    /*public float turnSpeed = 10;
    
    private bool isInTurn = false;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private Quaternion incRotation;
    private Vector3 rotation;
    */

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
        
        #region Rotation
        /*if (isInTurn) {
            transform.rotation = Quaternion.Lerp (transform.rotation, endRotation, Time.fixedDeltaTime * turnSpeed);
            
            // Fin de la rotation
            if (Mathf.Abs(transform.rotation.y - endRotation.y) <= 0.0001f) {
                isInTurn = false;
            }
        }*/
        #endregion
    }

    void Start () {
        boundX = 10;
        boundZ = 10;

        /*rotation = new Vector3 (0, 0, 180);
        startRotation = transform.rotation;
        endRotation = transform.rotation;
        incRotation = Quaternion.Euler (rotation);*/
    }

    public void TurnBack () {
        /*endRotation = endRotation * incRotation;
        isInTurn = true;*/
    }
}
