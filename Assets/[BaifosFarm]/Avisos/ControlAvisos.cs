using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAvisos : MonoBehaviour
{
    
    private Camera camara;
    private float bordePantalla = 100f;
    private bool generarAvisos = true;

    private Dictionary<Cabra, GameObject> avisosActivos = new Dictionary<Cabra, GameObject>();

    private void Awake()
    {
        camara = Camera.main;
    }

    public void GenerarOActualizarAviso(Cabra cabra, Vector3 posicionCabra, GameObject prefabAviso)
    {
        if (!generarAvisos) return;

        if (avisosActivos.TryGetValue(cabra, out GameObject avisoActual))
        {
            // Verificar si el tipo de aviso actual difiere del nuevo tipo de aviso
            if (avisoActual.tag != prefabAviso.tag)
            {
                Destroy(avisoActual);
                avisoActual = Instantiate(prefabAviso, transform.GetChild(0).GetComponent<RectTransform>());
                avisosActivos[cabra] = avisoActual;
            }
        }
        else
        {
            // No hay aviso existente, crear uno nuevo
            RectTransform targetParent = transform.GetChild(0).GetComponent<RectTransform>();
            avisoActual = Instantiate(prefabAviso, targetParent);
            avisosActivos[cabra] = avisoActual;
        }

        // Actualizar la posición y orientación del aviso
        RectTransform rectTransform = avisoActual.transform.GetChild(0).GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.localScale = Vector3.one;
        rectTransform.localRotation = Quaternion.identity;
        ActualizarAviso(rectTransform, posicionCabra);
    }

    private void ActualizarAviso(RectTransform avisoRectTransform, Vector3 posicionCabra)
    {
        RectTransform flechaAviso = avisoRectTransform.GetChild(0).GetComponent<RectTransform>();

        Vector3 posicionPantalla = camara.WorldToScreenPoint(posicionCabra);
        Vector3 desde = camara.WorldToScreenPoint(camara.transform.position);
        desde.z = 0;

        Vector3 direccion = (posicionPantalla - desde).normalized;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        flechaAviso.localEulerAngles = new Vector3(0, 0, angulo);

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

    public void EsconderTodosLosAvisos()
    {
        generarAvisos = false;

        foreach (var aviso in avisosActivos.Values)
        {
            Destroy(aviso);
        }
        avisosActivos.Clear();
    }
}
