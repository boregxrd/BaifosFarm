using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBotones : MonoBehaviour
{
    private AudioManagerBotones audioManagerBotones;
    [SerializeField] AudioClip sonido;

    public void ReproducirSonidoBoton()
    {
        audioManagerBotones = FindObjectOfType<AudioManagerBotones>();
        audioManagerBotones.ReproducirSonidoBoton(sonido);
    }

}
