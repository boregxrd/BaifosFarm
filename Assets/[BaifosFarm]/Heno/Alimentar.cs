using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�������������������������������������������������������SCRIPT ACCI�N ALIMENTAR������������������������������������������������������
//Este script ha de estar en Mano dentro de Personaje

public class Alimentar : MonoBehaviour
{
    [SerializeField] ControladorAccionesPersonaje controladorAccionesPersonaje;

    [SerializeField] private BarraAlimento barraAlimento;
    
    //Materiales inyectados en el inspector
    [SerializeField] private Material materialHenoNormal;
    [SerializeField] private Material materialHenoMejorado;

    public bool isHenoMejorado = true;

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
                float incremento = 25f;
                if(isHenoMejorado){
                    incremento = 50f;
                }
                barraAlimento.incrementarNivelAlimentacion(incremento);
            }
        }
    }

    public void GestionarAparienciaMontonHeno()
    {
        Debug.Log("GestionarAparienciaHeno");
        if(isHenoMejorado){
            GameObject.Find("MontonHeno").GetComponent<MeshRenderer>().material = materialHenoMejorado;
        }
        else{
            GameObject.Find("MontonHeno").GetComponent<MeshRenderer>().material = materialHenoNormal;
        }
    }
    public void GestionarAparienciaHeno(GameObject heno)
    {
        if(isHenoMejorado){
            heno.GetComponent<MeshRenderer>().material = materialHenoMejorado;
            Debug.Log("hola" + heno.GetComponent<MeshRenderer>().material.name);
        }
        else{
            heno.GetComponent<MeshRenderer>().material = materialHenoNormal;
        }
        Debug.Log(heno.GetComponent<MeshRenderer>().material.name);
    }
}
