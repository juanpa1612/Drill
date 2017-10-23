using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    public GameObject ventanaVender;
    public GameObject contentTaladros;
    public GameObject contentCuerpos;
    public GameObject materiales;

    public GameObject taladros;
    public GameObject cuerpos;

    private MainMenu mainMenu;
    private Animator animVender;
    private Animator animTaladros;
    private Animator animCuerpos;
    private Animator animActual;

    private void Start()
    {
        mainMenu = GameObject.Find("Canvas").GetComponent<MainMenu>();


        animTaladros = taladros.GetComponent<Animator>();
        animCuerpos = cuerpos.GetComponent<Animator>();

        animActual = animTaladros;
        animTaladros.SetBool("Active", true);
    }

    public void MostrarTaladros ()
    {
        if (animActual != animTaladros)
        {
            animActual.SetBool("Active", false);
            animTaladros.SetBool("Active", true);
            animActual = animTaladros;
            materiales.GetComponent<ScrollRect>().content = contentTaladros.GetComponent<RectTransform>();
        }
    }

    public void MostrarCuerpos ()
    {
        if (animActual != animCuerpos)
        {
            animActual.SetBool("Active", false);
            animCuerpos.SetBool("Active", true);
            animActual = animCuerpos;
            materiales.GetComponent<ScrollRect>().content = contentCuerpos.GetComponent<RectTransform>();
        }
    }

    public void VentanaVender ()
    {
        UIManager.Instance.OpenWindow(ventanaVender);
    }



}
