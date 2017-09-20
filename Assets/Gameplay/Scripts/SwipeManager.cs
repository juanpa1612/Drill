using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour {
	float startTime; 
	float endTime;

	Vector3 starPos;
	Vector3 endPos; 

	float SwipeDistance; 
	float SwipeTime;

	public float maxTime; 
	public float minSwipeDist;

	[SerializeField]Taladro1 Jugador;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
							if (Jugador.GetTransformPositionX () == Jugador.GetPosX () && Jugador.GetTransformPositionX () < 3) {
								Jugador.MoverDerecha (); 
							}	
						}
						if (distance.x < 0) {
							if (Jugador.GetTransformPositionX () == Jugador.GetPosX () && Jugador.GetTransformPositionX () > -3) {
								Jugador.MoverIzquierda ();
							}
						}
					}
					if (Mathf.Abs (distance.x) < Mathf.Abs (distance.y)) {
						//Debug.Log ("Vertical Swipe");
						if (distance.y < 0) {
							Jugador.ActivarBoost ();
						}
					}
				}
			}
		}
	}
}
