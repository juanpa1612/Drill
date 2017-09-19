﻿using UnityEngine;
using UnityEngine.UI;
 using System.Collections;
 
 public class SmoothCamera2D : MonoBehaviour {
	
    public float dampTime = 0.15f;    
    public Transform target;
	public int score;
	public int contadorRuby;
	public int contadorMetal;
	public int metros;
	public int vidas;
	private Vector3 velocity = Vector3.zero;
	private Camera cam;
	public Text mostrarMetros;
    public bool noTerminado;
	[SerializeField]private Image[] powerUpGUI;
	public int contadorPowerUp;

	public void limpiarIconoPowerUP(){
		contadorPowerUp = 0;
		foreach(Image i in powerUpGUI){
			i.gameObject.SetActive (false);
		}
	}

	public void PowerUpRecogido(){
		contadorPowerUp++;
		powerUpGUI [contadorPowerUp - 1].gameObject.SetActive (true);
	}

	void Awake()
	{
		limpiarIconoPowerUP ();
        noTerminado = true;
		//contador = PlayerPrefs.GetInt("Player Coins");
		vidas = 3;
		cam = GetComponent<Camera> ();
	}
	void Start () {
	}

	void Update () 
     {
         if (target&&noTerminado)
         {
            Vector3 point = cam.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.832f, point.z)); 
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
         }
		mostrarMetros.text = metros.ToString() + "m";
     }
 }