using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaController : MonoBehaviour
{
    private MenuPausa menuPausa;
    public bool juegoPausado = false;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!juegoPausado) // Pausar
            {
                SceneManager.LoadScene("MenuPausa", LoadSceneMode.Additive);
                audioManager.PauseMusic();
                juegoPausado = true;
            }
            else if (juegoPausado) // Reanudar
            {
                menuPausa = FindObjectOfType<MenuPausa>();

                if (menuPausa.ComprobarAjustes()) menuPausa.CerrarMenuAjustes();

                menuPausa.Reanudar();
                audioManager.ResumeMusic();
                juegoPausado = false;
            }
        }
    }
}
