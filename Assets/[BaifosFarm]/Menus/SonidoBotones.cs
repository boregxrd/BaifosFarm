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
        Debug.Log("Sonido botones");
    }

    public void ReproducirSonidoBotonCerrar()
    {
        audiosource.PlayOneShot(sonidoBotonCerrar);
        Debug.Log("Sonido botones");
    }

    public void ReproducirSonidoBotonNormalEnPausa()
    {
        Time.timeScale = 1;
        audiosource.PlayOneShot(sonidoBotonNormal);
        Debug.Log("Sonido botones");
        Time.timeScale = 0;
    }

    public void ReproducirSonidoBotonCerrarEnPausa()
    {
        Time.timeScale = 1;
        audiosource.PlayOneShot(sonidoBotonCerrar);
        Debug.Log("Sonido botones");
        Time.timeScale = 0;
    }
}
