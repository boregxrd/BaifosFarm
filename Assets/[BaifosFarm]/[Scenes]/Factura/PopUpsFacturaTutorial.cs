using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopUpsFacturaTutorial : MonoBehaviour
{
    public GameObject[] popUps; // Array de pop-ups
    public Button okButton; // Botón de OK que será asignado en el inspector

    private bool isButtonClicked = false; // Flag para saber si el botón ha sido clicado

    private void Start()
    {
        // Asegurarse de que el botón esté desactivado al inicio
        //okButton.gameObject.SetActive(false);
        okButton.onClick.AddListener(OnOkButtonClicked);
    }

    // Método que maneja la acción del botón OK
    private void OnOkButtonClicked()
    {
        isButtonClicked = true; // Marcar que el botón ha sido clicado
        okButton.gameObject.SetActive(false); // Ocultar el botón OK
    }

    // Coroutine que maneja cada pop-up individualmente
    private IEnumerator HandlePopUp(GameObject popUp)
    {
        isButtonClicked = false; // Resetear el flag del botón clicado
        popUp.SetActive(true); // Mostrar el pop-up
        okButton.gameObject.SetActive(true); // Mostrar el botón OK

        Debug.Log($"Mostrado pop-up: {popUp.name}");

        // Esperar hasta que el botón OK se haya clicado
        yield return new WaitUntil(() => isButtonClicked);

        popUp.SetActive(false); // Ocultar el pop-up

        Debug.Log($"Ocultado pop-up: {popUp.name}");
    }

    // Coroutine que muestra todos los pop-ups en secuencia
    public IEnumerator ShowPopUps()
    {
        okButton.gameObject.SetActive(true);
        foreach (GameObject popUp in popUps)
        {
            yield return StartCoroutine(HandlePopUp(popUp));
        }
        PlayerPrefs.SetInt("TutorialCompleto", 1); // Marcar el tutorial como completado
    }

    // Método para ocultar todos los pop-ups
    public void HidePopUps()
    {
        foreach (var popup in popUps)
        {
            popup.SetActive(false);
        }
        okButton.gameObject.SetActive(false); // Asegurarse de que el botón OK esté desactivado
    }
}
