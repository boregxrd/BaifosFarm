// MenuInicio.cs
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal
    ContadorDias contadorDias;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void Start()
    {
        contadorDias = FindAnyObjectByType<ContadorDias>();
        if(contadorDias != null) contadorDias.Destruir();
    }

    public void Jugar()
    {

        // Reset valores de cabras para nueva partida
        PlayerPrefs.SetInt("cabrasBlancas", 2);
        PlayerPrefs.SetInt("cabrasNegras", 0);
        PlayerPrefs.SetInt("DineroTotal", 100);
        PlayerPrefs.SetInt("HenoMejorado", 0);
        PlayerPrefs.SetInt("LechesGuardadas", 0);
        PlayerPrefs.SetInt("TutorialCompleto", 0); // Marcar el tutorial como no completado
        SceneManager.LoadScene("Comic_Introduccion");
    }

    public void Ajustes()
    {
        SceneManager.LoadScene("MenuAjustes", LoadSceneMode.Additive);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void EscenaTresCabrasNegras()
    {
        PlayerPrefs.SetInt("cabrasBlancas", 0);
        PlayerPrefs.SetInt("cabrasNegras", 3);
        PlayerPrefs.SetInt("DineroTotal", 100);
        PlayerPrefs.SetInt("HenoMejorado", 0);
        PlayerPrefs.SetInt("LechesGuardadas", 0);
        PlayerPrefs.SetInt("TutorialCompleto", 1); // Marcar el tutorial como completado
        SceneManager.LoadScene("Juego");
    }

    public void OnButtonCursorEnter()
    {
        // Cambiar el cursor a mano
        Cursor.SetCursor(cursorMano, Vector2.zero, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        // Cambiar el cursor a normal
        Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
    }
}
