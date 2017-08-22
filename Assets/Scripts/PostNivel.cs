using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostNivel : MonoBehaviour {

    public CanvasGroup seleccion;
    public CanvasGroup panel1;
    public GameObject materiales;
    public GameObject botones;

    private float metros;
    private int score;
    private int monedas;
    private string lastLevel = "Nivel1";

	// Use this for initialization
	void Start ()
    {
        panel1.gameObject.SetActive(false);
        materiales.SetActive(false);
        botones.SetActive(false);

        StartCoroutine(Panel1());
	}
	
    public void NextLevel ()
    {
        SceneManager.LoadScene("Niveles");
    }

    public void RepetirNivel ()
    {
        SceneManager.LoadScene(lastLevel);
    }

    IEnumerator Panel1 ()
    {
        yield return new WaitUntil(() => seleccion.alpha == 1);
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
        yield return new WaitForSeconds(1.5f);
        botones.SetActive(true);
    }
}
