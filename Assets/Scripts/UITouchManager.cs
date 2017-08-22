using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITouchManager : MonoBehaviour {

    public static bool guiTouch;

    public void TouchInput (GUITexture texture)
    {
       if (Input.GetMouseButtonDown(0))
        {
            if (texture.HitTest (Input.GetTouch(0).position) && texture.tag == "Imagen")
            {
                Debug.Log("Esta Tocando");
                guiTouch = true;            
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
        GenerateMouseRay();
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
