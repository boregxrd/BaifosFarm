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

    public void Interactuar(Jugador jugador)
    {
        if (jugador.LecheRecogida)
        {
            manejarLeche = jugador.GetComponent<ManejarLeche>();
            manejarLeche.DejarLeche();
            controladorTextoCaja.GuardarLeche();
            int leches = PlayerPrefs.GetInt("LechesGuardadas", 0);
            PlayerPrefs.SetInt("LechesGuardadas", leches);

            //para el tutorial
            lecheGuardada = true;
        }
        
    }
}