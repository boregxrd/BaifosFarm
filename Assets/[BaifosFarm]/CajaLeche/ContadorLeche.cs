using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorLeche : MonoBehaviour
{
    private static ContadorLeche instance;
    public static ContadorLeche Instance { get { return instance; } }

    private int contador;
    public int Contador { get => contador; }

    private void Awake() {
        if(Instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            contador = 0;
        } else {
            DestroyImmediate(gameObject);
        }
    }

    public void SumarLeche() {
        contador++;
    }

    public void Resetear() {
        contador = 0;
    }

    public void Destruir()
    {
        if (instance == this)
        {
            instance = null;
            Destroy(gameObject);
        }
    }
}
