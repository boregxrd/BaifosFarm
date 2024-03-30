using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        miniJuegoOrdenyar = GameObject.Find("CanvasMiniJuegoOrdenyar").GetComponent<MiniJuegoOrdenyar>();

        var children = other.gameObject.GetComponentsInChildren<Transform>(); //dentro de la cabra busco el objeto barraAlimento y luego su script
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
            //barraLeche a 0
            Debug.Log("Barra leche a 0");
            enabled = false;
            miniJuegoOrdenyar.miniJuegoReseteado = false;
        }
                    
    }

    private void OnDisable()
    {
        ordenioIniciado = false;
    }
}
