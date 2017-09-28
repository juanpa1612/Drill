using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Taladro1 : MonoBehaviour {
	Touch toque;
	private float speed = 18f;
	private Vector3 pos;
	[SerializeField] ManagerHUD hud;
	[SerializeField]GameObject canvasPostNivel;
    [SerializeField]GameObject canvasMateriales;
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
    bool muerto;

	ParticleSystem particulas;

	bool superCaida;

    //Observer de PerderVida
    public delegate void EstadoVidas ();
    public event EstadoVidas PerdioVida;

	public int GetVidas()
    {
		return vidas;
	}


	void Start()
    {
        muerto = false;
		esperar1 = false;
		particulas = GetComponentInChildren<ParticleSystem> ();
		particulas.Stop();
		speedCaida = 15f;
		pos = transform.position;
		tr = transform;
		tiempoAceleracion = 0.5f;
		acelerando = false;
		vidas = 3;
		flash = 0.5f;
		tiempoCastigo = 2f;
		castigo = false;
		esperar = 0.2f;

		desactivar = false;

		superCaida = false;
	}

	public float GetTransformPositionX(){
		return tr.position.x;
	}

	public float GetPosX(){
		return pos.x;
	}

	public bool getAcelerando(){
		return acelerando;
	}
	public void quitarVidas()
    {
		vidas--;
        //Notifica que perdió vida
        if (PerdioVida != null)
            PerdioVida();
	}
	// Update is called once per frame
	void Update () {
		hud.vidas=vidas;
		moverAbajo ();
		if (esperar1) {
			esperar -= Time.deltaTime;
		}
		if(esperar<=0&&esperar1){
			esperar1 = false;
			esperar=0.2f;
			speedCaida = 25f;
			if (superCaida) {
				tiempoAceleracion = 5f;
				superCaida = false;
			}
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
			tiempoAceleracion = 0.5f;
			particulas.Stop();
			acelerando = false;
			castigo = true;
		}
		if (castigo) {
			tiempoCastigo -= Time.deltaTime;
		}
		if (tiempoCastigo <= 0) {
			castigo = false;
			tiempoCastigo = 2f;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)&&tr.position.x==pos.x&&tr.position.x<3) {
			if(!desactivar){
				pos.x+=4;
			}
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)&&tr.position.x==pos.x&&tr.position.x>-3) {
			if(!desactivar){
				pos.x-=4;
			}
		}

		if(hud.contadorPowerUp>=7){
			esperar1 = true;
			superCaida = true;
			hud.limpiarIconoPowerUP ();
		}
			
		transform.position = Vector3.MoveTowards (transform.position, pos, Time.deltaTime * speed);
		if(vidas<=0){
            //PlayerPrefs.SetInt("Player Coins", camara.GetComponent<SmoothCamera2D>().contador);
            muerto = true;
            canvasPostNivel.SetActive(true);
            desactivar = true;
		}
	}
	void moverAbajo () {
		if(!esperar1&&!desactivar){
			transform.position += -transform.up * Time.deltaTime * speedCaida;
			pos += -transform.up * Time.deltaTime * speedCaida;
		}
	}

	public void MoverDerecha(){
		if (!desactivar) {
			pos.x += 4; 
		}
	}

	public void MoverIzquierda(){
		if(!desactivar){
			pos.x-=4;
		}
	}

	public void ActivarBoost(){
		if (!acelerando&&!castigo&&!desactivar){
			esperar1 = true;
		}
	}

    private void OnBecameInvisible()
    {
        if (!muerto) {
            PlayerPrefs.SetInt("Player Gemas", PlayerPrefs.GetInt("Player Gemas") + hud.contadorRuby);
            PlayerPrefs.SetInt("Player Ember", PlayerPrefs.GetInt("Player Ember") + hud.contadorEmber);
            PlayerPrefs.SetInt("Player Lithian", PlayerPrefs.GetInt("Player Lithian") + hud.contadorLithian);
        }
        if (canvasPostNivel != null)
        {
            canvasPostNivel.SetActive(true);
        }

        desactivar = true;
    }

}
