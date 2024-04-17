using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuAjustes : MonoBehaviour
{
    public AudioMixer audioMixer; // AudioMixer para controlar el volumen
    public Slider sliderVolumen; // Slider para ajustar el volumen

    void Start()
    {
        // Desactivar el GameObject del menú de ajustes al iniciar el juego

        // Obtener el valor actual del volumen y actualizar el slider
        float volumenActual;
        bool resultado = audioMixer.GetFloat("Volumen", out volumenActual);

        if (resultado)
        {
            sliderVolumen.value = volumenActual;
        }
    }

    // Método para ajustar el volumen
    public void AjustarVolumen(float volumen)
    {
        Debug.Log(volumen);
        audioMixer.SetFloat("Volumen", volumen); // Establecer el volumen en el AudioMixer
    }
}
