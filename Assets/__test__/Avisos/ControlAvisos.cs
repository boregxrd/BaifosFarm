using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAvisos : MonoBehaviour
{
    [SerializeField] private RectTransform avisoHambreRectTransform;
    private Camera camara;

    private void Awake()
    {
        avisoHambreRectTransform = transform.GetChild(0).Find("AvisoHambre").GetComponent<RectTransform>();
        OcultarAvisoHambre();
        camara = Camera.main;
    }


    public void MostrarAvisoHambre(Vector3 posicionCabra)
    {
        avisoHambreRectTransform.gameObject.SetActive(true);

        Vector3 posicionPantalla = camara.WorldToScreenPoint(posicionCabra);
        Vector3 desde = camara.WorldToScreenPoint(camara.transform.position);
        desde.z = 0;

        Vector3 direccion = (posicionPantalla - desde).normalized;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        avisoHambreRectTransform.localEulerAngles = new Vector3(0, 0, angulo);

        LimitarPosicionAviso(posicionCabra);
    }

    public void OcultarAvisoHambre()
    {
        avisoHambreRectTransform.gameObject.SetActive(false);
    }

    private void LimitarPosicionAviso(Vector3 posicionObjetivo)
    {
        Vector3 posicionPantalla = camara.WorldToScreenPoint(posicionObjetivo);

        if (posicionPantalla.x < 0) posicionPantalla.x = 0;
        if (posicionPantalla.x > Screen.width) posicionPantalla.x = Screen.width;
        if (posicionPantalla.y < 0) posicionPantalla.y = 0;
        if (posicionPantalla.y > Screen.height) posicionPantalla.y = Screen.height;

        avisoHambreRectTransform.position = posicionPantalla;
    }
}
