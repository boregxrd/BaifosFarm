using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlegadaCamión : MonoBehaviour
{
    public Vector3 destinoCamion = new Vector3(-6, 0, 17);
    [SerializeField] public float velocidadCamion = 5f;
    public Camera camara;
    public GameObject personaje;
    [SerializeField] public float velocidadRotacionCamara = 5f;

    private bool enMovimiento = false;

    private void OnEnable()
    {
        empezarMovimientoCamion();
    }

    public void empezarMovimientoCamion()
    {
        enMovimiento = true;

        Character scriptMovimiento = personaje.GetComponent<Character>();
        if (scriptMovimiento != null) scriptMovimiento.enabled = false;
        else Debug.LogWarning("scriptMovimiento null");
    }

    // Update is called once per frame
    void Update()
    {
        if (enMovimiento == true)
        {
            float avance = velocidadCamion * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destinoCamion, avance);

            if (camara != null)
            {
                Vector3 direccion = destinoCamion - camara.transform.position;
                Quaternion rotacion = Quaternion.LookRotation(direccion);
                camara.transform.rotation = Quaternion.Slerp(camara.transform.rotation, rotacion, velocidadRotacionCamara * Time.deltaTime);
            }
        }
    }
}
