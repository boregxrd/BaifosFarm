using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecogerAlimento : MonoBehaviour
{
    [SerializeField] private GameObject prefabHeno;

    [SerializeField] private GameObject heno;

    [SerializeField] ControladorAccionesPersonaje controladorAccionesPersonaje;

    public bool preparadoParaAlimentar = false;

    private void Awake()
    {
        enabled = false;
    }

    private void OnEnable()
    { 
        heno = Instantiate(prefabHeno); //creamos un objeto heno 

        //y lo recoge el personaje
        heno.GetComponent<Rigidbody>().useGravity = false;
        heno.GetComponent<Rigidbody>().isKinematic = true;

        heno.transform.position = controladorAccionesPersonaje.puntoDeMano.transform.position;
        heno.transform.SetParent(controladorAccionesPersonaje.puntoDeMano.transform);
        controladorAccionesPersonaje.objetoEnMano = heno;
        preparadoParaAlimentar = true;
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
