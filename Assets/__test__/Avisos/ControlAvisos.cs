using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAvisos : MonoBehaviour
{
    [SerializeField] private RectTransform avisoHambreRectTransform;

    private void Awake()
    {
        avisoHambreRectTransform = transform.GetChild(0).Find("AvisoHambre").GetComponent<RectTransform>();
        OcultarAvisoHambre();
    }


    public void MostrarAvisoHambre(Vector3 posicionCabra)
    {
        avisoHambreRectTransform.gameObject.SetActive(true);

        Vector3 hasta = posicionCabra;
        Vector3 desde = Camera.main.transform.position;

        desde.z = 0f;

        Vector3 direccion = (hasta - desde).normalized;

        float angulo = (Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg) % 360;

        avisoHambreRectTransform.localEulerAngles = new Vector3(0,0,angulo);
    }

    public void OcultarAvisoHambre()
    {
        avisoHambreRectTransform.gameObject.SetActive(false);
    }
}
