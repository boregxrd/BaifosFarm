using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MuerteCabraNegra : MonoBehaviour
{
    BarraAlimento barraAlimento;
    public LayerMask nuevaLayerMask;
    CabraNegra cabraNegra;

    private void Start()
    {
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
        int negrasAntesDeMorir = PlayerPrefs.GetInt("cabrasNegras", 0);
        PlayerPrefs.SetInt("cabrasNegras", negrasAntesDeMorir - 1);
        cabraNegra.cabraNegraMuerta = true;
    }

}
