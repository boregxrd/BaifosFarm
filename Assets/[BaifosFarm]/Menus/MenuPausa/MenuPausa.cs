using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//·······················································SCRIPT MENÚ PAUSA······················································
//Este script ha de estar en CanvasPausa

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject objetoMenuPausa;
    [SerializeField] private bool Pausa = false;


    void Start()
    {
        objetoMenuPausa.SetActive(false);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pausa == false)
            {
                Pausar();
            }
            else
            {
                Reanudar();
            }
        }
    }

    public void Pausar()
    {
        objetoMenuPausa.SetActive(true);
        Pausa = true;

        Time.timeScale = 0; //el juego se pausa

        //para que se vea el cursor del ratón y poder clicar en los botones:
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void Reanudar()
    {
        objetoMenuPausa.SetActive(false);
        Pausa = false;

        Time.timeScale = 1; //el juego se reanuda

        //para que se vea el cursor del ratón y poder clicar en los botones:
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void IrAlMenu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
    }
}
