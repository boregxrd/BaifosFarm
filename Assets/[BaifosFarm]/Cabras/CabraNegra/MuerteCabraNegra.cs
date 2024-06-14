using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MuerteCabraNegra : MonoBehaviour
{
    BarraAlimento barraAlimento;
    public LayerMask nuevaLayerMask;
    CabraNegra cabraNegra;
    ContadorCabras contadorCabras;
    [SerializeField] GameObject canvasBarraAlimento;

    private void Start()
    {
        contadorCabras = FindObjectOfType<ContadorCabras>();
        barraAlimento = GetComponentInChildren<BarraAlimento>();
        cabraNegra = GetComponent<CabraNegra>();
    }

    private void Update()
    {
        if(!cabraNegra.cabraNegraMuerta)
        {
            if (barraAlimento.ValorActual == 0)
            {
                Morir();
            }
        }
    }


    public void Morir()
    {
        gameObject.layer = nuevaLayerMask;
        barraAlimento.enabled = false;
        canvasBarraAlimento.SetActive(false);
        contadorCabras.MuerteCabraNegra();
        cabraNegra.cabraNegraMuerta = true;
    }

}
