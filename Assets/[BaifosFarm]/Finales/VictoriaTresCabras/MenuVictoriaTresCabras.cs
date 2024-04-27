using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoriaTresCabras : MonoBehaviour
{
    [SerializeField] GameObject objetoMenuVictoriaTresCabras;
    string NOMBRE_MENU = "Main";

    void Start()
    {
        objetoMenuVictoriaTresCabras.SetActive(false);
        ControlTiempo.OnThreeBlackGoatsVictory += MostrarMenuVictoriaTresCabras;
    }

    private void OnDestroy()
    {
        ControlTiempo.OnThreeBlackGoatsVictory -= MostrarMenuVictoriaTresCabras;
    }

    void MostrarMenuVictoriaTresCabras()
    {
        if (objetoMenuVictoriaTresCabras != null)
        {
            objetoMenuVictoriaTresCabras.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Debug.LogWarning("objetoMenuVictoriaTresCabras es nulo.");
        }
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(NOMBRE_MENU);
    }
}
