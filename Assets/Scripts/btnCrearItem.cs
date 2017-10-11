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
        UIManager.Instance.CloseWindow();
        //Aca se restan los materiales del motor: valor Req1 y valor Req2
    }
}
