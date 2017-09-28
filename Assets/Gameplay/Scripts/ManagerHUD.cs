using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerHUD : MonoBehaviour {
	public int score;
	public int contadorRuby;
	public int contadorEmber;
    public int contadorLithian;
	public int metros;
	public int vidas;
	public Text mostrarMetros;
	[SerializeField]private Image[] powerUpGUI;
	public int contadorPowerUp;

	public void limpiarIconoPowerUP(){
		contadorPowerUp = 0;
		foreach(Image i in powerUpGUI){
			i.gameObject.SetActive (false);
		}
	}

	public void PowerUpRecogido(){
		if(contadorPowerUp<7){
			contadorPowerUp++;
			powerUpGUI [contadorPowerUp - 1].gameObject.SetActive (true);
		}
	}

	// Use this for initialization
	void Awake () {
		limpiarIconoPowerUP ();
		//contador = PlayerPrefs.GetInt("Player Coins");
		vidas = 3;
	}
	
	// Update is called once per frame
	void Update () {
		mostrarMetros.text = metros.ToString() + "m";
	}
}
