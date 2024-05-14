using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject objetoMenuPausa;
    [SerializeField] private GameObject GrupoMenuAjustes; // Referencia al Canvas del menú de ajustes
    public bool Pausa = false;

    void Start()
    {
        objetoMenuPausa.SetActive(false);
        GrupoMenuAjustes.SetActive(false); // Desactivar el Canvas del menú de ajustes al iniciar
    }

    void Update()
    {

        // Verificar si el menú de ajustes está activo antes de procesar la entrada de la tecla ESC
        if (GrupoMenuAjustes.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                CerrarMenuAjustes(); // Cerrar el menú de ajustes si se pulsa la tecla ESC
            }
            return; // Salir del método Update si el menú de ajustes está activo
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Pausa == false)
            {
                Pausar();
            }
            else
            {
                Reanudar();
            }
        }
    }

    public void Pausar()
    {
        objetoMenuPausa.SetActive(true);
        Pausa = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0; //el juego se pausa
    }

    public void Reanudar()
    {
        objetoMenuPausa.SetActive(false);
        Pausa = false;
        if(PlayerPrefs.GetInt("TutorialCompleto") == 1){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        Time.timeScale = 1; //el juego se reanuda

    }

    public void AbrirMenuAjustes()
    {
        Debug.Log("AbrirMenuAjustes"); // Log de depuración
        objetoMenuPausa.SetActive(false);
        GrupoMenuAjustes.SetActive(true); // Activar el Canvas del menú de ajustes
    }


    public void CerrarMenuAjustes()
    {
        GrupoMenuAjustes.SetActive(false); 
    }

    public void IrAlMenu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu); // Cargar la escena del menú de inicio del juego
    }
}
