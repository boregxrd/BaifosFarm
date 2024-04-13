using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�������������������������������������������������������SCRIPT MEN� PAUSA������������������������������������������������������
//Este script ha de estar en CanvasPausa

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject objetoMenuPausa;
    public bool Pausa = false;


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

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void Reanudar()
    {
        objetoMenuPausa.SetActive(false);
        Pausa = false;

        Time.timeScale = 1; //el juego se reanuda

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void IrAlMenu(string NombreMenu)
    { 
        if(NombreMenu == "Ajustes")
        {
            Debug.Log("no se ha creado pantalla de ajustes aún");
        }
        else
        {
            SceneManager.LoadScene(NombreMenu);
        }
    }
}
