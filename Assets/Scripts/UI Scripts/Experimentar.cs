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

    private Image selectedItem;
    private bool slot1Empty;
    private bool slot2Empty;

    private Animator animAcelerar;

    private void Start()
    {
        slot1Empty = true;
        slot2Empty = true;

        animAcelerar = acelerar.GetComponent<Animator>();
        animAcelerar.SetBool("Active", false);
    }

    public void SeleccionarItem ()
    {
        selectedItem = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        if (slot1Empty)
        {
            slot1.sprite = selectedItem.sprite;
            slot1Empty = false;
        }
        else if (slot1Empty == false & slot2Empty == true)
        {
            slot2.sprite = selectedItem.sprite;
            slot2Empty = false;
        }
    }

    public void Clear ()
    {
        slot1.sprite = null;
        slot1Empty = true;
        slot2.sprite = null;
        slot2Empty = true;
    }

    public void Mix ()
    {
        animAcelerar.SetBool("Active", true);
    }

    public void Terminar ()
    {
        animAcelerar.SetBool("Active", false);
    }

}
