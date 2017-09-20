using UnityEngine;
using UnityEngine.UI;
 using System.Collections;
 
 public class SmoothCamera2D : MonoBehaviour {
	
    public float dampTime = 0.15f;    
    public Transform target;

	private Vector3 velocity = Vector3.zero;
	private Camera cam;
	public bool noTerminado;



	void Awake()
	{
		cam = GetComponent<Camera> ();
		noTerminado = true;
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
     }
 }