using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class motoresTaller : MonoBehaviour
{
    public Button[] botonesMotores;
    [SerializeField]
    ManagerTaladro managerTaladro;

	void Start ()
    {
        botonesMotores = GetComponentsInChildren<Button>();
        //ActivarBotones();
	}
    private void Update()
    {
        //ActivarBotones();
        if (managerTaladro.motores[0].isCreated)
        {
            botonesMotores[0].interactable = true;
        }
        else
        {
            botonesMotores[0].interactable = false;
        }
        if (managerTaladro.motores[1].isCreated)
        {
            botonesMotores[1].interactable = true;
        }
        else
        {
            botonesMotores[1].interactable = false;
        }
    }
    private void ActivarBotones()
    {
        for (int i = 0; i < botonesMotores.Length; i++)
        {
            if (managerTaladro.motores[i].isCreated)
            {
                botonesMotores[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                botonesMotores[i].GetComponent<Button>().interactable = false;
            }
        }
    }

}
