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
    ContadorLeche contadorLeche;
    ContadorDinero contadorDinero;
    ContadorCabras contadorCabras;

    [SerializeField] Transicion transicion;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void Start()
    {
        contadorDias = FindAnyObjectByType<ContadorDias>();
        if(contadorDias != null) contadorDias.Destruir();
        
        contadorLeche = FindAnyObjectByType<ContadorLeche>();
        if(contadorLeche != null) contadorLeche.Destruir();
        
        contadorCabras = FindAnyObjectByType<ContadorCabras>();
        if(contadorCabras != null) contadorCabras.Destruir();

        contadorDinero = FindAnyObjectByType<ContadorDinero>();
        if(contadorDinero != null) contadorDinero.Destruir();

    }

    public void Jugar()
    {
        transicion.FadeOut();
        PlayerPrefs.SetInt("HenoMejorado", 0);
        PlayerPrefs.SetInt("TutorialCompleto", 0); // Marcar el tutorial como no completado
        AudioManager.Instance.ChangeScene("Comic_Introduccion");
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
        PlayerPrefs.SetInt("HenoMejorado", 0);
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
