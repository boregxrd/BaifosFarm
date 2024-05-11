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

    private void Start()
    {
        barraAlimento = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();
        cabraNormal.SetActive(true);
        cabraMuerta.SetActive(false);
    }

    private void Update()
    {
        if (barraAlimento.ValorActual == 0)
        {
            Morir();
        }
    }


    public void Morir()
    {
        gameObject.layer = nuevaLayerMask;
        cabraNormal.SetActive(false);
        cabraMuerta.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);  
    }

}
