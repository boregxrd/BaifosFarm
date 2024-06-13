using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionSumarDinero : MonoBehaviour
{
    [SerializeField] float duracionAnimacion = 1.5f; // en segundos
    [SerializeField] Text textoDinero;
    private AudioManagerBotones audioManagerBotones;
    [SerializeField] private AudioClip sonidoMonedas;

    float dineroActual, dineroNuevo;

    private void Start()
    {
        audioManagerBotones = FindObjectOfType<AudioManagerBotones>();
    }
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
            audioManagerBotones.ReproducirSonidoBoton(sonidoMonedas);

            yield return new WaitForSeconds(intervalo);
        }
 
        textoDinero.text = (dineroActual + dineroNuevo).ToString();
       
    }
}
