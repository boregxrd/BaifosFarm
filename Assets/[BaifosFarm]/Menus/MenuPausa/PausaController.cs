using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaController : MonoBehaviour
{
    private MenuPausa menuPausa;

    public bool juegoPausado = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!juegoPausado) //Pausar
            {
                
                SceneManager.LoadScene("MenuPausa", LoadSceneMode.Additive);
                juegoPausado = true;
                AudioManager.Instance.PauseMusic();
            }

            else if (juegoPausado) //Reanudar
            {

                menuPausa = FindObjectOfType<MenuPausa>();

                if (menuPausa.ComprobarAjustes()) menuPausa.CerrarMenuAjustes();

                menuPausa.Reanudar();
                AudioManager.Instance.ResumeMusic();
                juegoPausado = false;
            }
        }
    }
}
