using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//·······················································SCRIPT ACCIÓN ALIMENTAR······················································
//Este script ha de estar en Mano dentro de Personaje

public class Alimentar : MonoBehaviour
{
    [SerializeField] ControladorAccionesPersonaje controladorAccionesPersonaje;

    [SerializeField] private BarraAlimento barraAlimento;

    [SerializeField] private float incremento = 25f;

    private void Awake()
    {
        enabled = false;
    }

    public void DarComida(Collider other)
    {
        var children = other.gameObject.GetComponentsInChildren<Transform>(); //dentro de la cabra busco el objeto barraAlimento y luego su script
        foreach (var child in children)
        {
            if (child.name == "BarraAlimentos")
            {
                barraAlimento = child.GetComponent<BarraAlimento>();
                barraAlimento.incrementarNivelAlimentacion(incremento);
            }
        }
    }
}
