using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnNivel : MonoBehaviour {

    public GameObject panelSeleccion;
    private bool clickAfuera;
    static string numNivel ="0";

    public void Hide ()
    {
        if (panelSeleccion.active == true)
        {
            panelSeleccion.GetComponent<Animator>().SetBool("Fade", false);
            Invoke("Desactivar", 1f);
        }
    }

    public void Desactivar ()
    {
        panelSeleccion.SetActive(false);
    }

    public void Seleccion()
    {
        panelSeleccion.SetActive(true);
        panelSeleccion.GetComponent<Animator>().SetBool("Fade", true);
        numNivel = GetComponentInChildren<Text>().text;
        Debug.Log(numNivel);

    }
    
    public void Drill ()
    {
        SceneManager.LoadScene("Nivel"+numNivel);
        Debug.Log(numNivel);
    }

}
