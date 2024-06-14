using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CabraBlancaInteracciones : MonoBehaviour, IInteractuable
{

    private BarraLeche barraLeche;
    [SerializeField] private BarraAlimento barraAlimento;
    private ManejarHeno manejadorHeno;
    private TipoDeHeno tipoDeHeno;
    private MiniJuegoOrdenyar miniJuegoOrdenyar;
    private MovimientoAleatorioCabras movimientoAleatorioCabras;
    private Jugador jugador;
    bool flag = true;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        tipoDeHeno = FindObjectOfType<TipoDeHeno>();
        barraLeche = transform.GetComponentInChildren<BarraLeche>();
        miniJuegoOrdenyar = FindObjectOfType<MiniJuegoOrdenyar>();
        movimientoAleatorioCabras = GetComponent<MovimientoAleatorioCabras>();
    }

    public float nivelDeLeche()
    {
        return barraLeche.valorActual;
    }


    public void Interactuar(Jugador jugador)
    {
        if (jugador.HenoRecogido && flag)
        {
            manejadorHeno = jugador.transform.GetComponent<ManejarHeno>();
            manejadorHeno.DejarHeno();
            barraAlimento.incrementarNivelAlimentacion(tipoDeHeno.incremento);
            if(animator.GetBool("enMovimiento")) {
                animator.SetTrigger("comerMov");
            } else {
                animator.SetTrigger("Comiendo");
            }
        }
    }

    public void Ordenyar(Jugador jugador)
    {
        this.jugador = jugador;

        if (!jugador.HenoRecogido && !jugador.LecheRecogida && nivelDeLeche() == barraLeche.ValorMaximo && flag)
        {
            miniJuegoOrdenyar.IniciarOrdenyado(gameObject);
            movimientoAleatorioCabras.pararCabra(gameObject);
        }
    }

    public void ResetearLeche()
    {
        barraLeche.resetearLeche();
        movimientoAleatorioCabras.continuarMov(gameObject);
        animator.SetTrigger("Ordenyada");
    }

    private void OnDisable() {
        flag = false;
    }
}
