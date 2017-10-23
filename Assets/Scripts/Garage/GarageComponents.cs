using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageComponents : MonoBehaviour
{
    [SerializeField]
    Button[] btnItems;
    [SerializeField]
    ManagerTaladro partes;
    [SerializeField]
    Text description;
    [SerializeField]
    GameObject ventanaEquipment;

    string itemActual;
    public string ItemActual
    {
        get
        {
            return itemActual;
        }
    }

    public void CambiarTipoItem (string tipoItem)
    {

    } 
    
    public void Motores ()
    {
        itemActual = "Motor";
        UIManager.Instance.OpenWindow(ventanaEquipment);

        for (int i = 0; i < btnItems.Length; i++)
        {
            btnItems[i].GetComponent<Image>().sprite = partes.motores[i].sprite;
        }
        description.text = "<b>" + partes.motores[0].motorName + "</b>" + "\n" + "\n" + "<size=38>" + partes.motores[0].description + "</size>";
    }
}
