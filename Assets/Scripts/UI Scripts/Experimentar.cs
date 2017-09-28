using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Experimentar : MonoBehaviour
{
    [SerializeField]
    private Image slot1;
    [SerializeField]
    private Image slot2;
    [SerializeField]
    private CanvasGroup acelerar;
    [SerializeField]
    Text cantidadEmber;
    [SerializeField]
    Text cantidadLithian;
    [SerializeField]
    Slider sliderInvestigacion;

    float tiempoInvestigacion;
    public float tiempoMaterial1;
    public float tiempoMaterial2;

    string material1;
    string material2;

    Button[] botonesMateriales;

    private Image selectedItem;
    private bool slot1Empty;
    private bool slot2Empty;

    private Animator animAcelerar;

    bool desactivados;

    private void Start()
    {

        botonesMateriales = GetComponentsInChildren<Button>();
        slot1Empty = true;
        slot2Empty = true;

        animAcelerar = acelerar.GetComponent<Animator>();
        animAcelerar.SetBool("Active", false);
        desactivados = false;
    }


    public void SeleccionarItem ()
    {
        selectedItem = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
        

        if (slot1Empty)
        {
            slot1.sprite = selectedItem.sprite;
            asignarMaterialSlot(slot1.sprite, 1);
            slot1Empty = false;
        }
        else if (slot1Empty == false & slot2Empty == true)
        {
            slot2.sprite = selectedItem.sprite;
            asignarMaterialSlot(slot2.sprite, 2);
            slot2Empty = false;
        }
    }

    public void asignarMaterialSlot(Sprite slotspr, int numeroSlot)
    {
        if (slotspr.name == "Ember")
        {
            PlayerPrefs.SetInt("Player Ember", PlayerPrefs.GetInt("Player Ember") - 1);
            if (numeroSlot == 1)
            {
                material1 = "Ember";
                tiempoMaterial1 = 5;
            }
            else
            {
                material2 = "Ember";
                tiempoMaterial2 = 5;
            }
        }
        if (slotspr.name == "Lithian")
        {
            PlayerPrefs.SetInt("Player Lithian", PlayerPrefs.GetInt("Player Lithian") - 1);
            if (numeroSlot == 1)
            {
                material1 = "Lithian";
                tiempoMaterial1 = 10;
            }
            else
            {
                material2 = "Lithian";
                tiempoMaterial2 = 10;
            }
        }
    }

    public void Clear ()
    {
        if (slot1.sprite != null)
        {
            if (slot1.sprite.name=="Ember" )
            {
                PlayerPrefs.SetInt("Player Ember", PlayerPrefs.GetInt("Player Ember") + 1);
            }

            if (slot1.sprite.name == "Lithian")
            {
                PlayerPrefs.SetInt("Player Lithian", PlayerPrefs.GetInt("Player Lithian") + 1);
            }
        }
        slot1.sprite = null;
        slot1Empty = true;
        if (slot2.sprite != null)
        {
            if (slot2.sprite.name == "Ember")
            {
                PlayerPrefs.SetInt("Player Ember", PlayerPrefs.GetInt("Player Ember") + 1);
            }

            if (slot2.sprite.name == "Lithian")
            {
                PlayerPrefs.SetInt("Player Lithian", PlayerPrefs.GetInt("Player Lithian") + 1);
            }
        }
        slot2.sprite = null;
        slot2Empty = true;
    }

    public void Mix ()
    {
        DesactivarBotones();
        tiempoInvestigacion = tiempoMaterial1 + tiempoMaterial2;
        sliderInvestigacion.maxValue = tiempoInvestigacion;
        animAcelerar.SetBool("Active", true);
    }

    public void Terminar ()
    {
        animAcelerar.SetBool("Active", false);
    }

    public void DesactivarBotones(string botonMix, string botonClear)
    {
        for (int i = 0; i < botonesMateriales.Length; i++)
        {
            if (botonesMateriales[i].gameObject.name != botonMix && botonesMateriales[i].gameObject.name != botonClear)
            {
                botonesMateriales[i].interactable = false;
            }
        }
    }

    public void DesactivarBotones()
    {
        for (int i = 0; i < botonesMateriales.Length; i++)
        {
            botonesMateriales[i].interactable = false;
        }
    }

    public void ReactivarBotones()
    {
        for (int i = 0; i < botonesMateriales.Length; i++)
        {
            botonesMateriales[i].interactable = true;
        }
    }

    public void Update()
    {

        //Slider
        if (tiempoInvestigacion > 0)
        {
            tiempoInvestigacion -= Time.deltaTime;
        }
        else
        {
            ReactivarBotones();
        }
        sliderInvestigacion.value = tiempoInvestigacion;


        cantidadLithian.text = "x" + PlayerPrefs.GetInt("Player Ember");
        cantidadEmber.text = "x" + PlayerPrefs.GetInt("Player Lithian");
        if (slot1.sprite!=null&&slot2.sprite!=null)
        {
            DesactivarBotones("btnMix","btnClear");
            desactivados = true;
        }
        else if(desactivados)
        {
            ReactivarBotones();
            desactivados = false;
        }

        ComprobarMateriales();
        
    }

    public void ComprobarMateriales ()
    {
        for (int i = 0; i < botonesMateriales.Length; i++)
        {
            if (botonesMateriales[i].gameObject.name == "Ember")
            {
                //Debug.Log(PlayerPrefs.GetInt("Player Ember"));
                if (PlayerPrefs.GetInt("Player Ember") <= 0)
                {
                    botonesMateriales[i].interactable = false;
                }
                else if(PlayerPrefs.GetInt("Player Ember")>0)
                {
                    botonesMateriales[i].interactable = true;
                }
            }
            if (botonesMateriales[i].gameObject.name == "Lithian")
            {
                if (PlayerPrefs.GetInt("Player Lithian") <= 0)
                {
                    botonesMateriales[i].interactable = false;
                }
                else if (PlayerPrefs.GetInt("Player Lithian") > 0)
                {
                    botonesMateriales[i].interactable = true;
                }
            }
        }
       

    }

}
