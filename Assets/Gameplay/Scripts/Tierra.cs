using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tierra : MonoBehaviour {
	Transform playTransform;
	Vector3 pos;
	void Start(){
		playTransform=GameObject.FindGameObjectWithTag ("Player").transform;
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.CompareTag("Player"))
        {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
    }

	void Update(){
		if(Vector3.Distance(playTransform.position,transform.position)>20){
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			if(transform.position.y>playTransform.position.y){
				pos = transform.position;
				pos.y = pos.y - 20;
				transform.position = pos;
			}
		}
	}
}
