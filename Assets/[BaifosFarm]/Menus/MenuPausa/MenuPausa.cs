using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuAjustes; // Referencia al Canvas del menú de ajustes
    public bool Pausa = false;
    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal

    void Start()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1; //el juego se reanuda
    }

    void Update()
    {

        // Verificar si el menú de ajustes está activo antes de procesar la entrada de la tecla ESC
        if (menuAjustes.activeSelf)
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
        gameObject.SetActive(true);
        Pausa = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0; //el juego se pausa
    }

    public void Reanudar()
    {
        gameObject.SetActive(false);
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
        gameObject.SetActive(false);
        menuAjustes.SetActive(true); // Activar el Canvas del menú de ajustes
    }


    public void CerrarMenuAjustes()
    {
        menuAjustes.SetActive(false); 
    }

    public void IrAlMenu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu); // Cargar la escena del menú de inicio del juego
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
