using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    PausaController pausaController;
    MenuAjustes menuAjustes;
    Animator animator;

    public bool pausa = false;
    public bool ajustesAbierto = false;
    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal


    void Start()
    {
        Time.timeScale = 0;
        pausaController = FindObjectOfType<PausaController>();
        animator = GetComponent<Animator>();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void Reanudar()
    {
        pausaController.juegoPausado = false;
        AudioManager.Instance.ResumeMusic();
        if (PlayerPrefs.GetInt("TutorialCompleto") == 1)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        animator.SetTrigger("Cerrar");
    }

    public void AcabaAnimacionCerrarMenuPausa()
    {
        Time.timeScale = 1; 
        SceneManager.UnloadSceneAsync("MenuPausa");
    }

    public bool ComprobarAjustes()
    {
        if (ajustesAbierto) return true;
        else return false;
    }

    public void AbrirMenuAjustes()
    {
        SceneManager.LoadScene("MenuAjustes", LoadSceneMode.Additive);
        ajustesAbierto = true;
    }

    public void CerrarMenuAjustes()
    {
        menuAjustes = FindObjectOfType<MenuAjustes>();
        menuAjustes.CerrarMenuAjustes();
        ajustesAbierto = false;
    }

    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1;
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
