using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnNivel : MonoBehaviour {

    public GameObject panelSeleccion;

    private MainMenu mainMenu;
    private Animator animSeleccion;

    static string numNivel ="0";


    private void Start()
    {
        mainMenu = GameObject.Find("Canvas").GetComponent<MainMenu>();

        animSeleccion = panelSeleccion.GetComponent<Animator>();
    }

    public void Activar ()
    {
        animSeleccion.SetBool("Active", true);
        mainMenu.AnimPestañaActual = animSeleccion;

        numNivel = GetComponentInChildren<Text>().text;
        Debug.Log(numNivel);
    }

    public void Desactivar ()
    {
        animSeleccion.SetBool("Active", false);
    }
    
    public void Drill ()
    {
        SceneManager.LoadScene("Prototipo");
        Debug.Log(numNivel);
    }

}
