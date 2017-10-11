using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blueprints : MonoBehaviour
{
    [SerializeField]
    ManagerTaladro managerTaladro;
    [SerializeField]
    Image result;
    [SerializeField]
    GameObject blueprintDisponible;

    public void ComprobarMaterial   (string material1, string material2)
    {
        foreach (Motor item in managerTaladro.motores)
        {
            if ((item.req1 == material1 && item.req2 == material2)|| (item.req1 == material2 && item.req2 == material1))
            {
                result.sprite = item.engineIcon;
            }
        }
    }
    public void ActivarItem (string material1, string material2)
    {
        foreach (Motor item in managerTaladro.motores)
        {
            if ((item.req1 == material1 && item.req2 == material2) || (item.req1 == material2 && item.req2 == material1))
            {
                item.blueprintIsActive = true;
                blueprintDisponible.GetComponent<Animator>().SetBool("Active", true);
                blueprintDisponible.GetComponentInChildren<Text>().text = "You have unlocked " + item.name;
            }
        }
    }
    public void Clear ()
    {
        result.sprite = null;
    }
}
