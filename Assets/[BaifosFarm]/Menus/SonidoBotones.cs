using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBotones : MonoBehaviour
{
    private AudioManagerBotones audioManagerBotones;

    private void Start()
    {
        audioManagerBotones = FindObjectOfType<AudioManagerBotones>();
    }

    public void ReproducirSonidoBotonNormal()
    {
        audioManagerBotones.ReproducirSonidoBotonNormal();
    }

    public void ReproducirSonidoBotonCerrar()
    {
        audioManagerBotones.ReproducirSonidoBotonCerrar();
    }
}
