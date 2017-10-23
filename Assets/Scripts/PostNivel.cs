using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PostNivel : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup postNivel;
    [SerializeField]
    private CanvasGroup panel1;
    [SerializeField]
    private GameObject materiales;
    [SerializeField]
    private GameObject botones;
    [SerializeField]
    private GameObject estrellas;
    [SerializeField]
    private Text txtScore;
    [SerializeField]
    private Text txtMetros;

    private Animator animEstrellas;

	private ManagerHUD hud;
    private float metrosRecorridos;
    private float metrosTotales;
    private float score;
    private int gemas;
    private int materialesObtenidos;
    private int vidasPlayer;

    private string lastLevel = "Prototipo";

    private void Awake()
    {
        animEstrellas = estrellas.GetComponent<Animator>();
    }

    IEnumerator Start()
    {
		hud = GameObject.Find("Canvas").GetComponent<ManagerHUD>();
		metrosRecorridos = hud.metros;
        metrosTotales = 80;

		vidasPlayer = hud.vidas;
		gemas = hud.contadorRuby;

        panel1.gameObject.SetActive(false);
        materiales.SetActive(false);
        botones.SetActive(false);

        StartCoroutine(Panel1());

        txtMetros.text = metrosRecorridos.ToString()+"m";
        Score(); 
        yield return 0;
        ComprobarEstrellas();
	}

    private void Score ()
    {
        score = metrosRecorridos + gemas;
        txtScore.text = score.ToString();
    }

    private void ComprobarEstrellas()
    {
        //1 Estrella
        if (metrosRecorridos <= (metrosTotales/2))
        {
            animEstrellas.SetInteger("Estrellas",1);
        }
        //2 Estrellas
        else if (metrosRecorridos >= (metrosTotales / 2) & vidasPlayer != 3)
        {
            animEstrellas.SetInteger("Estrellas", 2);
        }
        //3 Estrellas
        else if (metrosRecorridos >= metrosTotales & vidasPlayer == 3)
        {
            animEstrellas.SetInteger("Estrellas", 3);
        }
    }

    public void NextLevel ()
    {
        SceneManager.LoadScene("Main");
    }

    public void RepetirNivel ()
    {
        SceneManager.LoadScene(lastLevel);
    }

    IEnumerator Panel1 ()
    {
        yield return new WaitUntil(() => postNivel.alpha == 1);
        panel1.gameObject.SetActive(true);
        StartCoroutine(Materiales());
    }

    IEnumerator Materiales()
    {
        yield return new WaitUntil(() => panel1.GetComponent<RectTransform>().anchoredPosition.y >= 15);
        materiales.SetActive(true);
        yield return new WaitUntil(() => materiales.GetComponent<CanvasGroup>().alpha == 1);
        materiales.GetComponent<Animator>().SetBool("Entry", true);
        StartCoroutine(Botones());
    }

    IEnumerator Botones ()
    {
        yield return new WaitForSeconds(0.5f);
        botones.SetActive(true);
    }
}
