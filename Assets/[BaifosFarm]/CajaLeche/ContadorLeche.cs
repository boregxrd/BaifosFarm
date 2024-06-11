using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorLeche : MonoBehaviour
{
    private ContadorLeche instance;
    public ContadorLeche Instance { get { return instance; } }

    private int contador;
    public int Contador { get => contador; }

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            contador = 0;
        }
    }

    public void SumarLeche() {
        contador++;
    }

    public void Resetear() {
        contador--;
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
