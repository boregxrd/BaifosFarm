// MenuInicio.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public GameObject canvasMenuAjustes; // Referencia al Canvas del menú de ajustes

    public void Start()
    {
        canvasMenuAjustes.SetActive(false); // Desactivar el Canvas del menú de ajustes al iniciar
    }

    public void Jugar()
    {
        // Reset valores de cabras para nueva partida
        PlayerPrefs.SetInt("cabrasBlancas", 2);
        PlayerPrefs.SetInt("cabrasNegras", 0);
        PlayerPrefs.SetInt("DineroTotal", 100);
        PlayerPrefs.SetInt("HenoMejorado", 0);
        SceneManager.LoadScene("Juego");
    }

    public void Ajustes()
    {
        canvasMenuAjustes.SetActive(true); // Activar el Canvas del menú de ajustes
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        // Reset valores de cabras para nueva partida
        PlayerPrefs.SetInt("cabrasBlancas", 2);
        PlayerPrefs.SetInt("cabrasNegras", 0);
        PlayerPrefs.SetInt("DineroTotal", 100);
        PlayerPrefs.SetInt("HenoMejorado", 0);
        SceneManager.LoadScene("Tutorial");
    }
}
