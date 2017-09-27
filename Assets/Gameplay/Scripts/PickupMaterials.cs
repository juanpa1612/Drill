using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupMaterials : MonoBehaviour
{
	[SerializeField] 
	ManagerHUD hud;

    [SerializeField]
    private int scorePorMetal;
    [SerializeField]
    private int scorePorMadera;

    [SerializeField]
    private Text txtScore1;
    [SerializeField]
    private Text txtScore2;


    private int scoreMaterial;

    private void Awake ()
    {
        txtScore1.GetComponent<Animator>().speed = 0;

        //Saber que material es
        if (tag == "Metal")
            scoreMaterial = scorePorMetal;
        if (tag == "Madera")
            scoreMaterial = scorePorMadera;
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
            if (tag == "Metal")
                hud.contadorMetal++;
			    hud.score += scorePorMetal;

            if (tag == "Madera")
                hud.contadorMadera++;
                hud.score += scorePorMadera;          
        }

        ScoreText();
        Destroy (gameObject);
	}
}
