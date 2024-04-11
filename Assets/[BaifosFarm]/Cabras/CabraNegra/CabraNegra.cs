using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabraNegra : MonoBehaviour
{
    public void MuerteDeCabraNegra()
    {
        Quaternion rotacion = transform.rotation;

        if (Quaternion.Euler(0, 0, 90) != rotacion)
        {
            transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        }
    }
}
