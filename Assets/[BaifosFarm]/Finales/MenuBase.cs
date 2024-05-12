using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenuBase : MonoBehaviour, IMenu
{
    [SerializeField] protected GameObject menuObject;
    protected string mainMenuSceneName = "Main";

    public virtual void ShowMenu()
    {
        if (menuObject != null)
        {
            menuObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public virtual void HideMenu()
    {
        if (menuObject != null)
        {
            menuObject.SetActive(false);
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
}
