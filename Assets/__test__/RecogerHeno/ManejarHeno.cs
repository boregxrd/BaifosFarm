using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarHeno : MonoBehaviour
{
    private Jugador jugador;
    private GameObject heno;

    private void Start()
    {
        jugador = GetComponent<Jugador>();
    }

    public void CogerHeno(GameObject prefabheno, Transform mano)
    {
        if (!jugador.HenoRecogido)
        {
            jugador.HenoRecogido = true;

            heno = Instantiate(prefabheno);

            heno.transform.position = mano.position;
            heno.transform.SetParent(mano);
        }
        else
        {
            return;
        }

    }

    public void DejarHeno()
    {
        Destroy(heno);
        jugador.HenoRecogido = false;  
    }
    //Implementar DejarHeno, que activará alimentar en cabras
}
