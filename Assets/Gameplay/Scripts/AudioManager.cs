using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    AudioSource source;
    [SerializeField] AudioClip PickupGemas;
    [SerializeField] AudioClip PickupMaterialPowerup;
    [SerializeField] AudioClip RomperRoca;
    [SerializeField] AudioClip SwipeAbajo;
    [SerializeField] AudioClip GanarNivel;
    [SerializeField] AudioClip Boton;
    [SerializeField] AudioClip Choque;

	// Use this for initialization
	void Start () {
        source = gameObject.GetComponent<AudioSource>();
	}

    public void CorrerAudioGemas()
    {
        source.clip = PickupGemas;
        source.Play();
    }

    public void CorrerAudioMaterialesPowerup()
    {
        source.clip = PickupMaterialPowerup;
        source.Play();
    }

    public void CorrerAudioRomperRoca()
    {
        source.clip = RomperRoca;
        source.Play();
    }

    public void CorrerAudioSwipeAbajo()
    {
        source.clip = SwipeAbajo;
        source.Play();
    }

    public void CorrerAudioGanarNivel()
    {
        source.clip = GanarNivel;
        source.Play();
    }

    public void CorrerAudioBoton()
    {
        source.clip = Boton;
        source.Play();
    }

    public void CorrerAudioChoque()
    {
        source.clip = Choque;
        source.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
