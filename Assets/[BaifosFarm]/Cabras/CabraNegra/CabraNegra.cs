using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabraNegra : MonoBehaviour
{
    [SerializeField] GameObject objetoControlTiempo;
    [SerializeField] ControlTiempo controlTiempo;

    private void Start()
    {
        objetoControlTiempo = GameObject.Find("CanvasTiempo");
        controlTiempo = objetoControlTiempo.GetComponentInChildren<ControlTiempo>();
    }

    public void MuerteDeCabraNegra()
    {
        if (Quaternion.Euler(0, 0, 90) != transform.rotation)
        {
            transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        }
    }

    public void DestruirCabrasNegrasMuertas()
    {
        if(Quaternion.Euler(0, 0, 90) == transform.rotation && controlTiempo.tiempoRestante < 1f)
            {
                Debug.Log("cabraNegraDestruida");
                Destroy(gameObject);
            }
    }

}
