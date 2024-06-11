using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorCabras : MonoBehaviour
{
    // Singleton
    private static ContadorCabras instance;
    public static ContadorCabras Instance{ get { return instance; } }

    private int numCabrasGrises;
    public int NumCabrasGrises { get => numCabrasGrises; }
    private int numCabrasNegras;
    public int NumCabrasNegras { get => numCabrasNegras; }


    private void Awake() {
        if(Instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            numCabrasGrises = 2;
            numCabrasNegras = 0;
        } else {
            DestroyImmediate(gameObject);
        }
    }

    private void Start() {
        Debug.Log(numCabrasGrises + ", " + numCabrasNegras);
    }

    public void MuerteCabraGris() {
        numCabrasGrises--;
    }

    public void MuerteCabraNegra() {
        numCabrasNegras--;
    }

    public void NuevaCabraGris() {
        numCabrasGrises++;   
    }

    public void NuevaCabraNegra() {
        numCabrasNegras++;   
    }
}
