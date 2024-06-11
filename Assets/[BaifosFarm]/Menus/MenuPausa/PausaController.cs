using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaController : MonoBehaviour
{
    [SerializeField] MenuPausa menuPausa;

    public bool juegoPausado = false;

    
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (menuPausa.pausa == false)
            {
                menuPausa.Pausar();
            }
            else if (menuPausa.ComprobarAjustes())
            {
                menuPausa.CerrarMenuAjustes();
                menuPausa.Reanudar();
            }
            else
            {
                menuPausa.Reanudar();
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!juegoPausado) //Pausar
            {
                SceneManager.LoadScene("MenuPausa", LoadSceneMode.Additive);
                juegoPausado=true;
            }

            else if(juegoPausado) //Reanudar
            {
                menuPausa = FindObjectOfType<MenuPausa>();

                if (menuPausa.ComprobarAjustes()) menuPausa.CerrarMenuAjustes();
                
                menuPausa.Reanudar();
                juegoPausado = false;
            }
        }
    }
}
