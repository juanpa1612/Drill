using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnGarageItem : MonoBehaviour
{
    [SerializeField]
    Text descripcion;
    [SerializeField]
    ManagerPartesPlayer partesPlayer;
    [SerializeField]
    ManagerTaladro managerTaladro;
    [SerializeField]
    GameObject components;
    [SerializeField]
    GameObject ventanaEquipment;

    [SerializeField]
    int numItem;

    static Motor motorSeleccionado;
    GarageComponents garageComponents;

    public delegate void _ObjetoEquipado();
    public static event _ObjetoEquipado ObjetoEquipado;

    private void Start()
    {
        garageComponents = components.GetComponent<GarageComponents>();
    }

    public void SeleccionarItem ()
    {
        if (garageComponents.ItemActual == "Motor")
        {
            motorSeleccionado = managerTaladro.motores[numItem];
            descripcion.text = "<b>" + motorSeleccionado.motorName + "</b>" + "\n" + "\n" + "<size=38>" + motorSeleccionado.description + "</size>";
        } 
    }
    public void Equipar ()
    {
        if (garageComponents.ItemActual == "Motor")
        {
            partesPlayer.motorPlayer = motorSeleccionado;
        }
        //Implementar Cabeza y demás...
        if (true)
        {

        }

        if (ObjetoEquipado != null)
            ObjetoEquipado();

        UIManager.Instance.CloseWindow(ventanaEquipment);
    }
}
