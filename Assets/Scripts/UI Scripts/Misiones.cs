using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misiones : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup pasar;

    private Animator animPasar;

    private void Start()
    {
        animPasar = pasar.GetComponent<Animator>();
        animPasar.SetBool("Active", false);
        animPasar.Play("SizeOut", 0, 1);
    }

    public void MostrarVentana ()
    {
        animPasar.SetBool("Active", true);
    }

    public void EsconderVentana ()
    {
        animPasar.SetBool("Active", false);
    }

    public void Pasar ()
    {
        animPasar.SetBool("Active", false);
        //Codigo para dar recompensas por mision y restar Gemas
    }
}
