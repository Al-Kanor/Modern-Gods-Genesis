using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
    public float speed = 40000;
    public float rotationSpeed = 150;
    public float jumpForce = 50;

	void Update () {
        // Calcul de la rotation
        float h = Input.GetAxis ("Mouse X");
        Vector3 rotation = new Vector3 (0, h * rotationSpeed * Time.deltaTime, 0);

        // Calcul du déplacement
        float v = Input.GetAxis ("Vertical");
        Vector3 move = transform.forward * v;

        if (Input.GetButtonDown ("Jump")) {
            move.y = jumpForce;
        }

        // Application de la rotation et du déplacement
        transform.Rotate (rotation);
        rigidbody.AddForce (move * speed * Time.deltaTime);

        // Animation
        bool isWalking = false;

        if (Mathf.Abs (v) > 0.01f) {
            isWalking = true;
        }

        GetComponent<Animator> ().SetBool ("Walk", isWalking);

        // Attaque
        if (Input.GetButtonDown ("Fire1")) {
            //GetComponent<Animation> ().Play ();
            
            // Activation de la zone d'impact
            transform.GetChild (3).gameObject.SetActive (true);
        }
	}
}
