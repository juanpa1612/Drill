using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup niveles;
    public CanvasGroup taller;
    public CanvasGroup laboratorio;
    public CanvasGroup inventario;

    //Pestañas
    public GameObject ajustes;
    public GameObject gift;
    public GameObject tasks;

    private Animator animActual;

    private Animator animNiveles;
    private Animator animTaller;
    private Animator animLaboratorio;
    private Animator animInventario;

    private Animator animAjustes;
    private Animator animGifts;
    private Animator animTasks;

    private void Start()
    {
		//PlayerPrefs.SetInt ("Player Coins", 0);
        animNiveles = niveles.GetComponent<Animator>();
        animTaller = taller.GetComponent<Animator>();
        animLaboratorio = laboratorio.GetComponent<Animator>();
        animInventario = inventario.GetComponent<Animator>();

        animActual = animNiveles;

        animNiveles.SetBool("Active", true);
        animNiveles.Play("Entry", 0, 0.9f);
    }

    public void Niveles ()
    {
        animActual.SetBool("Active", false);
        UIManager.Instance.CloseWindow();

        animActual = animNiveles;

        animNiveles.SetBool("Active", true);
    }

    public void Taller ()
    {
        animActual.SetBool("Active", false);
        UIManager.Instance.CloseWindow();

        animActual = animTaller;

        animTaller.SetBool("Active",true);
    }

    public void Laboratorio ()
    {
        animActual.SetBool("Active", false);
        UIManager.Instance.CloseWindow();

        animActual = animLaboratorio;

        animLaboratorio.SetBool("Active", true);
    }

    public void Inventario()
    {
        animActual.SetBool("Active", false);
        UIManager.Instance.CloseWindow();

        animActual = animInventario;

        animInventario.SetBool("Active", true);
    }

    public void Ajustes ()
    {
        UIManager.Instance.OpenWindow(ajustes);
    }

    public void Gifts ()
    {
        UIManager.Instance.OpenWindow(gift);
    }

    public void Tasks ()
    {
        UIManager.Instance.OpenWindow(gift);
    }

    public Animator AnimActual
    {
        get
        {
            return animActual;
        }

        set
        {
            animActual = value;
        }
    }

}
