using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script ha de estar en el objeto Mano dentro de Personaje

public class RecogerHeno : MonoBehaviour
{

    public GameObject puntoDeMano;

    private GameObject objetoEnMano = null;

    public GameObject prefabHeno;

    public GameObject heno;
    
    public BoxCollider colliderHeno;

   
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "MontonHeno")
        {
            if (Input.GetKey("e") && objetoEnMano == null)
            {
                heno = Instantiate(prefabHeno);
            
                //heno.transform.position = new Vector3(0, 0, 0);
                heno.GetComponent<Rigidbody>().useGravity = false;
                heno.GetComponent<Rigidbody>().isKinematic = true;
                heno.transform.position = puntoDeMano.transform.position;
                heno.transform.SetParent(puntoDeMano.transform);
                objetoEnMano = other.gameObject;

                //crear objeto heno
                /*
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent <Rigidbody>().isKinematic = true;
                other.transform.position = puntoDeMano.transform.position;
                other.gameObject.transform.SetParent(puntoDeMano.transform);
                objetoEnMano = other.gameObject;
                */

            }
        }
    }


}
