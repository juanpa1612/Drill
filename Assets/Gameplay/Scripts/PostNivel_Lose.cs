using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PostNivel_Lose : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup postNivelLose;
    [SerializeField]
    private CanvasGroup panel1;
    [SerializeField]
    private GameObject botones;
    [SerializeField]
    private Text txtMetros;

    private float metrosRecorridos;
    private ManagerHUD hud;
    private string lastLevel = "Prototipo";
    

    IEnumerator Start()
    {
        hud = GameObject.Find("Canvas").GetComponent<ManagerHUD>();
        metrosRecorridos = hud.metros;
        panel1.gameObject.SetActive(false);
        botones.SetActive(false);

        StartCoroutine(Panel1());

        txtMetros.text = metrosRecorridos.ToString() + "m";
        yield return 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void RepetirNivel()
    {
        SceneManager.LoadScene(lastLevel);
    }

    IEnumerator Panel1()
    {
        yield return new WaitUntil(() => postNivelLose.alpha == 1);
        StartCoroutine(Botones());
        panel1.gameObject.SetActive(true);
    }
    IEnumerator Botones()
    {
        yield return new WaitForSeconds(0.5f);
        botones.SetActive(true);
    }
}
