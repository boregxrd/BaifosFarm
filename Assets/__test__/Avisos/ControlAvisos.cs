using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAvisos : MonoBehaviour
{
    [SerializeField] private RectTransform avisoHambreRectTransform;
    private Camera camara;
    private float bordePantalla = 100f;

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

        if (posicionPantalla.x < bordePantalla) posicionPantalla.x = bordePantalla;
        if (posicionPantalla.x > Screen.width - bordePantalla) posicionPantalla.x = Screen.width - bordePantalla;
        if (posicionPantalla.y < bordePantalla) posicionPantalla.y = bordePantalla;
        if (posicionPantalla.y > Screen.height - bordePantalla) posicionPantalla.y = Screen.height - bordePantalla;

        avisoHambreRectTransform.position = posicionPantalla;
    }
}
