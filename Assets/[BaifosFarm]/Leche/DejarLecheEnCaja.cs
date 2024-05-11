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

    private void Start()
    {
        controladorTextoCaja = GetComponent<ControladorTextoCaja>();
    }


    /*
    [SerializeField] ControladorAccionesPersonaje controladorAccionesPersonaje;
    [SerializeField] MiniJuegoOrdenyar miniJuegoOrdenyar;
    [SerializeField] private GameObject leche;

    public bool lecheGuardada = false; // Variable para comprobar si la leche ha sido guardada

    private void Awake()
    {
        enabled = false;
    }

    public void DejarLeche()
    {
        leche = controladorAccionesPersonaje.objetoEnMano;
        Destroy(leche);
        lecheGuardada = true; // Marcar la leche como guardada para el Tutorial
    }

    public bool TengoLecheEnMano()
    {
        if(controladorAccionesPersonaje.objetoEnMano == controladorAccionesPersonaje.ultimaLecheEnMano)
        { 
            return true; 
        }

        return false;
    }
    */

    public void Interactuar(Jugador jugador)
    {
        if (jugador.LecheRecogida)
        {
            manejarLeche = jugador.GetComponent<ManejarLeche>();
            manejarLeche.DejarLeche();
            controladorTextoCaja.GuardarLeche();

            //para el tutorial
            lecheGuardada = true;
        }
        
    }
}