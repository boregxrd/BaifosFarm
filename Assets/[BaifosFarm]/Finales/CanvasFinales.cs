using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFinales : MonoBehaviour
{
    protected string mainMenuSceneName = "Main";
    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal

    [SerializeField] Transicion transicion;

    private void Start()
    {
        transicion.FadeIn();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ReturnToMenu()
    {
        transicion.FadeOut();
        Debug.Log("Attempting to load scene: " + mainMenuSceneName);
        SceneManager.LoadScene(mainMenuSceneName);
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
