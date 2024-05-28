using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenuBase : MonoBehaviour, IMenu
{
    [SerializeField] protected GameObject menuObject;
    protected string mainMenuSceneName = "Main";

    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal

    public virtual void ShowMenu()
    {
        if (menuObject != null)
        {
            CanvasGroup canvasGroup = menuObject.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1;  // Hacer visible
                canvasGroup.interactable = true;  // Permitir interacci�n
                canvasGroup.blocksRaycasts = true;  // Permitir detecci�n de rayos
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

    public virtual void HideMenu()
    {
        if (menuObject != null)
        {
            menuObject.SetActive(false);
            enabled = false;
        }
    }

    public virtual void ReturnToMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    protected virtual void Start()
    {
        HideMenu();
    }

    protected virtual void OnDestroy()
    {
        HideMenu();
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
