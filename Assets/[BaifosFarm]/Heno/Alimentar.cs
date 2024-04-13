using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�������������������������������������������������������SCRIPT ACCI�N ALIMENTAR������������������������������������������������������
//Este script ha de estar en Mano dentro de Personaje

public class Alimentar : MonoBehaviour
{
    [SerializeField] ControladorAccionesPersonaje controladorAccionesPersonaje;

    [SerializeField] private BarraAlimento barraAlimento;

    [SerializeField] private float incremento = 25f;

    //JUAN 
    public bool powerUpAlimento = true;//set this to false
    private void Awake()
    {
        enabled = false;
        if (powerUpAlimento)
        {
            incremento = 50f;
        }
        else{
            incremento = 25f;
        }
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
