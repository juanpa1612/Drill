using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnNivel : MonoBehaviour {

    public GameObject panelSeleccion;

    static string numNivel ="0";

    private void Start()
    {

    }

    public void Activar ()
    {
        UIManager.Instance.OpenWindow(panelSeleccion);

        numNivel = GetComponentInChildren<Text>().text;
    }

    public void Desactivar ()
    {
        UIManager.Instance.CloseWindow();
    }
    
    public void Drill ()
    {
        SceneManager.LoadScene("Prototipo");
    }

}
