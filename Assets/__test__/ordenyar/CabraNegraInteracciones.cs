using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabraNegraInteracciones : MonoBehaviour, IInteractuable
{
    [SerializeField] private BarraAlimento barraAlimento;
    private ManejarHeno manejadorHeno;
    private TipoDeHeno tipoDeHeno;

    private void Start()
    {
        tipoDeHeno = FindObjectOfType<TipoDeHeno>();
    }

    public void Interactuar(Jugador jugador)
    {
        if (jugador.HenoRecogido)
        {
            manejadorHeno = jugador.transform.GetComponent<ManejarHeno>();
            manejadorHeno.DejarHeno();
            barraAlimento.incrementarNivelAlimentacion(tipoDeHeno.incremento);
        }

    }
}
