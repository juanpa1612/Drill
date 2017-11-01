using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	[SerializeField] ManagerHUD hud;
    [SerializeField] AudioManager manager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Player")) 
		{
            manager.CorrerAudioMaterialesPowerup();
			hud.PowerUpRecogido ();
			Destroy (gameObject);
		}
	}
}
