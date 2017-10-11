﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPartesPlayer : MonoBehaviour {
    [SerializeField] ManagerTaladro partes;
    static Motor motorPlayer;
    static Cabeza cabezaPlayer;
    void Start()
    {
        if (motorPlayer==null)
        {
            motorPlayer = partes.motores[0];
        }
        if (cabezaPlayer == null)
        {
            cabezaPlayer = partes.cabezas[0];
        }
    }
    public void SetMotorPlayer(Motor motorEquipar)
    {
        motorPlayer = motorEquipar;
    }

    public void SetCabezaPlayer(Cabeza cabezaEquipar)
    {
        cabezaPlayer = cabezaEquipar;
    }

    public Motor GetMotorPlayer()
    {
        return motorPlayer;
    }

    public Cabeza GetCabezaPlayer()
    {
        return cabezaPlayer;
    }
}
