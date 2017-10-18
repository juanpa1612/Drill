using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Motor : ScriptableObject
{
    public string name;

    public int life;

    public string req1;
    public string req2;
    public int valorReq1;
    public int valorReq2;

    public bool blueprintIsActive;
    public bool isCreated;

    public Sprite sprite;
    public Sprite engineIcon;
}
