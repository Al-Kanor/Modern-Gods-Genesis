using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
    public float speed = 1000;
    public float rotationSpeed = 100;
    public float jumpForce = 100000;

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

        // Attaque
        if (Input.GetButtonDown ("Fire1")) {
            GetComponent<Animation> ().Play ();
            transform.GetChild (3).gameObject.SetActive (true);
        }
	}
}
