using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabra : MonoBehaviour
{
    private BarraAlimento barraAlimento;
    private BarraLeche barraLeche;
    private Vector3 posicionCabra;

    public Vector3 PosicionCabra { get => posicionCabra;}

    private void Awake()
    {
        barraAlimento = transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();

        if (transform.childCount >= 5)
        {
            Transform barraLecheTransform = transform.GetChild(4).GetChild(0).GetChild(0);
            if (barraLecheTransform != null)
            {
                barraLeche = barraLecheTransform.GetComponent<BarraLeche>();
            }
        }
        else
        {
            Debug.Log("El GameObject no tiene suficientes hijos para inicializar correctamente.");
        }

        posicionCabra = transform.position;
    }
    public float nivelDeAlimentacion()
    {
        return barraAlimento.valorActual;
    }

    public float nivelDeLeche()
    {
        if(barraLeche != null)
        {
            return barraLeche.valorActual;
        }
        else
        {
            return 0f;
        }
        
    }



}
