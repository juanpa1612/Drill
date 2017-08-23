using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taladro : MonoBehaviour {
	Touch toque;

//	void OnCollisionEnter2D (Collision2D col)
//	{
//		if (col.gameObject.tag == "Pickup") 
//		{
//			Debug.Log ("Crash!");
//			contador++;
//			Destroy (col.gameObject);
//		}
//	}
//	void OnTriggerEnter2D (Collider2D col){
//		if (col.tag == "Pickup") 
//		{
//			Debug.Log ("Crash!");
//			contador++;
//			Destroy (col.gameObject);
//		}
//	}
//
	// Update is called once per frame
	void Update () {
		//Debug.Log (transform.rotation.eulerAngles.z);
		mover ();

		if (Input.GetKey (KeyCode.RightArrow)) {
			rotarDerecha ();
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rotarIzquierda ();
		}

		if (Input.touchCount == 1) {
			toque= Input.touches[0];
			if (toque.position.x < (Screen.width / 2)) {
				rotarIzquierda ();
			}
			else if(toque.position.x > (Screen.width/2)){
				rotarDerecha ();
			}
		}

		if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
			corregirRotacion ();
		}
	}
		
	void mover () {
		if (transform.position.x < 7 && transform.position.x > -7) {
			transform.position += -transform.up * Time.deltaTime * 15;
		} else {
			if(transform.position.x > 7){
				transform.position += -transform.right * Time.deltaTime * 2;
			}
			if(transform.position.x < -7){
				transform.position += transform.right * Time.deltaTime * 2;
			}
		}
	}

	void rotarDerecha() {
		if (transform.rotation.eulerAngles.z < 60||transform.rotation.eulerAngles.z > 290) {
			transform.Rotate (new Vector3 (0, 0, 3));
		}
	}

	void rotarIzquierda() {
		if (transform.rotation.eulerAngles.z < 70||transform.rotation.eulerAngles.z > 300) {
			transform.Rotate (new Vector3 (0, 0, -3));
		}
	}

	void corregirRotacion(){
		if (transform.rotation.eulerAngles.z !=0) {
			if (transform.rotation.eulerAngles.z < 70) {
				transform.Rotate (new Vector3 (0, 0, -2));
			}
			if (transform.rotation.eulerAngles.z > 290) {
				transform.Rotate (new Vector3 (0, 0, 2));
			}
		}
	}
}
