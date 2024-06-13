using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionSumarDinero : MonoBehaviour
{
    [SerializeField] float duracionAnimacion = 1.5f; // en segundos
    private float numeroOrigen, numeroDestino, numeroActual;
    [SerializeField] Text textoDinero;

    float dineroActual, dineroNuevo;

    public void Inicio(float d, float suma)
    {
        dineroActual = d;
        dineroNuevo = suma;
        float intervalo = duracionAnimacion / suma;

        StartCoroutine(SumarDinero(intervalo));
    }

    private IEnumerator SumarDinero(float intervalo)
    {
        Debug.Log(dineroActual + " " + dineroNuevo);
        for (int i = 0; i < dineroNuevo; i++)
        {
            textoDinero.text = (dineroActual + i).ToString();

            yield return new WaitForSeconds(intervalo);
        }
 
        textoDinero.text = (dineroActual + dineroNuevo).ToString();
    }
}
