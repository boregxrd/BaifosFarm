using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarHeno : MonoBehaviour
{
    Jugador jugador;

    private void Start()
    {
        jugador = GetComponent<Jugador>();
    }

    public void CogerHeno(GameObject prefabheno, Transform mano)
    {
        if (!jugador.HenoRecogido)
        {
            jugador.HenoRecogido = true;
            GameObject heno = Instantiate(prefabheno);

            heno.transform.position = mano.position;
            heno.transform.SetParent(mano);
        }
        else
        {
            return;
        }

    }

    //Implementar DejarHeno, que activará alimentar en cabras
}
