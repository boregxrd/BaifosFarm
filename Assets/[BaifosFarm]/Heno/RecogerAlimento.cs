using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//�������������������������������������������������������SCRIPT ACCI�N RECOGER ALIMENTO������������������������������������������������������
//Este script ha de estar en Mano dentro de Personaje

public class RecogerAlimento : MonoBehaviour
{
    [SerializeField] private GameObject prefabHeno;

    [SerializeField] private GameObject heno;

    private Alimentar alimentar;
    
    [SerializeField] ControladorAccionesPersonaje controladorAccionesPersonaje;

    public bool preparadoParaAlimentar = false;

    public bool henoRecogido = false;

    private void Awake()
    {
        enabled = false;
    }

    private void OnEnable()
    { 
        alimentar = GetComponent<Alimentar>();
        heno = Instantiate(prefabHeno); //creamos un objeto heno 

        alimentar.GestionarAparienciaHeno(heno);//Para apariencia si tiene powerup o no

        //y lo recoge el personaje
        heno.GetComponent<Rigidbody>().useGravity = false;
        heno.GetComponent<Rigidbody>().isKinematic = true;

        heno.transform.position = controladorAccionesPersonaje.puntoDeMano.transform.position;
        heno.transform.SetParent(controladorAccionesPersonaje.puntoDeMano.transform);
        controladorAccionesPersonaje.objetoEnMano = heno;
        preparadoParaAlimentar = true;
        henoRecogido = true;
    }

    private void OnDisable()
    {
        Destroy(heno);
        controladorAccionesPersonaje.objetoEnMano = null;
        preparadoParaAlimentar = false;
        
    }

    public GameObject objetoQueCogeBaifo()
    {
        return heno;
    }
}
