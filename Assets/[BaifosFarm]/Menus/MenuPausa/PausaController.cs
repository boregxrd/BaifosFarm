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
                Time.timeScale = 0;
                SceneManager.LoadScene("MenuPausa", LoadSceneMode.Additive);
                juegoPausado = true;
            }

            else if (juegoPausado) //Reanudar
            {
                Time.timeScale = 1; //el juego se reanuda

                menuPausa = FindObjectOfType<MenuPausa>();

                if (menuPausa.ComprobarAjustes()) menuPausa.CerrarMenuAjustes();

                menuPausa.Reanudar();
                juegoPausado = false;
            }
        }
    }
}
