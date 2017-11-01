using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupMaterials : MonoBehaviour
{
	[SerializeField] 
	ManagerHUD hud;

    [SerializeField]
    private int scorePorEmber;
    [SerializeField]
    private int scorePorLithian;

    [SerializeField]
    private Text txtScore1;
    [SerializeField]
    private Text txtScore2;

    [SerializeField] AudioManager manager;

    private int scoreMaterial;

    private void Awake ()
    {
        txtScore1.GetComponent<Animator>().speed = 0;

        //Saber que material es
        if (tag == "Ember")
            scoreMaterial = scorePorEmber;
        if (tag == "Lithian")
            scoreMaterial = scorePorLithian;
    }

    private void ScoreText ()
    {
         int _scoreMaterial = scoreMaterial;
        //Texto 1 disponible
        if (txtScore1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            txtScore1.text = scoreMaterial.ToString();
            txtScore1.rectTransform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            txtScore1.GetComponent<Animator>().Play("MaterialScore", 0, 0);
        }
        else
        {
            //Texto 2 disponible
            if (txtScore2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                txtScore2.text = scoreMaterial.ToString();
                txtScore2.rectTransform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                txtScore2.GetComponent<Animator>().Play("MaterialScore", 0, 0);
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player")) 
		{
            if (tag == "Ember")
                hud.contadorEmber++;
			    hud.score += scorePorEmber;

            if (tag == "Lithian")
                hud.contadorLithian++;
                hud.score += scorePorLithian;          
        }

        ScoreText();
        manager.CorrerAudioMaterialesPowerup();
        other.GetComponent<Taladro1>().IniciarParticulasPickUP();
        Destroy (gameObject);
	}
}
