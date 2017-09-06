using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tierra : MonoBehaviour {
	Transform playTransform;
	Vector3 pos;
	GameObject camara;
	void Start(){
		playTransform=GameObject.FindGameObjectWithTag ("Player").transform;
		camara = GameObject.FindGameObjectWithTag ("MainCamera");
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.CompareTag("Player"))
        {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			camara.GetComponent<SmoothCamera2D> ().metros++;
		}
    }

	void Update(){
		if(camara.GetComponent<SmoothCamera2D>().noTerminado){
			if(Vector3.Distance(playTransform.position,transform.position)>20){
				gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			}

			if(transform.position.y-playTransform.position.y>10){
				pos = transform.position;
				pos.y = pos.y - 40;
				transform.position = pos;
			}
		}
	}
}
