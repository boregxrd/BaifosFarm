using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoDerrota : MonoBehaviour
{
    [SerializeField] private string derrotaSceneName;  // Nombre de la escena de derrota

    private void Start()
    {
        Factura.OnGameOver += LoadDerrotaScene;
    }

    private void OnDestroy()
    {
        Factura.OnGameOver -= LoadDerrotaScene;
    }

    private void LoadDerrotaScene()
    {
        if (!string.IsNullOrEmpty(derrotaSceneName))
        {
            SceneManager.LoadScene(derrotaSceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena de derrota no está asignado.");
        }
    }
}
