using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraLeche : MonoBehaviour
{
    private float valorMaximo = 100f;
    [SerializeField] private float valorActual = 0f;
    [SerializeField] private float velocidadAumento = 15f; // Velocidad a la que aumenta la barra de leche
    public bool lechePreparada = false;

    private Image barraLeche;
    private BarraAlimento barraAlimento; // Referencia al script BarraAlimento
    private bool produccionDetenida = false; // Variable para controlar si la producción de leche está detenida

    void Start()
    {
        barraLeche = GetComponent<Image>();
        barraLeche.fillAmount = valorActual / valorMaximo; // Asegúrate de que la barra se inicialice correctamente

        // Obtener la referencia al script BarraAlimento
        barraAlimento = FindObjectOfType<BarraAlimento>();
    }

    void Update()
    {
        // Verificar si la producción de leche debe detenerse
        if (barraAlimento != null && barraAlimento.valorActual < 30f)
        {
            produccionDetenida = true;
        }
        else
        {
            produccionDetenida = false;
        }

        // Si la producción de leche está detenida, salir de la función sin aumentar la barra de leche
        if (produccionDetenida)
        {
            return;
        }

        // Reanudar la producción de leche tan pronto como la comida vuelva a estar por encima de 30f
        if (barraAlimento.valorActual >= 30f)
        {
            produccionDetenida = false;
        }

        // Aumentar la barra de leche con el tiempo solo si la producción no está detenida
        if (!produccionDetenida && valorActual < valorMaximo)
        {
            valorActual += velocidadAumento * Time.deltaTime; // Aumenta el valor de la leche con el tiempo
            barraLeche.fillAmount = valorActual / valorMaximo; // Actualiza visualmente la barra de leche
            lechePreparada = false;
        }
        else
        {
            valorActual = Mathf.Clamp(valorActual, 0f, valorMaximo); // Asegurar que el valor actual esté en el rango válido
            lechePreparada = true; // Indicar que la leche está lista si se ha alcanzado el valor máximo
        }
    }



    public void resetearLeche()
    {
        valorActual = 0f;
        lechePreparada = false;
    }

    public void OrdeñarCabra()
    {
        if (produccionDetenida)
        {
            // Si la producción de leche está detenida, solo reiniciar la barra de leche y salir de la función
            valorActual = 0f;
            barraLeche.fillAmount = valorActual / valorMaximo;
            lechePreparada = false;
            return;
        }

        if (valorActual >= valorMaximo)
        {
            valorActual = 0f; // Reiniciar la barra de leche después de ordeñar
            barraLeche.fillAmount = valorActual / valorMaximo; // Actualizar la barra de leche visualmente
            lechePreparada = false;
        }
    }

}
