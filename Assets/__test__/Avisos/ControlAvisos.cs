using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAvisos : MonoBehaviour
{
    
    private Camera camara;
    private float bordePantalla = 100f;

    private Dictionary<Cabra, GameObject> avisosActivos = new Dictionary<Cabra, GameObject>();

    private void Awake()
    {
        camara = Camera.main;
    }

    public void GenerarOActualizarAviso(Cabra cabra, Vector3 posicionCabra, GameObject prefabAviso)
    {
        if (!avisosActivos.TryGetValue(cabra, out GameObject aviso))
        {
            RectTransform targetParent = transform.GetChild(0).GetComponent<RectTransform>();
            aviso = Instantiate(prefabAviso, targetParent);
            avisosActivos[cabra] = aviso;
        }

        RectTransform rectTransform = aviso.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.localScale = Vector3.one;
        rectTransform.localRotation = Quaternion.identity;
        ActualizarAviso(rectTransform, posicionCabra);
    }


    private void ActualizarAviso(RectTransform avisoRectTransform, Vector3 posicionCabra)
    {
        Vector3 posicionPantalla = camara.WorldToScreenPoint(posicionCabra);
        Vector3 desde = camara.WorldToScreenPoint(camara.transform.position);
        desde.z = 0;

        Vector3 direccion = (posicionPantalla - desde).normalized;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        avisoRectTransform.localEulerAngles = new Vector3(0, 0, angulo);

        LimitarPosicionAviso(avisoRectTransform, posicionCabra);
    }

    private void LimitarPosicionAviso(RectTransform avisoRectTransform, Vector3 posicionObjetivo)
    {
        Vector3 posicionPantalla = camara.WorldToScreenPoint(posicionObjetivo);

        if (posicionPantalla.x < bordePantalla) posicionPantalla.x = bordePantalla;
        if (posicionPantalla.x > Screen.width - bordePantalla) posicionPantalla.x = Screen.width - bordePantalla;
        if (posicionPantalla.y < bordePantalla) posicionPantalla.y = bordePantalla;
        if (posicionPantalla.y > Screen.height - bordePantalla) posicionPantalla.y = Screen.height - bordePantalla;

        avisoRectTransform.position = posicionPantalla;
    }

    public void DestruirAviso(Cabra cabra)
    {
        if (avisosActivos.TryGetValue(cabra, out GameObject aviso))
        {
            Destroy(aviso);
            avisosActivos.Remove(cabra);
        }
    }
}
