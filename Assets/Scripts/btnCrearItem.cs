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
    [SerializeField] ManagerPartesPlayer partesPlayer;

    Button boton;
    private void Start()
    {
        boton = GetComponent<Button>();
    }
    private void Update()
    {
        boton.interactable = motorActual.blueprintIsActive;
    }
    public void Crear ()
    {
        UIManager.Instance.OpenWindow(ventanaCrearItem);
        ventanaCrearItem.GetComponentInChildren<Text>().text = "¿Do you want to spend " + motorActual.valorReq1 + " of " + motorActual.req1
            + " and " + motorActual.valorRequ2 + " of " + motorActual.req2 + "?";
    }
    public void Hagamoslo ()
    {
        if (PlayerPrefs.GetInt("Player " + motorActual.req1)>motorActual.valorReq1&& PlayerPrefs.GetInt("Player " + motorActual.req2) > motorActual.valorRequ2) {
            PlayerPrefs.SetInt("Player " + motorActual.req1, PlayerPrefs.GetInt("Player " + motorActual.req1) - 1);
            PlayerPrefs.SetInt("Player " + motorActual.req2, PlayerPrefs.GetInt("Player " + motorActual.req2) - 1);
            partesPlayer.SetMotorPlayer(motorActual);
            UIManager.Instance.CloseWindow(ventanaCrearItem);
            Debug.Log(partesPlayer.GetMotorPlayer().name);
            //Aca se restan los materiales del motor: valor Req1 y valor Req
        }
    }
}
