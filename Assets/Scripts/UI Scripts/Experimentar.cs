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
    float tiempoMaterial1;
    float tiempoMaterial2;

    string material1;
    string material2;

    Button[] botonesMateriales;

    Image selectedItem;
    bool slot1Empty;
    bool slot2Empty;

    Animator animAcelerar;

    bool desactivados;
    [SerializeField]
    bool materialesEstanActivados  = true;

    public string getMaterial1()
    {
        return material1;
    }

    public string getMaterial2()
    {
        return material2;
    }

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
        if (materialesEstanActivados)
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
                gameObject.GetComponent<Blueprints>().ComprobarMaterial(material1, material2);
            }
        }
    }

    public void asignarMaterialSlot(Sprite slotspr, int numeroSlot)
    {
        if (slotspr.name == "Ember")
        {
            if (PlayerPrefs.GetInt("Player Ember") > 0 )
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
            if (PlayerPrefs.GetInt("Player Lithian") > 0)
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
        GetComponent<Blueprints>().Clear();
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
        //Restar Zynux
        tiempoInvestigacion = 0.5f;
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
        materialesEstanActivados = false;
    }

    public void DesactivarBotones()
    {
        for (int i = 0; i < botonesMateriales.Length; i++)
        {
            botonesMateriales[i].interactable = false;
        }
        materialesEstanActivados = false;
    }

    public void ReactivarBotones()
    {
        for (int i = 0; i < botonesMateriales.Length; i++)
        {
            botonesMateriales[i].interactable = true;
        }
        materialesEstanActivados = true;
    }

    public void Update()
    {

        //Slider
        sliderInvestigacion.value = tiempoInvestigacion;
        if (tiempoInvestigacion > 0)
        {
            tiempoInvestigacion -= Time.deltaTime;
        }
        if (tiempoInvestigacion >0 && tiempoInvestigacion <=1)
        {
            GetComponent<Blueprints>().ActivarItem(material1, material2);
            animAcelerar.SetBool("Active", false);
        }

        cantidadLithian.text = "x" + PlayerPrefs.GetInt("Player Lithian");
        cantidadEmber.text = "x" + PlayerPrefs.GetInt("Player Ember");

        if (slot1.sprite != null && slot2.sprite != null)
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
