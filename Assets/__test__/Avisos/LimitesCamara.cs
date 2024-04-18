using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesCamara : MonoBehaviour
{
    private Camera camara;
    private float bordePantalla = 30f;

    private void Awake()
    {
        camara = Camera.main;
    }

    public bool ObjetoFueraDeCamara(Vector3 posicionDeObjeto)
    {
        Vector2 posicionObjectoEnPantalla = camara.WorldToScreenPoint(posicionDeObjeto);

        if(posicionObjectoEnPantalla.x < bordePantalla ||
            posicionObjectoEnPantalla.x > camara.pixelWidth - bordePantalla ||
            posicionObjectoEnPantalla.y < bordePantalla ||
            posicionObjectoEnPantalla.y > camara.pixelHeight - bordePantalla)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
