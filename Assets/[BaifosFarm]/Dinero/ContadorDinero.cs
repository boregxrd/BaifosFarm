using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorDinero : MonoBehaviour
{
    // Singleton
    private static ContadorDinero instance;
    public static ContadorDinero Instance { get { return instance; } }

    private int dinero;
    public int Dinero { get => dinero; }

    private void Awake() {
        if(Instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            dinero = 100;
        } else {
            DestroyImmediate(gameObject);
        }
    }

    public void SumarDinero(int d) {
        dinero += d;
    }

    public void RestarDinero(int d) {
        dinero -= d;
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
