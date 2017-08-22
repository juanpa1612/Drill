using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager2 : MonoBehaviour {

    GameObject gObj = null;
    public Plane objPlane;
    public Plane plano;
    private bool isSet;

    Vector3 offset;

    // Use this for initialization
    void Start ()
    {
		
	}
	public Ray GenerateMouseRay ()
    {
            Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
            Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

            Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
            Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

            Debug.DrawRay(mousePosN, mousePosF - mousePosN, Color.green);

            Ray mr = new Ray(mousePosN,mousePosF - mousePosN);
            return mr;
    }
	// Update is called once per frame
	void Update ()
    {
        //Phase 1
        if (Input.GetMouseButtonDown(0)  && IsSet == false)
        {
            Ray mouseRay = GenerateMouseRay();
            RaycastHit hit;

            if (Physics.Raycast(mouseRay.origin,mouseRay.direction, out hit))
            {
                gObj = hit.transform.gameObject;
                objPlane = new Plane(Camera.main.transform.up * -1, gObj.transform.position);

                //Offset
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                objPlane.Raycast(mRay, out rayDistance);
                offset = gObj.transform.position - mRay.GetPoint(rayDistance);

            }
        }
        //Phase 2
        else if (Input.GetMouseButton(0) && gObj)
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay,out rayDistance))
            {
                gObj.transform.position = mRay.GetPoint(rayDistance) + offset;
            }
        }
        //Phase 3
        else if (Input.GetMouseButtonUp(0) && gObj)
        {
            gObj.transform.position = new Vector3(gObj.transform.position.x, 1f, gObj.transform.position.z);
            gObj = null;
            IsSet = true;
        }
    }
    public bool IsSet
    {
        get
        {
            return isSet;
        }

        set
        {
            isSet = value;
        }
    }
}
