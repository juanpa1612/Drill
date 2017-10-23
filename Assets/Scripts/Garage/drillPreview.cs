using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drillPreview : MonoBehaviour
{
    [SerializeField]
    Image imgHead, imgEngine, imgLight;
    [SerializeField]
    ManagerPartesPlayer partesPlayer;

    private void Start()
    {
        btnGarageItem.ObjetoEquipado += ChangeSprites;
        ChangeSprites();
    }

    public void ChangeSprites ()
    {
        //imgHead.sprite = partesPlayer.cabezaPlayers.sprite;
        imgEngine.sprite = partesPlayer.motorPlayer.sprite;
    }
}
