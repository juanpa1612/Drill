using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnCrearItem : MonoBehaviour
{
    [SerializeField]
    Motor motorActual;
    [SerializeField]
    GameObject ventanaCrearItem;
    [SerializeField]
    Button doItButton;
    [SerializeField] ManagerPartesPlayer partesPlayer;

    Button boton;
    public static Motor motorSeleccionado;

    public delegate void _EnCreacion();
    public static event _EnCreacion EnCreacion;

    private void Start()
    {
        boton = GetComponent<Button>();

        Blueprints.BlueprintActivation += ActivarBotones;
        ActivarBotones();
    }

    private void ActivarBotones()
    {
        boton.interactable = motorActual.blueprintIsActive;
    }

    public void Crear ()
    {
        UIManager.Instance.OpenWindow(ventanaCrearItem);

        if (PlayerPrefs.GetInt("Player " + motorActual.req1) >= motorActual.valorReq1 && PlayerPrefs.GetInt("Player " + motorActual.req2) >= motorActual.valorReq2)
        {
            ventanaCrearItem.GetComponentInChildren<Text>().text = "¿Do you want to spend " + motorActual.valorReq1 + " of " + motorActual.req1
            + " and " + motorActual.valorReq2 + " of " + motorActual.req2 + "?";

            doItButton.interactable = true;
            motorSeleccionado = motorActual;
        }
        else
        {
            ventanaCrearItem.GetComponentInChildren<Text>().text = "You don´t have enough materials";
            doItButton.interactable = false;
        }
    }
    public void Hagamoslo ()
    {
        PlayerPrefs.SetInt("Player " + motorSeleccionado.req1, PlayerPrefs.GetInt("Player " + motorSeleccionado.req1) - motorSeleccionado.valorReq1);
        PlayerPrefs.SetInt("Player " + motorSeleccionado.req2, PlayerPrefs.GetInt("Player " + motorSeleccionado.req2) - motorSeleccionado.valorReq2);

        motorSeleccionado.isCreated = true;
        //partesPlayer.motorPlayer = motorSeleccionado;

        UIManager.Instance.CloseWindow(ventanaCrearItem);

        if (EnCreacion != null)
            EnCreacion();
    }
}
