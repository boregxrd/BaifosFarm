using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//·······················································SCRIPT ACCIÓN ORDEÑAR······················································
//Este script ha de estar en Mano dentro de Personaje

public class Ordeniar : MonoBehaviour
{
    [SerializeField] private BarraLeche barraLeche;

    [SerializeField] private MiniJuegoOrdenyar miniJuegoOrdenyar;

    public bool ordenioIniciado = false;

    private void Awake()
    {
        enabled = false;
    }

    public void IniciarOrdenyado(Collider other)
    {
        var children = other.gameObject.GetComponentsInChildren<Transform>(); //dentro de la cabra busco el objeto barraLeche y luego su script
        foreach (var child in children)
        {
            if (child.name == "BarraLeche")
            {
                barraLeche = child.GetComponent<BarraLeche>();

                if (barraLeche.lechePreparada == true)
                {
                    miniJuegoOrdenyar.enabled = true;
                    ordenioIniciado = true;
                    
                }
            }
        }
    }

    private void Update()
    {
        if (miniJuegoOrdenyar.miniJuegoReseteado == true)
        {
            barraLeche.resetearLeche();
            enabled = false;
            miniJuegoOrdenyar.miniJuegoReseteado = false;
        }
                    
    }

    private void OnDisable()
    {
        ordenioIniciado = false;
        miniJuegoOrdenyar.enabled = false;
    }
}
