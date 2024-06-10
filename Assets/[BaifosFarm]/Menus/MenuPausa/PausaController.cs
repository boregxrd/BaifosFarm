using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaController : MonoBehaviour
{
    [SerializeField] MenuPausa menuPausa;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (menuPausa.pausa == false)
            {
                menuPausa.Pausar();
            }
            else if (menuPausa.ComprobarAjustes())
            {
                menuPausa.CerrarMenuAjustes();
            }
            else
            {
                menuPausa.Reanudar();
            }
        }
    }
}
