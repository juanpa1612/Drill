using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laboratorio : MonoBehaviour
{
    [SerializeField]
    private Button btnExperimentar;
    [SerializeField]
    private Button btnFabricar;
    [SerializeField]
    private CanvasGroup experimentar;
    [SerializeField]
    private CanvasGroup fabricar;  

    private Animator animBtnExperimentar;
    private Animator animBtnFabricar;

    private Animator animExperimentar;
    private Animator animFabricar;

	// Use this for initialization
	void Start ()
    {
        animBtnExperimentar = btnExperimentar.GetComponent<Animator>();
        animBtnFabricar = btnFabricar.GetComponent<Animator>();
        animExperimentar = experimentar.GetComponent<Animator>();
        animFabricar = fabricar.GetComponent<Animator>();

        animBtnExperimentar.SetBool("Active", true);
        animBtnFabricar.SetBool("Active", false);

        animFabricar.SetBool("Active", false);
        animExperimentar.SetBool("Active", true);
    }
	
    public void Experimentar ()
    {
        animBtnExperimentar.SetBool("Active", true);
        animBtnFabricar.SetBool("Active", false);

        animFabricar.SetBool("Active", false);
        animExperimentar.SetBool("Active", true);
    }

    public void Fabricar ()
    {
        animBtnExperimentar.SetBool("Active", false);
        animBtnFabricar.SetBool("Active", true);

        animExperimentar.SetBool("Active", false);
        animFabricar.SetBool("Active", true);
    }
}
