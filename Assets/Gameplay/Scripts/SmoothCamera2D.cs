using UnityEngine;
using UnityEngine.UI;
 using System.Collections;
 
 public class SmoothCamera2D : MonoBehaviour {
	
    public float dampTime = 0.15f;    
    public Transform target;
	public int contador;
	public int contadorRuby;
	public int contadorMetal;
	public int metros;
	public int vidas;
	private Vector3 velocity = Vector3.zero;
	private Camera cam;
	public Text monedas;
	public Text mostrarVidas;
	public Text mostrarMetros;
    public bool noTerminado;

	void Awake()
	{
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
			Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.9f, point.z)); 
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
         }
		monedas.text = contador.ToString();
		mostrarVidas.text = vidas.ToString ();
		mostrarMetros.text = metros.ToString ();
     }
 }