using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorDias : MonoBehaviour
{
    //Singleton
    private static ContadorDias instance;
    public static ContadorDias Instance { get { return instance; } }

    
    private int contador;
    public int Contador { get => contador;}

    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            contador = 1;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void SumarUnDiaAlContador()
    {
        contador++;
    }

    public void ResetearContadorDias()
    {
        contador = 1;
    }
}
