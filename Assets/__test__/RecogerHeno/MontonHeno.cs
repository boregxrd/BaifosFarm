using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontonHeno : MonoBehaviour, IInteractuable
{

    [SerializeField] private GameObject prefabHeno;

    public void Interactuar(Jugador jugador)
    {
        GenerarHeno(jugador);
    }

    private void GenerarHeno(Jugador jugador)
    {
        jugador.CogerHeno(prefabHeno);
    }

}
