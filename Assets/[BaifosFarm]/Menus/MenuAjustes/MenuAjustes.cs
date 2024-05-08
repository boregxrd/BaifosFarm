using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuAjustes : MonoBehaviour
{
    public AudioMixer audioMixer; // AudioMixer para controlar el volumen
    public Slider sliderVolumen; // Slider para ajustar el volumen
    [SerializeField] private GameObject GrupoMenuAjustes; // Referencia al Canvas del menu de ajustes


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

    // M�todo para ajustar el volumen
    public void AjustarVolumen(float volumen)
    {
        Debug.Log(volumen);
        audioMixer.SetFloat("Volumen", volumen); // Establecer el volumen en el AudioMixer
    }

    // M�todo para cerrar el menu de ajustes
    public void CerrarMenuAjustes()
    {
        GrupoMenuAjustes.SetActive(false); // Desactivar el Canvas del menu de ajustes
    }
}
