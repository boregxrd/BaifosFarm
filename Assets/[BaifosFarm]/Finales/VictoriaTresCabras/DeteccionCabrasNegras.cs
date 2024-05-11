using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeteccionCabrasNegras : MonoBehaviour
{
    public CabraNegra[] cabrasNegras;
    private int cabrasNegrasAlFinal = 0;

    public bool CuidasteLasCabrasNegrasAlFinal()
    {
        cabrasNegras = FindObjectsOfType<CabraNegra>();
        Debug.Log("cabras negras al final: " + cabrasNegras.Length);

        if (cabrasNegras.Length <= 2) return false;

        for (int i = 0; i < cabrasNegras.Length; i++)
        {
            if (!cabrasNegras[i].cabraNegraMuerta)
            {
                cabrasNegrasAlFinal++;
            }
        }

        Debug.Log("cabras negras al final tras for: " + cabrasNegrasAlFinal);

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
