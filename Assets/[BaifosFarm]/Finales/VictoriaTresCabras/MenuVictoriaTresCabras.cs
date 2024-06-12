using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoriaTresCabras : MonoBehaviour
{
    [SerializeField] private string victoriaTresCabrasSceneName; 
    private void Start()
    {
        DeteccionCabrasNegras.OnThreeBlackGoatsVictory += LoadVictoriaTresCabrasScene;
    }

    private void OnDestroy()
    {
        DeteccionCabrasNegras.OnThreeBlackGoatsVictory -= LoadVictoriaTresCabrasScene;
    }

    private void LoadVictoriaTresCabrasScene() 
    {
        if (!string.IsNullOrEmpty(victoriaTresCabrasSceneName))
        {
            SceneManager.LoadScene(victoriaTresCabrasSceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena de victoriaTresCabras no está asignado.");
        }
    }
    
}
