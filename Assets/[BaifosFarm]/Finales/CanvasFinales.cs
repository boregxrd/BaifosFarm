using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasFinales : MonoBehaviour
{
    [SerializeField] protected GameObject menuObject;
    protected string mainMenuSceneName = "Main";
    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal

    private void Start() 
    {
        if (menuObject != null)
        {
            CanvasGroup canvasGroup = menuObject.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1;  // Hacer visible
                canvasGroup.interactable = true;  // Permitir interaccion
                canvasGroup.blocksRaycasts = true;  // Permitir deteccion de rayos
            }
            menuObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Debug.Log("menuobject es null");
        }
    }

    public virtual void ReturnToMenu()
    {
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
