using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorCabras : MonoBehaviour
{
    // Singleton
    private static ContadorCabras instance;
    public static ContadorCabras Instance{ get { return instance; } }
    
    public int initNumCabrasBlancas = 2; 
    public int initNumCabrasNegras = 0; 

    private int numCabrasBlancas;
    public int NumCabrasBlancas { get => numCabrasBlancas; }
    private int numCabrasNegras;
    public int NumCabrasNegras { get => numCabrasNegras; }


    private void Awake() {
        if(Instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            numCabrasBlancas = initNumCabrasBlancas;
            numCabrasNegras = initNumCabrasNegras;
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
