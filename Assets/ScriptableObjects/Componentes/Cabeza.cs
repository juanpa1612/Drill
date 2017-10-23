using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Cabeza",menuName ="Upgrades/Cabeza")]
public class Cabeza : ScriptableObject
{
    public string name;
    public float speed;
    public string req1;
    public string req2;
}
