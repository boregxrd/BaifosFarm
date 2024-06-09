// MenuInicio.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public GameObject canvasMenuAjustes; // Referencia al Canvas del men� de ajustes
    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void Start()
    {
        canvasMenuAjustes.SetActive(false); // Desactivar el Canvas del men� de ajustes al iniciar
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
        canvasMenuAjustes.SetActive(true); // Activar el Canvas del men� de ajustes
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
