﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
	[SerializeField] ManagerHUD hud;
	[SerializeField] bool Derecha;
    [SerializeField] AudioManager manager;
	bool movin;
	Vector3 posOriginal;
    CameraShake camara;

	void Start(){
		posOriginal = transform.position;
		movin = true;
        camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
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
                manager.CorrerAudioRomperRoca();
                Destroy(gameObject);
			} else {
                camara.ShakeCamera(1, 0.03f);
				col.gameObject.GetComponent<Taladro1> ().quitarVidas ();
				col.gameObject.GetComponent<SpriteRenderer> ().color=Color.red;
				Destroy (gameObject);
			}
		}
	}
}
