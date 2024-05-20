using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopUpsFacturaTutorial : MonoBehaviour
{
    public GameObject[] popUps; // Array de pop-ups
    public Button okButton; // Bot�n de OK que ser� asignado en el inspector

    private bool isButtonClicked = false; // Flag para saber si el bot�n ha sido clicado

    private void Start()
    {
        // Asegurarse de que el bot�n est� desactivado al inicio
        //okButton.gameObject.SetActive(false);
        okButton.onClick.AddListener(OnOkButtonClicked);
    }

    // M�todo que maneja la acci�n del bot�n OK
    private void OnOkButtonClicked()
    {
        isButtonClicked = true; // Marcar que el bot�n ha sido clicado
        okButton.gameObject.SetActive(false); // Ocultar el bot�n OK
    }

    // Coroutine que maneja cada pop-up individualmente
    private IEnumerator HandlePopUp(GameObject popUp)
    {
        isButtonClicked = false; // Resetear el flag del bot�n clicado
        popUp.SetActive(true); // Mostrar el pop-up
        okButton.gameObject.SetActive(true); // Mostrar el bot�n OK

        Debug.Log($"Mostrado pop-up: {popUp.name}");

        // Esperar hasta que el bot�n OK se haya clicado
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

    // M�todo para ocultar todos los pop-ups
    public void HidePopUps()
    {
        foreach (var popup in popUps)
        {
            popup.SetActive(false);
        }
        okButton.gameObject.SetActive(false); // Asegurarse de que el bot�n OK est� desactivado
    }
}
