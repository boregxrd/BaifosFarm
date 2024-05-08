using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������������������������������������������������������SCRIPT ACCI�N ORDE�AR������������������������������������������������������
//Este script ha de estar en Mano dentro de Personaje

public class Ordeniar : MonoBehaviour
{
    [SerializeField] private BarraLeche barraLeche;

    [SerializeField] private MiniJuegoOrdenyar miniJuegoOrdenyar;

    public bool ordenioIniciado = false;

    public bool ordeniarIniciado = false; //Para verificar en el Tutorial

    protected Cabra cabraActual;

    private void Awake()
    {
        enabled = false;
    }

    public void IniciarOrdenyado(Cabra cabra)
    {
        cabraActual = cabra;
        var children = cabra.gameObject.GetComponentsInChildren<Transform>(); //dentro de la cabra busco el objeto barraLeche y luego su script
        foreach (var child in children)
        {
            if (child.name == "BarraLeche")
            {
                barraLeche = child.GetComponent<BarraLeche>();

                if (barraLeche.lechePreparada == true)
                {
                    cabraActual.pararCabra();
                    miniJuegoOrdenyar.enabled = true;
                    ordenioIniciado = true;
                    ordeniarIniciado = true; //Para verificar en el Tutorial
                    miniJuegoOrdenyar.enabled = true;
                }
            }
        }
    }

    private void Update()
    {
        if (miniJuegoOrdenyar.miniJuegoReseteado == true)
        {
            barraLeche.resetearLeche();
            cabraActual.continuarMov();
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
