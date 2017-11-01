using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemasPlayer : MonoBehaviour {
	[SerializeField] Text txtGemas;
	void Start ()
    {
		
	}
	
	void Update ()
    {
		txtGemas.text = PlayerPrefs.GetInt ("Player Gemas").ToString();
	}
}
