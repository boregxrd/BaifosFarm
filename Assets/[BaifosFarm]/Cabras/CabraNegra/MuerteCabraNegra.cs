using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MuerteCabraNegra : MonoBehaviour
{
    [SerializeField] BarraAlimento barraAlimento;
    [SerializeField] GameObject cabraNormal;
    [SerializeField] GameObject cabraMuerta;
    public LayerMask nuevaLayerMask;
    public CabraNegra cabraNegra;

    private void Start()
    {
        barraAlimento = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();
        cabraNormal.SetActive(true);
        cabraMuerta.SetActive(false);
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
        //cabraNormal.SetActive(false);
        //cabraMuerta.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);
        int negrasAntesDeMorir = PlayerPrefs.GetInt("cabrasNegras", 0);
        PlayerPrefs.SetInt("cabrasNegras", negrasAntesDeMorir - 1);
        cabraNegra.cabraNegraMuerta = true;
    }

}
