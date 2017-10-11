using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Motor : ScriptableObject
{
    public string name;

    public float life;

    public string req1;
    public string req2;
    public int valorReq1;
    public int valorRequ2;

    public bool blueprintIsActive;

    public Sprite sprite;
    public Sprite engineIcon;
}
