using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//·······················································SCRIPT BARRA LECHE······················································
//Este script ha de estar en BarraLeche dentro de Cabra

public class BarraLeche : MonoBehaviour
{

    private float valorMaximo = 100f;
    [SerializeField] private float valorActual = 0f;
    [SerializeField] private float velocidadAumento = 15f; // Velocidad a la que aumenta la barra de leche
    public bool lechePreparada = false;

    private Image barraLeche;
    

    void Start()
    {
        barraLeche = GetComponent<Image>();
        barraLeche.fillAmount = valorActual / valorMaximo; // Asegúrate de que la barra se inicialice correctamente
    }

    void Update()
    {
        // Aumentar la barra de leche con el tiempo
        if (valorActual < valorMaximo)
        {
            valorActual += velocidadAumento * Time.deltaTime; // Aumenta el valor de la leche con el tiempo
            barraLeche.fillAmount = valorActual / valorMaximo; // Actualiza la barra de alimentación visualmente
            lechePreparada = false;
        }
        else
        {
            valorActual = valorMaximo;
            lechePreparada = true;
        }
    }

    public void resetearLeche()
    {
        valorActual = 0f;
        lechePreparada = false;
    }
}
