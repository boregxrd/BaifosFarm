using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDerrota : MonoBehaviour
{
    [SerializeField] GameObject objetoMenuDerrota;
    string NOMBRE_MENU = "Main";

    void Start()
    {
        objetoMenuDerrota.SetActive(false);
        Factura.OnGameOver += MostrarMenuDerrota; 
    }

    private void OnDestroy()
    {
        Factura.OnGameOver -= MostrarMenuDerrota;
    }

    void MostrarMenuDerrota()
    {
        if(objetoMenuDerrota != null)
        {
            objetoMenuDerrota.SetActive(true);
        }
        else
        {
            Debug.LogWarning("objetoMenuDerrota es nulo.");
        }
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(NOMBRE_MENU);
    }
}