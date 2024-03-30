using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraLeche : MonoBehaviour
{

    private float valorMaximo = 100f;
    [SerializeField] private float valorActual = 0f;
    [SerializeField] private float velocidadAumento = 5f; // Velocidad a la que aumenta la barra de leche

    private Image barraLeche;
    [SerializeField] private GameObject cabra;

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
        }
        else
        {
            valorActual = valorMaximo;
        }
    }
}
