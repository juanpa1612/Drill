using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private int vidaActual;
    Taladro1 player;
    bool asignarValores;

    void Start()
    {
        //Suscribción al evento
        FindObjectOfType<Taladro1>().PerdioVida += RestarVidaUI;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Taladro1>();

    }

    public void RestarVidaUI()
    {
        vidaActual--;
        slider.value = vidaActual;
        
    }
    private void Update()
    {
        if (!asignarValores)
        {
            vidaActual = player.GetVidas();
            slider.maxValue = vidaActual;
            slider.value = vidaActual;
            asignarValores = true;
        }
        //Debug.Log(vidaActual);
    }
}
