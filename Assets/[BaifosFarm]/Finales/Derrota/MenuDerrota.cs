using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDerrota : MonoBehaviour
{
    [SerializeField] GameObject objetoMenuDerrota;
    string NOMBRE_MENU = "Main";

    void Start()
    {
        objetoMenuDerrota.SetActive(false);
        Factura.OnGameOver += MostrarMenuDerrota; // Suscribirse al evento de derrota
    }

    private void OnDestroy()
    {
        Factura.OnGameOver -= MostrarMenuDerrota; // Desuscribirse al destruir el objeto
    }

    void MostrarMenuDerrota()
    {
        objetoMenuDerrota.SetActive(true);
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene(NOMBRE_MENU);
    }
}