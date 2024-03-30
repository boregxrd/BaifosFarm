using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//·················································SCRIPT PARA RECOGER Y SOLTAR EL HENO·················································

//Este script ha de estar en el objeto Mano dentro de Personaje

public class RecogerHeno : MonoBehaviour
{

    public GameObject puntoDeMano;

    private GameObject objetoEnMano = null;

    public GameObject prefabHeno;

    public GameObject heno;

    [SerializeField] private BarraAlimento barraAlimento;

    [SerializeField] private float incremento = 25f;

    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "MontonHeno") //cuando el personaje se acerca al montón de heno,
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

        if (other.gameObject.CompareTag("cabra"))
        {
            if(Input.GetKey("e") && objetoEnMano != null)
            {
                var children = other.gameObject.GetComponentsInChildren<Transform>();
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


}
