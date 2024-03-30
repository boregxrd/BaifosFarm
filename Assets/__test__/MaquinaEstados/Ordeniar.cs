using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordeniar : MonoBehaviour
{
    [SerializeField] private BarraLeche barraLeche;

    [SerializeField] private GameObject miniJuegoOrdenyar;

    private void Awake()
    {
        enabled = false;
    }

    public void IniciarOrdenyado(Collider other)
    {
        var children = other.gameObject.GetComponentsInChildren<Transform>(); //dentro de la cabra busco el objeto barraAlimento y luego su script
        foreach (var child in children)
        {
            if (child.name == "BarraLeche")
            {
                barraLeche = child.GetComponent<BarraLeche>();

                if (barraLeche.lechePreparada == true)
                {
                    miniJuegoOrdenyar.SetActive(true);
                }
            }
        }
    }
}
