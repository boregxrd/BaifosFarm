using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabraBlancaInteracciones : MonoBehaviour, IInteractuable
{

    [SerializeField] private BarraLeche barraLeche;
    [SerializeField] private BarraAlimento barraAlimento;
    private ManejarHeno manejadorHeno;
    private TipoDeHeno tipoDeHeno;


    private void Start()
    {
        tipoDeHeno = FindObjectOfType<TipoDeHeno>();
        barraLeche = transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<BarraLeche>();
    }

    public float nivelDeLeche()
    {
        return barraLeche.valorActual;
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

    public void Ordenyar(Jugador jugador)
    {
        if (!jugador.HenoRecogido && !jugador.LecheRecogida && nivelDeLeche() == barraLeche.ValorMaximo)
        {
            Debug.Log("minijuego");
        }
    }
}
