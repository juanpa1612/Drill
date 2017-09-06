using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRuby : MonoBehaviour {
	[SerializeField]GameObject camara;
	SpriteRenderer icon; 
	// Use this for initialization
	void Start () {
		icon = camara.GetComponentInChildren<SpriteRenderer> ();
	}



	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Player")) 
		{
			camara.GetComponent<SmoothCamera2D> ().contadorRuby++;
			camara.GetComponent<SmoothCamera2D> ().contador=camara.GetComponent<SmoothCamera2D> ().contadorRuby;
			icon.sprite = GetComponent<SpriteRenderer> ().sprite;
			Destroy (gameObject);
		}
	}

}
