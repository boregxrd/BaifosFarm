using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuAjustes : MonoBehaviour
{
    public AudioMixer audioMixer; // AudioMixer para controlar el volumen
    public Slider sliderVolumen; // Slider para ajustar el volumen
    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal
    public Toggle toggle; // Toggle Pantalla Completa
    public int calidad;
    public TMP_Dropdown dropdown;
    public TMP_Dropdown resolucionesDropdown;
    Resolution[] resoluciones;
    private MenuPausa menuPausa;

    void Start()
    {
        menuPausa = FindObjectOfType<MenuPausa>();

        // Cargar el valor de volumen guardado desde PlayerPrefs
        float volumenGuardado = PlayerPrefs.GetFloat("Volumen", 1f); // Valor por defecto 1 (máximo volumen) si no hay valor guardado
        AudioListener.volume = volumenGuardado;

        // Actualizar el valor del slider al valor guardado
        sliderVolumen.value = volumenGuardado * 100; // Convertir a un rango de 0 a 100

        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        } else
        {
            toggle.isOn = false;
        }

        calidad = PlayerPrefs.GetInt("CalidadGuardada", 6);
        dropdown.value = calidad;

        RevisarResoluciones();
    }

    // Metodo para ajustar el volumen
    public void AjustarVolumen(float volumen)
    {
        Debug.Log(volumen);

        // Convertir el valor del slider (0 a 100) a un rango de 0 a 1
        float volumenNormalizado = volumen / 100f;

        // Establecer el volumen en el AudioListener
        AudioListener.volume = volumenNormalizado;

        // Guardar el valor del volumen
        PlayerPrefs.SetFloat("Volumen", volumenNormalizado);
    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("CalidadGuardada", dropdown.value);
        calidad = dropdown.value;
    }

    public void RevisarResoluciones()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height) {
                
                resolucionActual = i;

            }
        }

        resolucionesDropdown.AddOptions(opciones);
        resolucionesDropdown.value = resolucionActual;
        resolucionesDropdown.RefreshShownValue();

    }


    public void CambiarResolucion(int indiceResolucion)
    {
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }

    // Metodo para cerrar el menu de ajustes
    public void CerrarMenuAjustes()
    {
        if (menuPausa != null)
        {
            menuPausa.ajustesAbierto = false;
        }

        SceneManager.UnloadSceneAsync("MenuAjustes");
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
