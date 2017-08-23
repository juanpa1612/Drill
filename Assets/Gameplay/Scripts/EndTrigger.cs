using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    [SerializeField]private GameObject camara;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            camara.GetComponent<SmoothCamera2D>().noTerminado = false;
        }
    }
}
