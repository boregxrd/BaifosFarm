using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DejarLecheEnCaja : MonoBehaviour, IInteractuable
{
    private ManejarLeche manejarLeche;
    private ControladorTextoCaja controladorTextoCaja;

    //para el tutorial
    public bool lecheGuardada = false;

    private Animator animatorDejarLeche;
    private ParticleSystem particulasDejarLeche;

    private void Start()
    {
        controladorTextoCaja = GetComponent<ControladorTextoCaja>();
        animatorDejarLeche = GetComponent<Animator>();
        particulasDejarLeche = GetComponent<ParticleSystem>();
    }

    public void Interactuar(Jugador jugador)
    {
        if (jugador.LecheRecogida)
        {
            manejarLeche = jugador.GetComponent<ManejarLeche>();
            manejarLeche.DejarLeche();
            controladorTextoCaja.GuardarLeche();
            animatorDejarLeche.SetTrigger("DejarLeche");
            particulasDejarLeche.Play();
            //para el tutorial
            lecheGuardada = true;
        }
        
    }
}