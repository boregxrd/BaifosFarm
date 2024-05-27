using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de tener esta directiva

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public ParticleSystem[] particleEffects; // Efectos de partículas para cada paso

    private int popUpIndex;
    [SerializeField] private ManejarHeno manejarHeno;
    [SerializeField] private DejarLecheEnCaja dejarLecheEnCaja;
    [SerializeField] private Character movimientoPersonaje;
    [SerializeField] private Jugador jugador;
    [SerializeField] private ManejarLeche manejarLeche;

    private Temporizador temporizador;
    public Button botonSkip;
    public GameObject CanvasSkipTutorial;

    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal

    private void Awake()
    {
        temporizador = FindObjectOfType<Temporizador>(); // Obtener referencia a ControlTiempo en la escena
    }

    public void IniciarTutorial()
    {
        if (PlayerPrefs.GetInt("TutorialCompleto") == 0)
        {
            ShowNextPopUp();
            CanvasSkipTutorial.SetActive(true);
            botonSkip.interactable = true;
        }
        else if (PlayerPrefs.GetInt("TutorialCompleto") == 1)
        {
            CanvasSkipTutorial.SetActive(false);
            botonSkip.interactable = false;
            // Ocultar todos los pop-ups
            foreach (var popup in popUps)
            {
                popup.SetActive(false);
            }
            // Ocultar todos los efectos de partículas
            foreach (var particles in particleEffects)
            {
                particles.Stop(); // Detiene la emisión de partículas
            }
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("TutorialCompleto") == 0)
        {
            CheckCompletion();
        }
    }

    private void ShowNextPopUp()
    {
        // Ocultar todos los pop-ups al inicio
        foreach (var popUp in popUps)
        {
            popUp.SetActive(false);
        }
        // Desactivar los efectos de partículas al inicio
        foreach (var effect in particleEffects)
        {
            effect.Stop();
        }

        if (popUpIndex < popUps.Length)
        {
            // Activar el efecto de partículas correspondiente
            particleEffects[popUpIndex].Play();

            // Mostrar el pop-up
            popUps[popUpIndex].SetActive(true);
            Debug.Log($"Mostrando pop-up {popUpIndex + 1}"); // Mensaje de depuración
        }
        else
        {
            PlayerPrefs.SetInt("TutorialCompleto", 1); // Marcar el tutorial como completado
            Debug.Log("Tutorial completado");
        }
    }

    private void CheckCompletion()
    {
        StartCoroutine(DelayBeforeCheck());
    }

    private IEnumerator DelayBeforeCheck()
    {
        // Esperar 2 segundos
        yield return new WaitForSeconds(3f);

        // Verificar si el tutorial ha sido completado antes de continuar
        if (PlayerPrefs.GetInt("TutorialCompleto") == 1)
        {
            yield break; // Salir de la corrutina si el tutorial está completado
        }

        switch (popUpIndex)
        {
            case 0: // Movimiento
                if (movimientoPersonaje.HasMoved())
                {
                    CompleteStep();
                    Debug.Log("Movimiento completado");
                }
                break;

            case 1: // Recoger Heno
                if (jugador.HenoRecogido)
                {
                    CompleteStep();
                    Debug.Log("Recoger Heno completado");
                }
                break;

            case 2: // Alimentar
                if (manejarHeno.alimentacionRealizada)
                {
                    CompleteStep();
                    Debug.Log("Alimentar completado");
                }
                break;

            case 3: // Recoger Leche
                if (manejarLeche.ordenyoRealizado)
                {
                    CompleteStep();
                    Debug.Log("Recoger Leche completado");
                }
                break;

            case 4: // Guardar Leche
                if (dejarLecheEnCaja.lecheGuardada)
                {
                    CompleteStep();
                    Debug.Log("Guardar Leche completado");
                }
                break;

            default:
                break;
        }
    }

    private void CompleteStep()
    {
        // Detener el efecto de partículas actual
        particleEffects[popUpIndex].Stop();

        // Pasar al siguiente pop-up
        NextPopUp();
    }

    private void NextPopUp()
    {
        // Ocultar el pop-up actual
        popUps[popUpIndex].SetActive(false);

        // Incrementar el índice del pop-up
        popUpIndex++;

        // Mostrar el siguiente pop-up
        ShowNextPopUp();
    }

    public void SkipTutorial()
    {
        PlayerPrefs.SetInt("TutorialCompleto", 1); // Marcar el tutorial como completado
        Debug.Log("Tutorial completado");
        CanvasSkipTutorial.SetActive(false);
        botonSkip.interactable = false;
        // Ocultar todos los pop-ups
        foreach (var popup in popUps)
        {
            popup.SetActive(false);
        }
        // Ocultar todos los efectos de partículas
        foreach (var particles in particleEffects)
        {
            particles.Stop(); // Detiene la emisión de partículas
        }
        Debug.Log("Tutorial completado, pop-ups ocultos");
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
