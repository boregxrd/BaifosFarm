using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecogerAlimento : MonoBehaviour
{
    [SerializeField] private GameObject prefabHeno;

    [SerializeField] private GameObject heno;

    [SerializeField] ControladorAccionesPersonaje controladorAccionesPersonaje;

    private void Awake()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");

        heno = Instantiate(prefabHeno); //creamos un objeto heno 

        //y lo recoge el personaje
        heno.GetComponent<Rigidbody>().useGravity = false;
        heno.GetComponent<Rigidbody>().isKinematic = true;

        heno.transform.position = controladorAccionesPersonaje.puntoDeMano.transform.position;
        heno.transform.SetParent(controladorAccionesPersonaje.puntoDeMano.transform);
        
    }

    public void asignarObjetoEnMano(GameObject objeto)
    {
        controladorAccionesPersonaje.objetoEnMano = objeto;
    }
    
}
