using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComicIntroController : MonoBehaviour
{
    public Image[] comicImages; // Array de imágenes del cómic
    public Button continueButton; // Botón de continuar

    private int currentIndex = 0; // Índice actual de la imagen mostrada

    private void Start()
    {
        // Desactivar el botón de continuar al inicio
        continueButton.gameObject.SetActive(false);

        // Mostrar el puntero del ratón al inicio
        //Cursor.visible = true;

        if (PlayerPrefs.GetInt("TutorialCompleto") == 0) 
        { 
            // Iniciar la secuencia de mostrar imágenes del cómic
            StartCoroutine(ShowComicSequence());
        }
    }

    // Método para mostrar la secuencia de imágenes del cómic
    private IEnumerator ShowComicSequence()
    {
        Time.timeScale = 0f; // Pausar el tiempo del juego

        foreach (Image image in comicImages)
        {
            // Mostrar la imagen actual del cómic
            image.gameObject.SetActive(true);
            Debug.Log($"Mostrada la imagen {currentIndex + 1}");

            if (currentIndex == 3)
            {
                // Mostrar el botón de continuar junto con la cuarta imagen
                continueButton.gameObject.SetActive(true);
                Debug.Log("Mostrando botón de continuar");

                // Ocultar el puntero del ratón al mostrar el botón de continuar
                //Cursor.visible = false;
            }

            yield return new WaitForSecondsRealtime(3f); // Esperar 3 segundos

            currentIndex++; // Avanzar al siguiente índice
        }

        // Mostrar el puntero del ratón cuando se completa la secuencia del cómic
        //Cursor.visible = true;
    }

    // Método llamado por el botón de continuar
    public void OnContinueButtonClicked()
    {
        Debug.Log("Botón de continuar pulsado");

        // Ocultar todas las imágenes y el botón de continuar
        foreach (Image image in comicImages)
        {
            image.gameObject.SetActive(false);
        }
        continueButton.gameObject.SetActive(false);

        Time.timeScale = 1f; // Reanudar el tiempo del juego
    }
}
