using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBotones : MonoBehaviour
{
    private AudioManagerBotones audioManagerBotones;

    public void ReproducirSonidoBotonNormal()
    {
        audioManagerBotones = FindObjectOfType<AudioManagerBotones>();
        audioManagerBotones.ReproducirSonidoBotonNormal();
    }

    public void ReproducirSonidoBotonCerrar()
    {
        audioManagerBotones = FindObjectOfType<AudioManagerBotones>();
        audioManagerBotones.ReproducirSonidoBotonCerrar();
    }
}
