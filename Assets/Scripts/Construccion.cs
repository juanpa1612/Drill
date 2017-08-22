using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construccion : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = GenerateMouseRay();
            RaycastHit hit;

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit) && (hit.collider.tag == "Slot"))
            {
                Debug.Log("Hit");
            }
        }
    }
    public Ray GenerateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Debug.DrawRay(mousePosN, mousePosF - mousePosN, Color.green);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;
    }
}
