﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Taller : MonoBehaviour
{
    public GameObject equipacion;
    public CanvasGroup lab;

    private Animator animEquipacion;
    private Animator animTaller;
    private Animator animLab;

    private Button btnActual;
    private MainMenu mainMenu;

    public ColorBlock coloresBtn;

    private void Start()
    {
        animTaller = gameObject.GetComponent<Animator>();
        animLab = lab.GetComponent<Animator>();

        mainMenu = GameObject.Find("Canvas").GetComponent<MainMenu>();
    }
    public void AbrirVentana()
    {      
        UIManager.Instance.OpenWindow(equipacion);
    }
    public void CerrarVentana()
    {
        UIManager.Instance.CloseWindow();
    }

    public void Crear()
    {
        animTaller.SetBool("Active", false);
        animLab.SetBool("Active", true);
        mainMenu.AnimActual = animLab;

        CerrarVentana();
    }

    public void SeleccionarItem ()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        btnActual = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
    }
}
