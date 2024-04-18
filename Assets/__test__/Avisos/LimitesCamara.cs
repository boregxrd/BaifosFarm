using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesCamara : MonoBehaviour
{
    private Camera camara;
    private Vector3 transform = new Vector3(-10.84658f, 9.536743e-07f, -11.00915f);

    private void Awake()
    {
        camara = Camera.main;
    }

    private void Update()
    {
        bool indicador = ObjetoFueraDeCamara(transform);
        Debug.Log(indicador);
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
