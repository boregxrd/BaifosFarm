using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeteccionCabrasNegras : MonoBehaviour
{
    private CabraNegra[] cabrasNegras;
    private int cabrasNegrasAlFinal = 0;

    public void VerificarSiHayTresCabrasNegrasAlInicio()
    {
        cabrasNegras = FindObjectsOfType<CabraNegra>();
        // Verifica si hay tres cabras negras al inicio
        Debug.Log("cabras negras al inicio:" + cabrasNegras.Length);
        if (cabrasNegras.Length >= 3)
        {
            int contadorCabrasNegras = cabrasNegras.Length;
        }
    }

    public bool CuidasteLasCabrasNegrasAlFinal()
    {
        if (cabrasNegras.Length <= 2) return false;

        for (int i = 0; i < cabrasNegras.Length; i++)
        {
            if (!cabrasNegras[i].cabraNegraMuerta)
            {
                cabrasNegrasAlFinal++;
            }
        }

        Debug.Log("cabras negras al final: " + cabrasNegrasAlFinal);

        if (cabrasNegrasAlFinal >= 3) 
        {
            Debug.Log("Tres cabras vivas al final true");
            return true;
        }
        return false;
    }

    public void DestruirCabrasCadaUna()
    {
        foreach (CabraNegra cabra in cabrasNegras)
        {
            cabra.DestruirCabrasNegrasMuertas();
        }
    }
}
