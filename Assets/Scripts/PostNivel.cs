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

    private float metrosRecorridos;
    private float metrosTotales;
    private float score;
    private int gemas;
    private int materialesObtenidos;
    private int vidasPlayer;

    private string lastLevel = "Prototipo";

	void Start ()
    {
        animEstrellas = estrellas.GetComponent<Animator>();
        /*vidasPlayer = PlayerPrefs.GetInt();*/

        PlayerPrefs.Save ();

        panel1.gameObject.SetActive(false);
        materiales.SetActive(false);
        botones.SetActive(false);

        StartCoroutine(Panel1());

        txtMetros.text = metrosRecorridos.ToString();
        Score();
        /*ComprobarEstrellas();*/
	}

    private void Score ()
    {
        txtScore.text = score.ToString();
        score = metrosRecorridos + gemas + materialesObtenidos;
    }

    private void ComprobarEstrellas()
    {
        //1 Estrella
        if (metrosRecorridos <= (metrosTotales/2))
        {
            animEstrellas.SetInteger("Estrellas",1);
        }
        //2 Estrellas
        else if (metrosRecorridos >= (metrosTotales / 2))
        {
            animEstrellas.SetInteger("Estrellas", 2);
        }
        //3 Estrellas
        else if (metrosRecorridos >= metrosTotales /*&& vidasPlayer == 3*/)
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
