using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MuerteCabraNegra : MonoBehaviour
{
    [SerializeField] BarraAlimento barraAlimento;
    [SerializeField] GameObject cabraNormal;
    [SerializeField] GameObject cabraMuerta;
    [SerializeField] public CabraNegra cabra;
    public LayerMask nuevaLayerMask;
    

    private void Start()
    {
        barraAlimento = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();
        cabraNormal.SetActive(true);
        cabraMuerta.SetActive(false);
        cabra = GetComponent<CabraNegra>();
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

        cabra.cabraNegraMuerta = true;
    }

}
