using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuAjustes : MonoBehaviour
{
    public AudioMixer audioMixer; // AudioMixer para controlar el volumen
    public Slider sliderVolumen; // Slider para ajustar el volumen
    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal
    [SerializeField] private GameObject GrupoMenuAjustes; // Referencia al Canvas del menu de ajustes
    [SerializeField] private GameObject objetoMenuPausa;


    void Start()
    {
        // Desactivar el GameObject del menu de ajustes al iniciar el juego
        GrupoMenuAjustes.SetActive(false);
        // Obtener el valor actual del volumen y actualizar el slider
        float volumenActual;
        bool resultado = audioMixer.GetFloat("Volumen", out volumenActual);

        if (resultado)
        {
            sliderVolumen.value = volumenActual;
        }
    }

    // Metodo para ajustar el volumen
    public void AjustarVolumen(float volumen)
    {
        Debug.Log(volumen);
        audioMixer.SetFloat("Volumen", volumen); // Establecer el volumen en el AudioMixer
    }

    // Metodo para cerrar el menu de ajustes
    public void CerrarMenuAjustes()
    {
        GrupoMenuAjustes.SetActive(false); // Desactivar el Canvas del menu de ajustes
        if(objetoMenuPausa != null) objetoMenuPausa.SetActive(true);
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
