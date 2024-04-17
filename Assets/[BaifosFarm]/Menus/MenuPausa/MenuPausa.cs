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
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CerrarMenuAjustes(); // Cerrar el menú de ajustes si se pulsa la tecla ESC
            }
            return; // Salir del método Update si el menú de ajustes está activo
        }

        if (Input.GetKeyDown(KeyCode.Escape))
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

        Time.timeScale = 0; //el juego se pausa

        MostrarCursor(); // Mostrar el cursor al pausar el juego
    }

    public void Reanudar()
    {
        objetoMenuPausa.SetActive(false);
        Pausa = false;

        Time.timeScale = 1; //el juego se reanuda

        OcultarCursor(); // Ocultar el cursor al reanudar el juego
    }

    public void AbrirMenuAjustes()
    {
        Debug.Log("AbrirMenuAjustes"); // Log de depuración
        GrupoMenuAjustes.SetActive(true); // Activar el Canvas del menú de ajustes
        
    }


    public void CerrarMenuAjustes()
    {
        GrupoMenuAjustes.SetActive(false); // Desactivar el Canvas del menú de ajustes
        MostrarCursor(); // Mostrar el cursor al cerrar el menú de ajustes
    }

    // Método para mostrar el cursor
    private void MostrarCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Método para ocultar el cursor
    private void OcultarCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void IrAlMenu(string NombreMenu)
    {

        if (NombreMenu == "Ajustes")
        {
            Debug.Log("Nada aqui por ahora");
        }
        else
        {
            SceneManager.LoadScene(NombreMenu); // Cargar la escena del menú de inicio del juego
        }
    }
}
