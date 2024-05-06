using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Transform mano;

    private void Start()
    {
        mano = gameObject.transform.GetChild(1).GetChild(0);
    }

    public void CogerHeno(GameObject prefabheno)
    {
        GameObject heno = Instantiate(prefabheno);

        heno.transform.position = mano.position;
        heno.transform.SetParent(mano);
    }
}
