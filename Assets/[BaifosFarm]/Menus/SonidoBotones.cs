using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBotones : MonoBehaviour
{
    AudioSource audiosource;

    [SerializeField] private AudioClip sonidoBotonNormal;
    [SerializeField] private AudioClip sonidoBotonCerrar;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void ReproducirSonidoBotonNormal()
    {
        audiosource.PlayOneShot(sonidoBotonNormal);
    }

    public void ReproducirSonidoBotonCerrar()
    {
        audiosource.PlayOneShot(sonidoBotonCerrar);
    }
}
