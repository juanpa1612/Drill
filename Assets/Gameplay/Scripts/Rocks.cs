using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Player")) 
		{
			if (col.gameObject.GetComponent<Taladro1> ().getAcelerando ()) {
				Destroy (gameObject);
			} else {
				col.gameObject.GetComponent<Taladro1> ().quitarVidas ();
				col.gameObject.GetComponent<SpriteRenderer> ().color=Color.red;
				Destroy (gameObject);
			}
		}
	}
}
