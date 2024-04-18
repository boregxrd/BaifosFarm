using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesCamara : MonoBehaviour
{
    private Camera camara;

    private void Awake()
    {
        camara = Camera.main;
    }

    public bool ObjetoFueraDeCamara(Vector3 posicionDeObjeto)
    {
        Vector2 posicionObjectoEnPantalla = camara.WorldToScreenPoint(posicionDeObjeto);

        if(posicionObjectoEnPantalla.x < 0 ||
            posicionObjectoEnPantalla.x > camara.pixelWidth ||
            posicionObjectoEnPantalla.y < 0 ||
            posicionObjectoEnPantalla.y > camara.pixelHeight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
