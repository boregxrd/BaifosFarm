using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAccionesPersonaje : MonoBehaviour
{
    public GameObject puntoDeMano;
    public GameObject objetoEnMano = null;

    [SerializeField] private RecogerAlimento recogerAlimento;
    [SerializeField] private Alimentar alimentar;
    [SerializeField] private Ordeniar ordeniar;

    private void Awake()
    {
        recogerAlimento = GetComponent<RecogerAlimento>();
        alimentar = GetComponent<Alimentar>();
        ordeniar = GetComponent<Ordeniar>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "MontonHeno") //cuando el personaje se acerca al montón de heno,
        {
            if (Input.GetKey("e") && objetoEnMano == null) //se pulsa E y no tiene nada en la mano:
            {
                Debug.Log("He pulsado E");
                recogerAlimento.enabled = true;
                recogerAlimento.asignarObjetoEnMano(other.gameObject);
            }
        }
    }
}
