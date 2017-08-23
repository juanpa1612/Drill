using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	[SerializeField]GameObject camara;

	// Use this for initialization
	void Start () {
				
	}



	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Player")) 
		{
			camara.GetComponent<SmoothCamera2D> ().contador++;
			Destroy (gameObject);
		}
	}

}
