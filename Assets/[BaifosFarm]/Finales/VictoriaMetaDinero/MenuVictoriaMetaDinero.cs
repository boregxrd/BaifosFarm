using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoriaMetaDinero : MonoBehaviour
{
    [SerializeField] GameObject objetoMenuVictoria;
    string NOMBRE_MENU = "Main";

    void Start()
    {
        objetoMenuVictoria.SetActive(false);
        Factura.OnMoneyVictory += MostrarMenuVictoria;
    }

    private void OnDestroy()
    {
        Factura.OnGameOver -= MostrarMenuVictoria; 
    }

    void MostrarMenuVictoria()
    {
        if (objetoMenuVictoria != null)
        {
            objetoMenuVictoria.SetActive(true);
        }
        else
        {
            Debug.LogWarning("objetoMenuVictoria es nulo.");
        }
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(NOMBRE_MENU);
    }
}
