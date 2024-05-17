using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComicIntroController : MonoBehaviour
{
    public Image[] comicImages; // Array de im�genes del c�mic
    public Button continueButton; // Bot�n de continuar

    private int currentIndex = 0; // �ndice actual de la imagen mostrada

    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal
    private void Start()
    {
        // Desactivar el bot�n de continuar al inicio
        continueButton.gameObject.SetActive(false);

        // Mostrar el puntero del rat�n al inicio
        //Cursor.visible = true;

        if (PlayerPrefs.GetInt("TutorialCompleto") == 0) 
        { 
            // Iniciar la secuencia de mostrar im�genes del c�mic
            StartCoroutine(ShowComicSequence());
        }
    }

    // M�todo para mostrar la secuencia de im�genes del c�mic
    private IEnumerator ShowComicSequence()
    {
        Time.timeScale = 0f; // Pausar el tiempo del juego

        foreach (Image image in comicImages)
        {
            // Mostrar la imagen actual del c�mic
            image.gameObject.SetActive(true);
            //Debug.Log($"Mostrada la imagen {currentIndex + 1}");

            if (currentIndex == 3)
            {
                // Mostrar el bot�n de continuar junto con la cuarta imagen
                continueButton.gameObject.SetActive(true);
                //Debug.Log("Mostrando bot�n de continuar");

                // Ocultar el puntero del rat�n al mostrar el bot�n de continuar
                //Cursor.visible = false;
            }

            yield return new WaitForSecondsRealtime(3f); // Esperar 3 segundos

            currentIndex++; // Avanzar al siguiente �ndice
        }

        // Mostrar el puntero del rat�n cuando se completa la secuencia del c�mic
        //Cursor.visible = true;
    }

    // M�todo llamado por el bot�n de continuar
    public void OnContinueButtonClicked()
    {
        Debug.Log("Bot�n de continuar pulsado");

        // Ocultar todas las im�genes y el bot�n de continuar
        foreach (Image image in comicImages)
        {
            image.gameObject.SetActive(false);
        }
        continueButton.gameObject.SetActive(false);

        Time.timeScale = 1f; // Reanudar el tiempo del juego
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
