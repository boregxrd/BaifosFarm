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
    
    [SerializeField] private bool ordenyoIniciado = false;
    

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
                alimentar.enabled = false;
                ordeniar.enabled = false;
                recogerAlimento.enabled = true;
            }
        }

        if(other.gameObject.CompareTag("cabraBlanca") || other.gameObject.CompareTag("cabraNegra"))
        {
            if (Input.GetKey("e") && objetoEnMano == recogerAlimento.objetoQueCogeBaifo() && recogerAlimento.preparadoParaAlimentar == true)
            {
                alimentar.enabled = true; 
                alimentar.DarComida(other);
                recogerAlimento.enabled = false;
                ordeniar.enabled = false;
            }
        }

        if (other.gameObject.CompareTag("cabraBlanca"))
        {
            if (Input.GetKey(KeyCode.Space) && objetoEnMano == null && ordeniar.ordenioIniciado == false)
            {
                ordeniar.enabled = true;
                ordeniar.IniciarOrdenyado(other);
                alimentar.enabled = false;
            }
        }

        

    }
}
