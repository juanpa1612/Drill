using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private int vidaActual;

    void Start()
    {
        //Suscribción al evento
        FindObjectOfType<Taladro1>().PerdioVida += RestarVidaUI;

        vidaActual = 3;
    }

    public void RestarVidaUI()
    {
        vidaActual--;
        slider.value = vidaActual;
    }
}
