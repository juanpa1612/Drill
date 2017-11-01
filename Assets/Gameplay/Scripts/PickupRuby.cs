using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupRuby : MonoBehaviour
{
	[SerializeField] 
	ManagerHUD hud;
    [SerializeField]
    private int scorePorGema;
    [SerializeField]
    private Text txtScore1;
    [SerializeField]
    private Text txtScore2;
    [SerializeField]AudioManager manager;

    private void Awake ()
    {
        txtScore1.GetComponent<Animator>().speed = 1;
    }


    void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Player")) 
		{
            manager.CorrerAudioGemas();
			hud.contadorRuby++;
			hud.score += scorePorGema;
           
            
            //Texto 1 disponible
            if (txtScore1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                txtScore1.text = scorePorGema.ToString();
                txtScore1.rectTransform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                txtScore1.GetComponent<Animator>().Play("MaterialScore", 0, 0);
            }
            else
            {
                //Texto 2 disponible
                if (txtScore2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    txtScore2.text = scorePorGema.ToString();
                    txtScore2.rectTransform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                    txtScore2.GetComponent<Animator>().Play("MaterialScore", 0, 0);
                }
            }
            col.GetComponent<Taladro1>().IniciarParticulasPickUP();
            Destroy (gameObject);
            
            
        }
	}

}
