using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    [SerializeField]
    private GameObject bodega = null;

    [SerializeField]
    Text txtMetal;

    private float metal;
    private bool building;
    public GameObject tienda;
    // Use this for initialization
    void Start ()
    {
        Metal = 500;
    }

    // Update is called once per frame
    void Update ()
    {
        txtMetal.text = ("Metal " + Metal.ToString("0"));
	}

    public void Build ()
    {
        bodega.SetActive(true);

        tienda.SetActive(false);

        Building = true;

        Metal -= 150;
    }

    //Permisos
    public bool Building
    {
        get
        {
            return building;
        }

        set
        {
            building = value;
        }
    }

    public float Metal
    {
        get
        {
            return metal;
        }

        set
        {
            metal = value;
        }
    }
}
