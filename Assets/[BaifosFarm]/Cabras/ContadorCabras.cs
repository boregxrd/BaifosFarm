using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorCabras : MonoBehaviour
{
    // Singleton
    private static ContadorCabras instance;
    public static ContadorCabras Instance{ get { return instance; } }

    private int numCabrasBlancas;
    public int NumCabrasBlancas { get => numCabrasBlancas; }
    private int numCabrasNegras;
    public int NumCabrasNegras { get => numCabrasNegras; }


    private void Awake() {
        if(Instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            numCabrasBlancas = 2;
            numCabrasNegras = 0;
        } else {
            DestroyImmediate(gameObject);
        }
    }

    public void MuerteCabraGris() {
        numCabrasBlancas--;
    }

    public void MuerteCabraNegra() {
        numCabrasNegras--;
    }

    public void NuevaCabraGris() {
        numCabrasBlancas++;   
    }

    public void NuevaCabraNegra() {
        numCabrasNegras++;   
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
