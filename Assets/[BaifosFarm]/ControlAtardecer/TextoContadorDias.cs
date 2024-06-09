using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoContadorDias : MonoBehaviour
{
    private Text txtContadorDias;
    private ContadorDias contadorDias;

    private int contador;

    private void Start()
    {
        txtContadorDias = GetComponent<Text>();
        contadorDias = FindObjectOfType<ContadorDias>();

        contador = contadorDias.Contador;
        ActualizarContadorDias(contador);
    }

    private void ActualizarContadorDias(int numero)
    {
        txtContadorDias.text = "Día " + numero.ToString();
    }

}
