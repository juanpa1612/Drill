using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemasPlayer : MonoBehaviour {
	[SerializeField] Text txtGemas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		txtGemas.text = PlayerPrefs.GetInt ("Player Gemas").ToString();
	}
}
