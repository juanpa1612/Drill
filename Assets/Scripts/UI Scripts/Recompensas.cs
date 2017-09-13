using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recompensas : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup recompensasObtenidas;

    private Animator animRecompensasObtenidas;

    private void Start()
    {
        animRecompensasObtenidas = recompensasObtenidas.GetComponent<Animator>();
        animRecompensasObtenidas.Play("SizeOut", 0, 1);
        animRecompensasObtenidas.SetBool("Active", false);
    }

    public void CerrarVentana ()
    {
        animRecompensasObtenidas.SetBool("Active", false);
    }

    public void AbrirCofre ()
    {
        animRecompensasObtenidas.SetBool("Active", true);
        Invoke("CerrarVentana", 4);
    }
}
