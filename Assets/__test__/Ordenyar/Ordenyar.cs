using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordenyar : MonoBehaviour
{
    [SerializeField] private GameObject puntoDeMano;

    [SerializeField] private GameObject objetoEnMano = null;

    [SerializeField] private GameObject prefabLeche;

    [SerializeField] private GameObject leche;

    [SerializeField] private BarraLeche barraLeche;

    [SerializeField] private bool procesoIniciado = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("cabraBlanca")) //cuando el personaje de acerca a una cabra blanca,
        {
            if (Input.GetKey("e") && objetoEnMano == null && !procesoIniciado)
            {
                procesoIniciado = true;
                var children = other.gameObject.GetComponentsInChildren<Transform>(); //dentro de la cabra busco el objeto barraAlimento y luego su script
                foreach (var child in children)
                {
                    if (child.name == "BarraLeche")
                    {
                        barraLeche = child.GetComponent<BarraLeche>();

                        if (barraLeche.lechePreparada == true)
                        {
                            Debug.Log("a ordeñar");
                        }
                    }
                }
            }
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "MontonHeno") //cuando el personaje se acerca al montón de heno,
        {
            if (Input.GetKey("e") && objetoEnMano == null) //se pulsa E y no tiene nada en la mano:
            {
                heno = Instantiate(prefabHeno); //creamos un objeto heno 

                //y lo recoge el personaje
                heno.GetComponent<Rigidbody>().useGravity = false;
                heno.GetComponent<Rigidbody>().isKinematic = true;
                heno.transform.position = puntoDeMano.transform.position;
                heno.transform.SetParent(puntoDeMano.transform);
                objetoEnMano = other.gameObject;

            }
        }

        if (other.gameObject.CompareTag("cabra")) //cuando el personaje de acerca a cualquier cabra,
        {
            if (Input.GetKey("e") && objetoEnMano != null)
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

                Destroy(heno);
                objetoEnMano = null;
            }
        }
    }
    */

}
