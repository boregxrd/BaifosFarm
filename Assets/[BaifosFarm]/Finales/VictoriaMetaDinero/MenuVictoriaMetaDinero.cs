using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoriaMetaDinero : MonoBehaviour
{
    [SerializeField] private string victoriaSceneName; 
    private void Start()
    {
        Factura.OnMoneyVictory += LoadVictoriaTresCabrasScene;
    }

    private void OnDestroy()
    {
        Factura.OnMoneyVictory -= LoadVictoriaTresCabrasScene;
    }

    private void LoadVictoriaTresCabrasScene() 
    {
        if (!string.IsNullOrEmpty(victoriaSceneName))
        {
            SceneManager.LoadScene(victoriaSceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena de victoria no está asignado.");
        }
    }
}

