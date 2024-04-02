using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void Jugar() {
        // Reset valores de cabras para nueva partida
        PlayerPrefs.SetInt("cabrasBlancas", 2);
        PlayerPrefs.SetInt("cabrasNegras", 0);
        SceneManager.LoadScene("Juego");
    }

    public void Ajustes() {
        Debug.Log("Falta por hacer el menu ajustes");
    }

    public void Salir() {
        Application.Quit();
    }
}
