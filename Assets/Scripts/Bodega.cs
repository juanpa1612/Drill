using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bodega : MonoBehaviour {

    private Resources recursos;
    private TouchManager2 tManager;
    private float tmpMetal = 0;

    public Slider slider;
    public Button btnMetal;

    public float buildingTime =30;
    private bool isReady;
    Vector3 sldPosOffset;

	// Use this for initialization
	void Start ()
    {
        gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
        btnMetal.gameObject.SetActive(false);

        recursos = GameObject.FindGameObjectWithTag("GameController").GetComponent<Resources>();
        tManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<TouchManager2>();
	}

    // Update is called once per frame
    void Update()
    {

        if (recursos.Building == true && buildingTime >= 0 && tManager.IsSet == true)
        {
            buildingTime -= 1 * Time.deltaTime;
            slider.gameObject.SetActive(true);
            sldPosOffset = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            slider.transform.position = new Vector3(sldPosOffset.x  ,sldPosOffset.y-10,   0);
        }

        if (buildingTime <= 0 && tmpMetal<=50)
        {
            tmpMetal += 0.25f * Time.deltaTime;
            slider.gameObject.SetActive(false);
            Debug.Log (tmpMetal);
        }
        if (tmpMetal >= 2)
        {
            btnMetal.gameObject.SetActive(true);
            btnMetal.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            btnMetal.image.CrossFadeAlpha(200f,1.5f,false);
        }
        slider.value = buildingTime;
        Debug.Log(buildingTime);
    }

    public void ResourceGathering ()
    {
        recursos.Metal += 50;
        btnMetal.gameObject.SetActive(false);
        tmpMetal = 0;
    }
}
