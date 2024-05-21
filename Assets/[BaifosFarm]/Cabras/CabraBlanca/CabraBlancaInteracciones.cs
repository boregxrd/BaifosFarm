using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabraBlancaInteracciones : MonoBehaviour, IInteractuable
{

    private BarraLeche barraLeche;
    [SerializeField] private BarraAlimento barraAlimento;
    private ManejarHeno manejadorHeno;
    private TipoDeHeno tipoDeHeno;
    private MiniJuegoOrdenyar miniJuegoOrdenyar;
    [SerializeField] private MovimientoAleatorioCabras movimientoAleatorioCabras;
    private Jugador jugador;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        tipoDeHeno = FindObjectOfType<TipoDeHeno>();
        barraLeche = transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<BarraLeche>();
        miniJuegoOrdenyar = FindObjectOfType<MiniJuegoOrdenyar>();
        movimientoAleatorioCabras = GetComponent<MovimientoAleatorioCabras>();
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
            animator.SetTrigger("Comiendo");
        }
    }

    public void Ordenyar(Jugador jugador)
    {
        this.jugador = jugador;

        if (!jugador.HenoRecogido && !jugador.LecheRecogida && nivelDeLeche() == barraLeche.ValorMaximo)
        {
            miniJuegoOrdenyar.IniciarOrdenyado(gameObject);
            movimientoAleatorioCabras.pararCabra(gameObject);
            jugador.GetComponent<Character>().PararMovimiento();
        }
    }

    public void ResetearLeche()
    {
        barraLeche.resetearLeche();
        movimientoAleatorioCabras.continuarMov(gameObject);
        jugador.GetComponent<Character>().ContinuarMovimiento();
        animator.SetTrigger("Ordenyada");
    }
}
