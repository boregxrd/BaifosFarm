using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class DeteccionCabrasNegras : MonoBehaviour
{
    public CabraNegra[] cabrasNegras;
    private int cabrasNegrasAlFinal = 0;

    public static Action OnThreeBlackGoatsVictory;

    public bool CuidasteLasCabrasNegrasAlFinal()
    {
        cabrasNegras = FindObjectsOfType<CabraNegra>();
        
        if (cabrasNegras.Length <= 2) return false;

        for (int i = 0; i < cabrasNegras.Length; i++)
        {
            if (!cabrasNegras[i].cabraNegraMuerta)
            {
                cabrasNegrasAlFinal++;
            }
        }

        if (cabrasNegrasAlFinal >= 3) 
        {
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

    public void InvocarVictoria()
    {
        if (CuidasteLasCabrasNegrasAlFinal())
        {
            Debug.Log("invocamos");
            OnThreeBlackGoatsVictory?.Invoke();
            return;
        }
        else
        {
            DestruirCabrasCadaUna();
            SceneManager.LoadScene("Factura");
        }
    }

    public int CabrasNegrasMuertas()
    {
        cabrasNegras = FindObjectsOfType<CabraNegra>();
        int cabrasNegrasMuertas = 0;

        for (int i = 0; i < cabrasNegras.Length; i++)
        {
            if (cabrasNegras[i].cabraNegraMuerta)
            {
                cabrasNegrasMuertas++;
            }
        }
        
        return cabrasNegrasMuertas;
    }
}
