using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeteccionCabrasNegras : MonoBehaviour
{
    private CabraNegra[] cabrasNegras;
    private CabraNegra[] cabrasNegrasAlFinal;

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
        cabrasNegrasAlFinal = FindObjectsOfType<CabraNegra>();
        Debug.Log("cabras negras al final: " + cabrasNegrasAlFinal.Length);

        if (cabrasNegrasAlFinal.Length <= 2) return false;

        if (cabrasNegrasAlFinal.Length == cabrasNegras.Length)
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
