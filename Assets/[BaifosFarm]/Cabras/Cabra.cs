using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabra : MonoBehaviour
{
    [SerializeField]
    private BarraAlimento barraAlimento;
    private BarraLeche barraLeche;
    private Vector3 posicionCabra;

    public Vector3 PosicionCabra { get => posicionCabra;}

    private void Awake()
    {
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
