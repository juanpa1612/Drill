using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Materiales : MonoBehaviour
{
    [SerializeField]
    private GameObject objGemas;
    [SerializeField]
    private Sprite sprMadera;
    [SerializeField]
    private Sprite sprMetal;
    [SerializeField]
    private Sprite sprTierra;
    [SerializeField]
    private GameObject content2;

    private int materialesRecogidos = 3;

    private int gemasPlayer;
    //Estas variables seran privadas, una vez se haga la referencia a las variables del jugador
    public int madera;
    public int metal;
    public int tierra;
    private int lava;

    private void Start()
    {
        ContarMateriales();
        objGemas.GetComponentInChildren<Text>().text = gemasPlayer.ToString();
        //Asignar los valores de las variables, según lo recogido en la partida anterior.
    }

    public void ContarMateriales ()
    {
        if (madera >= 1)
        {
            GameObject maderaRecogida = GameObject.Instantiate(objGemas,content2.transform);
            maderaRecogida.GetComponentInChildren<Text>().text = madera.ToString();
            maderaRecogida.GetComponent<Image>().sprite = sprMadera;
        }
        if (metal >= 1)
        {
            GameObject metalRecogido = GameObject.Instantiate(objGemas, content2.transform);
            metalRecogido.GetComponentInChildren<Text>().text = metal.ToString();
            metalRecogido.GetComponent<Image>().sprite = sprMetal;
        }
        if (tierra >= 1)
        {
            GameObject tierraRecogida = GameObject.Instantiate(objGemas, content2.transform);
            tierraRecogida.GetComponentInChildren<Text>().text = tierra.ToString();
            tierraRecogida.GetComponent<Image>().sprite = sprTierra;
        }

    }

}
