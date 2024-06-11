using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasosBaifo : MonoBehaviour
{
    [SerializeField] ParticleSystem particulasPieDcho;

    [SerializeField] ParticleSystem particulasPieIzqdo;

    private AudioSource audioSource;
    [SerializeField] AudioClip[] sonidosPasosBaifo;
    [SerializeField] AudioClip[] sonidosEsfuerzoBaifo;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DispararParticulasPieDcho()
    {
        particulasPieDcho.Play();
        audioSource.PlayOneShot(sonidosPasosBaifo[Random.Range(0, sonidosPasosBaifo.Length)]);
    }

    public void DispararParticulasPieIzqdo()
    {
        particulasPieIzqdo.Play();
        audioSource.PlayOneShot(sonidosPasosBaifo[Random.Range(0, sonidosPasosBaifo.Length)]);
    }

    public void ReproducirSonidoEsfuerzo()
    {
        audioSource.PlayOneShot(sonidosEsfuerzoBaifo[Random.Range(0, sonidosEsfuerzoBaifo.Length)]);
    }
}
