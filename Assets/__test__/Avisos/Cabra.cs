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
        barraLeche = transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<BarraLeche>();
        posicionCabra = transform.position;
    }

    public float nivelDeAlimentacion()
    {
        return barraAlimento.valorActual;
    }

    public float nivelDeLeche()
    {
        return barraLeche.valorActual;
    }



}
