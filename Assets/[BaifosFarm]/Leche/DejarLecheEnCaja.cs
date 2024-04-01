using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DejarLecheEnCaja : MonoBehaviour
{
    [SerializeField] ControladorAccionesPersonaje controladorAccionesPersonaje;
    [SerializeField] MiniJuegoOrdenyar miniJuegoOrdenyar;
    [SerializeField] private GameObject leche;

    private void Awake()
    {
        enabled = false;
    }

    public void DejarLeche()
    {
        leche = controladorAccionesPersonaje.objetoEnMano;
        Destroy(leche);
       
    }

    public bool TengoLecheEnMano()
    {
        if(controladorAccionesPersonaje.objetoEnMano == controladorAccionesPersonaje.ultimaLecheEnMano)
        { 
            return true; 
        }

        return false;
    }
}