using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarraLeche : MonoBehaviour
{
    private float valorMaximo = 100f;
    public float valorActual = 0f;
    [SerializeField] private float velocidadAumento = 10f; // Velocidad a la que aumenta la barra de leche
    public bool lechePreparada = false;

    private Image barraLeche;
    [SerializeField] private BarraAlimento barraAlimento; // Referencia al script BarraAlimento
    private bool produccionDetenida = false; // Variable para controlar si la producci�n de leche est� detenida

    void Start()
    {
        barraLeche = GetComponent<Image>();
        barraLeche.fillAmount = valorActual / valorMaximo; // Aseg�rate de que la barra se inicialice correctamente
    }

    void Update()
    {

        if(barraAlimento == null)
        {
            return;
        }
        // Verificar si la producci�n de leche debe detenerse
        if (barraAlimento.valorActual < 30f)
        {
            produccionDetenida = true;
        }
        else
        {
            produccionDetenida = false;
        }

        // Aumentar la barra de leche con el tiempo solo si la producci�n no est� detenida
        if (!produccionDetenida && valorActual < valorMaximo)
        {
            valorActual += velocidadAumento * Time.deltaTime; // Aumenta el valor de la leche con el tiempo
             // Actualiza visualmente la barra de leche
            lechePreparada = false;
        }
        else if(!produccionDetenida && valorActual >=valorMaximo)
        {
            valorActual = valorMaximo;//Mathf.Clamp(valorActual, 0f, valorMaximo); // Asegurar que el valor actual est� en el rango v�lido
            produccionDetenida = true;
            lechePreparada = true; // Indicar que la leche est� lista si se ha alcanzado el valor m�ximo
        }
        barraLeche.fillAmount = valorActual / valorMaximo;
    }

    public void resetearLeche()
    {
        valorActual = 0f;
        produccionDetenida = false;
        Debug.Log(valorActual + " Valor Actual");
        lechePreparada = false;
    }

}
