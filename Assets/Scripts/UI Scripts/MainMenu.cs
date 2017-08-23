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
    public CanvasGroup ajustes;
    public CanvasGroup gift;
    public CanvasGroup tasks;

    private Animator animActual;
    private Animator animPestañaActual;

    private Animator animNiveles;
    private Animator animTaller;
    private Animator animLaboratorio;
    private Animator animInventario;
    private Animator animAjustes;
    private Animator animGifts;
    private Animator animTasks;

    private void Start()
    {
        animNiveles = niveles.GetComponent<Animator>();
        animTaller = taller.GetComponent<Animator>();
        animLaboratorio = laboratorio.GetComponent<Animator>();
        animInventario = inventario.GetComponent<Animator>();
        animAjustes = ajustes.GetComponent<Animator>();
        animGifts = gift.GetComponent<Animator>();
        animTasks = tasks.GetComponent<Animator>();

        animActual = animNiveles;
        animPestañaActual = animGifts;

        animNiveles.SetBool("Active", true);
    }

    public void Niveles ()
    {
        animActual.SetBool("Active", false);
        animPestañaActual.SetBool("Active", false);

        animActual = animNiveles;

        animNiveles.SetBool("Active", true);
    }

    public void Taller ()
    {
        animActual.SetBool("Active", false);
        animPestañaActual.SetBool("Active", false);

        animActual = animTaller;

        animTaller.SetBool("Active",true);
    }

    public void Laboratorio ()
    {
        animActual.SetBool("Active", false);
        animPestañaActual.SetBool("Active", false);

        animActual = animLaboratorio;

        animLaboratorio.SetBool("Active", true);
    }

    public void Inventario()
    {
        animActual.SetBool("Active", false);
        animPestañaActual.SetBool("Active", false);

        animActual = animInventario;

        animInventario.SetBool("Active", true);
    }

    public void Ajustes ()
    {
        animActual.SetBool("Active", false);
        animPestañaActual.SetBool("Active", false);

        animActual = animAjustes;

        animAjustes.SetBool("Active", true);
    }

    public void Gifts ()
    {
        animGifts.SetBool("Active", true);
        animPestañaActual = animGifts;
    }

    public void Tasks ()
    {
        animTasks.SetBool("Active", true);
        animPestañaActual = animTasks;
    }

    public void ExitPestaña ()
    {
        animPestañaActual.SetBool("Active", false);
    }

}
