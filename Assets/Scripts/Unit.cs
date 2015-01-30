using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    #region Attributs publics
    public int strenght = 1;    // Force
    public int moves = 1; // Nombre de cases parcourues par tour ("vitesse" sur la carte)
    public int lifes = 1;   // Points de vie
    public GameObject card;
    #endregion

    #region Attributs privés
    private bool isPlaced = false;
    private bool isToP1;

    // Déplacement
    public float speed = 1f;    // Vitesse de déplacement
    private Vector3 startPos;
    private Vector3 endPos;
    private float startTime;
    private float journeyLength;
    private bool isInMovement = false;
    #endregion

    #region Accesseurs
    public bool IsInMovement {
        get { return isInMovement; }
    }

    public bool IsPlaced {
        get { return isPlaced; }
        set { isPlaced = value; }
    }

    public bool IsToP1 {
        get { return isToP1; }
    }

    public int Moves {
        get { return moves; }
    }
    #endregion

    #region Méthodes publiques
    public void Move () {
        startPos = transform.position;
        endPos = transform.position + Vector3.forward * moves;
        startTime = Time.time;
        journeyLength = Vector3.Distance (startPos, endPos);
        isInMovement = true;
    }
    #endregion

    #region Méthodes privées
    void Clamp () {
        transform.position = new Vector3 (
            Mathf.Round (transform.position.x),
            transform.position.y,
            Mathf.Round (transform.position.z)
        );
    }

    void FixedUpdate () {
        if (isInMovement) {
            float distCovered = (Time.time - startTime) * speed * Time.fixedDeltaTime;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp (startPos, endPos, fracJourney);

            // Clamp
            if (Mathf.Abs (transform.position.z - endPos.z) < 0.1f) {
                transform.position = endPos;
                isInMovement = false;
            }
        }
        else if (!isPlaced) {
            transform.position = InputManager.MouseWorldPosition ();
            Clamp ();
        }
    }

    void Start () {
        isToP1 = GameManager.instance.GetComponent<GameManager> ().IsP1Turn;
    }
    #endregion
}