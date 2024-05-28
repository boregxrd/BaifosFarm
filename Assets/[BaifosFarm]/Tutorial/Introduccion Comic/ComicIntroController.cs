using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ComicIntroController : MonoBehaviour
{
    public Image[] comicImages; // Array de im�genes del c�mic
    public Button continueButton; // Bot�n de continuar

    private bool isRunning = true;
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
        continueButton.gameObject.SetActive(true);
        foreach (Image image in comicImages)
        {
            if (!isRunning) // Si isRunning es falso, detener la corutina
                yield break;

            image.gameObject.SetActive(true);

            if (currentIndex == 6)
            {
                continueButton.GetComponentInChildren<Text>().text = "Empezar";
            }

            yield return new WaitForSecondsRealtime(3f); // Esperar 3 segundos
            currentIndex++; // Avanzar al siguiente índice
        }
    }

    // Método llamado por el botón de continuar
    public void OnContinueButtonClicked()
    {
        Debug.Log("Botón de continuar pulsado");

        isRunning = false; // Detener la corutina

        // Ocultar todas las imágenes y el botón de continuar
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
