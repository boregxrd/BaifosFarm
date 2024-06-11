using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasosBaifo : MonoBehaviour
{
    [SerializeField] ParticleSystem particulasPieDcho;

    [SerializeField] ParticleSystem particulasPieIzqdo;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] sonidosPasosBaifo;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void DispararParticulasPieDcho()
    {
        particulasPieDcho.Play();

        AudioClip paso = sonidosPasosBaifo[Random.Range(0, sonidosPasosBaifo.Length)];
        audioSource.PlayOneShot(paso);
    }

    public void DispararParticulasPieIzqdo()
    {
        particulasPieIzqdo.Play();

        AudioClip paso = sonidosPasosBaifo[Random.Range(0, sonidosPasosBaifo.Length)];
        audioSource.PlayOneShot(paso);
    }
}
