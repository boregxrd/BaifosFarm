using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasosBaifo : MonoBehaviour
{
    [SerializeField] ParticleSystem particulasPieDcho;

    [SerializeField] ParticleSystem particulasPieIzqdo;

    public void DispararParticulasPieDcho()
    {
        particulasPieDcho.Play();
    }

    public void DispararParticulasPieIzqdo()
    {
        particulasPieIzqdo.Play();
    }
}
