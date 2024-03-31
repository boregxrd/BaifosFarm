using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
//···············································SCRIPT CONTROLADORA DE ACCIONES (MAQUINA DE ESTADOS FINITOS)······················································
//Este script ha de estar en Mano dentro de Personaje

public class ControladorAccionesPersonaje : MonoBehaviour
{
    public GameObject puntoDeMano;
    public GameObject objetoEnMano = null;

    //Variable global para almacenar el clon del instance del prefab leche
    public GameObject ultimaLecheEnMano = null;
    //Variable global para almacenar el numero de leches guardadas
    public int lechesGuardadas = 0;
    private bool cajaLecheInteractuada = false;

    //Diferentes acciones que realiza el personaje:

    [SerializeField] private RecogerAlimento recogerAlimento;
    [SerializeField] private Alimentar alimentar;
    [SerializeField] private Ordeniar ordeniar;
    [SerializeField] private DejarLecheEnCaja dejarLecheEnCaja;

    
    

    private void Awake()
    {
        recogerAlimento = GetComponent<RecogerAlimento>();
        alimentar = GetComponent<Alimentar>();
        ordeniar = GetComponent<Ordeniar>();
        dejarLecheEnCaja = GetComponent<DejarLecheEnCaja>();
    }

    private void OnTriggerStay(Collider other)
    {

        //Dependiendo de lo que el personaje tenga cerca, lo que lleve en las manos y la tecla que pulse realizará una acción u otra:


        //RECOGER ALIMENTO
        if (other.gameObject.name == "MontonHeno") //cuando el personaje se acerca al montón de heno,
        {

            if (Input.GetKey("e") && objetoEnMano == null) //se pulsa E y no tiene nada en la mano:
            {
                alimentar.enabled = false;
                ordeniar.enabled = false;
                recogerAlimento.enabled = true;
            }
        }

        //ALIMENTAR
        if(other.gameObject.CompareTag("cabraBlanca") || other.gameObject.CompareTag("cabraNegra")) //si se acerca a cualquier cabra
        {
            if (Input.GetKey("e") && objetoEnMano == recogerAlimento.objetoQueCogeBaifo() && recogerAlimento.preparadoParaAlimentar == true)
            {
                alimentar.enabled = true; 
                alimentar.DarComida(other);
                recogerAlimento.enabled = false;
                ordeniar.enabled = false;
            }
        }

        //ORDEÑAR
        if (other.gameObject.CompareTag("cabraBlanca")) 
        {
            if (Input.GetKey(KeyCode.Space) && objetoEnMano == null && ordeniar.ordenioIniciado == false)
            {
                ordeniar.enabled = true;
                ordeniar.IniciarOrdenyado(other);
                alimentar.enabled = false;
            }
        }

        //DEJAR LECHE EN CAJA
        if (other.gameObject.CompareTag("CajaLeche"))
        {
            if (Input.GetKey(KeyCode.E) && objetoEnMano == ultimaLecheEnMano && !cajaLecheInteractuada)
            {
                cajaLecheInteractuada = true;

                dejarLecheEnCaja.enabled = true;
                dejarLecheEnCaja.DejarLeche();
                lechesGuardadas++;
                Debug.Log(lechesGuardadas);

                StartCoroutine(ReactivarControladorDespuesDeDelay());
            }
        }

        IEnumerator ReactivarControladorDespuesDeDelay()
        {
            yield return new WaitForSeconds(0.5f); // Cambia este valor según sea necesario
            cajaLecheInteractuada = false;
            dejarLecheEnCaja.enabled = false;
        }


    }
}
