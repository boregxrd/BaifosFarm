using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenuBase : MonoBehaviour, IMenu
{
    [SerializeField] protected GameObject menuObject;
    protected string mainMenuSceneName = "Main";

    public virtual void ShowMenu()
    {
        Debug.Log("victoria");
        //este menu es el canva, pero lo que esta
        //es el panel que esta dentro del canva,
        //tal vez lo que deba tener el enable es su hijo?
        enabled = true;
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
}
