using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasosBaifo : MonoBehaviour
{
    [SerializeField] ParticleSystem particulasPieDcho;

    [SerializeField] ParticleSystem particulasPieIzqdo;

    public void DispararParticulasPieDcho()
    {
        Debug.Log("pieDcho");
        particulasPieDcho.Play();
    }

    public void DispararParticulasPieIzqdo()
    {
        Debug.Log("pieIzqdo");
        particulasPieIzqdo.Play();
    }
}
