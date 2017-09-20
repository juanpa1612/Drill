using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Materiales : MonoBehaviour
{
    [SerializeField]
    private GameObject objMaterial;
    [SerializeField]
    private Sprite sprGemas;
    [SerializeField]
    private Sprite sprMadera;
    [SerializeField]
    private Sprite sprMetal;
    [SerializeField]
    private Sprite sprTierra;
    [SerializeField]
    private GameObject content2;

    private int materialesRecogidos = 3;

	private ManagerHUD hud;

    private int gemasPlayer;

    private int madera;
    private int metal;
    private int tierra;
    private int lava;

    private void Start()
    {
		hud = GameObject.Find("Canvas").GetComponent<ManagerHUD>();

		metal = hud.contadorMetal;
		gemasPlayer = hud.contadorRuby;

        ContarMateriales();
    }

    public void ContarMateriales ()
    {
        objMaterial.GetComponentInChildren<Text>().text = gemasPlayer.ToString();

        if (gemasPlayer >= 1)
        {
            GameObject gemasRecogidas = GameObject.Instantiate(objMaterial, content2.transform,false);
            gemasRecogidas.GetComponentInChildren<Text>().text = gemasPlayer.ToString();
            gemasRecogidas.GetComponent<Image>().sprite = sprGemas;
        }
        if (madera >= 1)
        {
            GameObject maderaRecogida = GameObject.Instantiate(objMaterial,content2.transform,false);
            maderaRecogida.GetComponentInChildren<Text>().text = madera.ToString();
            maderaRecogida.GetComponent<Image>().sprite = sprMadera;
        }
        if (metal >= 1)
        {
            GameObject metalRecogido = GameObject.Instantiate(objMaterial, content2.transform,false);
            metalRecogido.GetComponentInChildren<Text>().text = metal.ToString();
            metalRecogido.GetComponent<Image>().sprite = sprMetal;
        }
        if (tierra >= 1)
        {
            GameObject tierraRecogida = GameObject.Instantiate(objMaterial, content2.transform,false);
            tierraRecogida.GetComponentInChildren<Text>().text = tierra.ToString();
            tierraRecogida.GetComponent<Image>().sprite = sprTierra;
        }

    }

}
