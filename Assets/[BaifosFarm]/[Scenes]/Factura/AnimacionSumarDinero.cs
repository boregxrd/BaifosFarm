using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionSumarDinero : MonoBehaviour
{
    [SerializeField] float duracionAnimacion = 1.5f; // en segundos
    private float numeroOrigen, numeroDestino, numeroActual;
    [SerializeField] Text textoDinero;

   

    public void AddToNumber(float numero, float numeroOrigen)
    {
        this.numeroOrigen = numeroOrigen;
        numeroActual = numeroOrigen;
        numeroDestino = numeroActual + numero;
    }

    private void Update()
    {
        if (numeroActual != numeroDestino)
        {
            if (numeroOrigen < numeroDestino)
            {
                numeroActual += (duracionAnimacion * Time.deltaTime) * (numeroDestino - numeroOrigen);

                if (numeroActual >= numeroDestino)
                {
                    numeroActual = numeroDestino;
                }
            }
            textoDinero.text = numeroActual.ToString("0"); // sin decimales
        }
    }
}
