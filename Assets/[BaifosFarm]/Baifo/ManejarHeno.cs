using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarHeno : MonoBehaviour
{
    private Jugador jugador;
    private GameObject heno;

    //para el tutorial
    public bool alimentacionRealizada = false;

    private void Start()
    {
        jugador = GetComponent<Jugador>();
    }

    public void CogerHeno(GameObject prefabheno, Transform mano)
    {
        //para el tutorial
        alimentacionRealizada = false;

        jugador.HenoRecogido = true;
        heno = Instantiate(prefabheno);

        heno.transform.position = mano.position;
        heno.transform.SetParent(mano);
    }

    public void DejarHeno()
    {
        Destroy(heno);
        jugador.HenoRecogido = false;

        //para el tutorial
        alimentacionRealizada = true;
    }
    
}
