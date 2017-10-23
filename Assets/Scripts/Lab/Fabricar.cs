using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fabricar : MonoBehaviour
{
    [SerializeField]
    private GameObject planosTaladros;
    [SerializeField]
    private GameObject planosCuerpos;
    [SerializeField]
    private GameObject acelerar;
    [SerializeField]
    private GameObject planos;
    [SerializeField]
    private GameObject contentTaladros;
    [SerializeField]
    private GameObject contentCuerpos;
    [SerializeField]
    Text txtComponentes;

    private Animator animTaladros;
    private Animator animCuerpos;
    private Animator animActual;
    private Animator animAcelerar;

	void Start ()
    {
        animTaladros = planosTaladros.GetComponent<Animator>();
        animCuerpos = planosCuerpos.GetComponent<Animator>();
        animAcelerar = acelerar.GetComponent<Animator>();

        animActual = animTaladros;

        animTaladros.SetBool("Active", true);
        animCuerpos.SetBool("Active", false);
        animAcelerar.SetBool("Active", false);
	}
	
    public void Taladros ()
    {
        if (animActual != animTaladros)
        {
            animActual.SetBool("Active", false);
            animActual = animTaladros;
            animActual.SetBool("Active", true);
            planos.GetComponent<ScrollRect>().content = contentTaladros.GetComponent<RectTransform>();
            txtComponentes.text = "Heads";
        }
    }

    public void Cuerpos ()
    {
        if (animActual != animCuerpos)
        {
            animActual.SetBool("Active", false);
            animActual = animCuerpos;
            animActual.SetBool("Active", true);
            planos.GetComponent<ScrollRect>().content = contentCuerpos.GetComponent<RectTransform>();
            txtComponentes.text = "Engines";
        }
    }

    public void Crear ()
    {
        animAcelerar.SetBool("Active", true);
    }
}
