using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
	[SerializeField] GameObject Camara;
	[SerializeField] bool Derecha;
	bool movin;
	Vector3 posOriginal;

	void Start(){
		posOriginal = transform.position;
		movin = true;
	}

	void Update(){
		if(Derecha){
			MoveRight();
		}
		else{
			MoveLeft ();
		}
	}

	void MoveRight(){
		if (movin) {
			if (transform.position.x < (posOriginal.x + 4)) {
				transform.position += transform.right * Time.deltaTime * 5;
			} else {
				movin = false;
			}
		} else {
			if (transform.position.x > posOriginal.x) {
				transform.position -= transform.right * Time.deltaTime * 5;			
			} else {
				movin = true;
			}
		}

	}

	void MoveLeft(){
		if (movin) {
			if (transform.position.x > (posOriginal.x - 4)) {
				transform.position -= transform.right * Time.deltaTime * 6;
			} else {
				movin = false;
			}
		} else {
			if (transform.position.x < posOriginal.x) {
				transform.position += transform.right * Time.deltaTime * 6;			
			} else {
				movin = true;
			}
		}
	}

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Player")) 
		{
			if (col.gameObject.GetComponent<Taladro1> ().getAcelerando ()) {
				Destroy (gameObject);
				Camara.GetComponent<SmoothCamera2D> ().score++;

			} else {
				col.gameObject.GetComponent<Taladro1> ().quitarVidas ();
				col.gameObject.GetComponent<SpriteRenderer> ().color=Color.red;
				Destroy (gameObject);
			}
		}
	}
}
