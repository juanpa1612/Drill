using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tierra : MonoBehaviour {
	Transform playTransform;
	Vector3 pos;
	ManagerHUD hud;
	SmoothCamera2D camara;
    SpriteRenderer sprRenderer;
	void Start(){
		playTransform=GameObject.FindGameObjectWithTag ("Player").transform;
		hud = GameObject.Find("Canvas").GetComponent<ManagerHUD>();
		camara = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<SmoothCamera2D>();
        sprRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.CompareTag("Player"))
        {
            sprRenderer.enabled = false;
			hud.metros++;
		}
    }

	void Update(){
		if(camara.noTerminado){
			if(Vector3.Distance(playTransform.position,transform.position)>20){
				sprRenderer.enabled = true;
			}

			if(transform.position.y-playTransform.position.y>10){
				pos = transform.position;
				pos.y = pos.y - 40;
				transform.position = pos;
			}
		}
	}
}
