using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Camion : MonoBehaviour
{
    public Vector3 destinoCamion = new Vector3(-6, 0, 17);
    [SerializeField] public float velocidadCamion = 5f;
    public Camera camara;
    [SerializeField] public float velocidadRotacionCamara = 5f;

    public bool enMovimiento = false;

    public void empezarMovimientoCamion()
    {
        enMovimiento = true;
    }

    void verificarLlegada()
    {
        Vector3 posActual = transform.position;

        if (posActual == destinoCamion)
        {
            enMovimiento = false;
        }
    }

    void Update()
    {
        if (enMovimiento == true)
        {
            float avance = velocidadCamion * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destinoCamion, avance);

            if (camara != null)
            {
                Vector3 direccion = transform.position - camara.transform.position;
                Quaternion rotacion = Quaternion.LookRotation(direccion);
                camara.transform.rotation = Quaternion.Slerp(camara.transform.rotation, rotacion, velocidadRotacionCamara * Time.deltaTime);
            }

            verificarLlegada();
        }
    }
}
