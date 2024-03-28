using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script ha de estar en el objeto Mano dentro de Personaje

public class RecogerHeno : MonoBehaviour
{

    public GameObject puntoDeMano;

    private GameObject objetoEnMano = null;

   
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "MontonHeno")
        {
            if (Input.GetKey("e") && objetoEnMano == null)
            {
                //crear objeto heno
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent <Rigidbody>().isKinematic = true;
                other.transform.position = puntoDeMano.transform.position;
                other.gameObject.transform.SetParent(puntoDeMano.transform);
                objetoEnMano = other.gameObject;

            }
        }
    }


}
