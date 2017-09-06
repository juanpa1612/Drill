using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Taladro1 : MonoBehaviour {
	Touch toque;
	private float speed = 18f;
	private Vector3 pos;
	[SerializeField]GameObject camara;
	[SerializeField]GameObject canvasPostNivel;
	private Animator animPostNivel;
	private Transform tr;
	private float speedCaida;
	float tiempoAceleracion;
	bool acelerando;
	private int vidas;
	private float flash;
	float tiempoCastigo;
	bool castigo;
	float esperar;
	bool esperar1;
	bool desactivar;


	float startTime; 
	float endTime;

	Vector3 starPos;
	Vector3 endPos; 

	float SwipeDistance; 
	float SwipeTime;

	public float maxTime; 
	public float minSwipeDist;
	ParticleSystem particulas;

	public int GetVidas(){
		return vidas;
	}


	void Start(){
		esperar1 = false;
		particulas = GetComponentInChildren<ParticleSystem> ();
		particulas.Stop();
		speedCaida = 15f;
		pos = transform.position;
		tr = transform;
		tiempoAceleracion = 1f;
		acelerando = false;
		vidas = 3;
		flash = 0.5f;
		tiempoCastigo = 2f;
		castigo = false;
		esperar = 0.2f;

		animPostNivel = canvasPostNivel.GetComponent<Animator> ();
		animPostNivel.SetBool ("Active", false);

		desactivar = false;
	}

	public bool getAcelerando(){
		return acelerando;
	}
	public void quitarVidas(){
		vidas--;
	}
	// Update is called once per frame
	void Update () {
		camara.GetComponent<SmoothCamera2D>().vidas=vidas;
		mover ();
		if (esperar1) {
			esperar -= Time.deltaTime;
		}
		if(esperar<=0&&esperar1){
			esperar1 = false;
			esperar=0.2f;
			speedCaida = 25f;
			acelerando = true;
			particulas.Play();
		}
		if (gameObject.GetComponent<SpriteRenderer> ().color == Color.red) {
			flash -= Time.deltaTime;
		}
		if (flash <= 0) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
			flash = 0.5f;
		}
		if(acelerando){
			tiempoAceleracion -= Time.deltaTime;
		}
		if(tiempoAceleracion<=0){
			speedCaida = 15f;
			tiempoAceleracion = 2f;
			particulas.Stop();
			acelerando = false;
			castigo = true;
		}
		if (castigo) {
			tiempoCastigo -= Time.deltaTime;
		}
		if (tiempoCastigo <= 0) {
			castigo = false;
			tiempoCastigo = 1f;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)&&tr.position.x==pos.x&&tr.position.x<3) {
			pos.x+=4;
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)&&tr.position.x==pos.x&&tr.position.x>-3) {
			pos.x-=4; 
		}
		/*
		if (Input.touchCount == 1) {
			toque= Input.touches[0];
			if (toque.position.x < (Screen.width / 2)&&tr.position.x==pos.x&&tr.position.x>-3&&toque.position.y > (Screen.height / 2)) {
				pos.x-=4;
			}
			else if(toque.position.x > (Screen.width/2)&&tr.position.x==pos.x&&tr.position.x<3&&toque.position.y > (Screen.height / 2)){
				pos.x+=4; 
			}
			else if (toque.position.y < (Screen.height / 2)&&!acelerando){
				speedCaida = 25f;
				acelerando = true;
			}
		}
		*/


		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				startTime = Time.time;
				starPos = touch.position; 
			} else if (touch.phase == TouchPhase.Ended) {
				endTime = Time.time;
				endPos = touch.position;
				SwipeDistance = (endPos - starPos).magnitude;
				SwipeTime = endTime - startTime;
				//Debug.Log ("Paso por aca");
				if (SwipeTime < maxTime && SwipeDistance > minSwipeDist) {
					Vector2 distance = endPos - starPos;
					if (Mathf.Abs (distance.x) > Mathf.Abs (distance.y)) {
						//Debug.Log ("Horizonal Swipe");
						if (distance.x > 0) {
							if(tr.position.x==pos.x&&tr.position.x<3){
								pos.x+=4; 
							}	
						}
						if (distance.x < 0) {
							if (tr.position.x==pos.x&&tr.position.x>-3) {
								pos.x-=4;
							}
						}
					}
					if (Mathf.Abs (distance.x) < Mathf.Abs (distance.y)) {
						//Debug.Log ("Vertical Swipe");
						if (distance.y < 0) {
							if (!acelerando){
								esperar1 = true;
							}
						}
					}
				}
			}
		}
		transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);
		if(vidas<=0){
			//PlayerPrefs.SetInt("Player Coins", camara.GetComponent<SmoothCamera2D>().contador);
			animPostNivel.SetBool ("Active", true);
			desactivar = true;
		}
	}
	void mover () {
		if(!esperar1&&!desactivar){
			transform.position += -transform.up * Time.deltaTime * speedCaida;
			pos += -transform.up * Time.deltaTime * speedCaida;
		}
	}

    private void OnBecameInvisible()
    {
		PlayerPrefs.SetInt("Player Coins", PlayerPrefs.GetInt("Player Coins")+camara.GetComponent<SmoothCamera2D>().contador);
		animPostNivel.SetBool ("Active", true);
		desactivar = true;
    }

}
