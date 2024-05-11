using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontonHeno : MonoBehaviour, IInteractuable
{

    [SerializeField] private GameObject prefabHeno;

    ManejarHeno manejadorHeno;


    private void Start()
    {
        manejadorHeno = FindObjectOfType<ManejarHeno>();
    }

    public void Interactuar(Jugador jugador)
    {
        GenerarHeno(jugador);
    }

    private void GenerarHeno(Jugador jugador)
    {
        //si no lleva nada en las manos
        if (!jugador.HenoRecogido && !jugador.LecheRecogida) manejadorHeno.CogerHeno(prefabHeno, jugador.Mano);
        
        //si lleva algo en las manos
        else if (jugador.HenoRecogido || jugador.LecheRecogida) return;
    }

}
