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
        btnCrearItem.EnCreacion += ActivarBotones;

        botonesMotores = GetComponentsInChildren<Button>();

        botonesMotores[0].GetComponent<Image>().sprite = managerTaladro.motores[0].sprite;
        botonesMotores[1].GetComponent<Image>().sprite = managerTaladro.motores[1].sprite;

        ActivarBotones();
    }

    private void ActivarBotones()
    {
        for (int i = 0; i < botonesMotores.Length; i++)
        {
            if (managerTaladro.motores[i].isCreated)
            {
                botonesMotores[i].interactable = true;
            }
            else
            {
                botonesMotores[i].interactable = false;
            }
        }
    }

}
