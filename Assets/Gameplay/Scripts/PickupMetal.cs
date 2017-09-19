using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupMetal : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private int scorePorMetal;
    [SerializeField]
    private Text txtScore1;
    [SerializeField]
    private Text txtScore2;

    private void Awake ()
    {
        txtScore1.GetComponent<Animator>().speed = 0;
    }

    void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Player")) 
		{
            mainCamera.GetComponent<SmoothCamera2D>().contadorMetal++;
            mainCamera.GetComponent<SmoothCamera2D>().score += scorePorMetal;

            //Texto 1 disponible
            if (txtScore1.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                txtScore1.text = scorePorMetal.ToString();
                txtScore1.rectTransform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                txtScore1.GetComponent<Animator>().Play("MaterialScore", 0, 0);
            }
            else
            {
                //Texto 2 disponible
                if (txtScore2.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    txtScore2.text = scorePorMetal.ToString();
                    txtScore2.rectTransform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                    txtScore2.GetComponent<Animator>().Play("MaterialScore", 0, 0);
                }
            }

            Destroy (gameObject);
		}
	}

}
