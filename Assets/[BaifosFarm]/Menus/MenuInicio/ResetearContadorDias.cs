using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetearContadorDias : MonoBehaviour
{
    [SerializeField] ContadorDias contadorDias;

    private void Start()
    {
        contadorDias = FindObjectOfType<ContadorDias>();

        if(contadorDias != null)
        {
            contadorDias.ResetearContadorDias();
        }
    }

}
