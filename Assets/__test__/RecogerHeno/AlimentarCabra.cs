using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentarCabra : MonoBehaviour, IInteractuable
{

    [SerializeField] private BarraAlimento barraAlimento;
    ManejarHeno manejadorHeno;


    private float incremento = 40f;
   
    public void Interactuar(Jugador jugador)
    {
        if (jugador.HenoRecogido)
        {
            manejadorHeno = jugador.transform.GetComponent<ManejarHeno>();
            manejadorHeno.DejarHeno();
            barraAlimento.incrementarNivelAlimentacion(incremento);
        }
        
    }
}
