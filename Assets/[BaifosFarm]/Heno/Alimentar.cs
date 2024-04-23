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

    public bool alimentacionRealizada = false;

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
                float incremento = 40f;
                if(PlayerPrefs.GetInt("HenoMejorado", 0) == 1){
                    incremento = 80f;
                }
                barraAlimento.incrementarNivelAlimentacion(incremento);
                alimentacionRealizada = true;
            }
        }
    }

    public void GestionarAparienciaMontonHeno()
    {
        if(PlayerPrefs.GetInt("HenoMejorado", 0) == 1){
            GameObject.Find("MontonHeno").GetComponent<MeshRenderer>().material = materialHenoMejorado;
        }
        else{
            GameObject.Find("MontonHeno").GetComponent<MeshRenderer>().material = materialHenoNormal;
        }
    }
    public void GestionarAparienciaHeno(GameObject heno)
    {
        if(PlayerPrefs.GetInt("HenoMejorado", 0) == 1){
            heno.GetComponent<MeshRenderer>().material = materialHenoMejorado;
        }
        else{
            heno.GetComponent<MeshRenderer>().material = materialHenoNormal;
        }
    }
}
