using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipacionTaladro : MonoBehaviour
{

    public Cabeza cabeza;
    public Motor motor;

    private void Update()
    {
        Debug.Log(cabeza.speed);
    }
}
