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

    public IEnumerator EmpezarMovimientoCamion()
    {
        enMovimiento = true;
        while (enMovimiento)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
    }

    private void verificarLlegada()
    {
        if (Vector3.Distance(transform.position, destinoCamion) < 0.1f)  
        {
            enMovimiento = false;
        }
    }

    void Update()
    {
        if (enMovimiento)
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
