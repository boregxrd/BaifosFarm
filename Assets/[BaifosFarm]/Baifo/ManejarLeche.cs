using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarLeche : MonoBehaviour
{
    [SerializeField] private Jugador jugador;
    private GameObject leche;

    //para el tutorial
    public bool ordenyoRealizado = false;

    private void Start()
    {
        jugador = GetComponent<Jugador>();
    }

    public void CogerLeche(GameObject prefabLeche)
    {
        //para el tutorial
        ordenyoRealizado = true;

        jugador.LecheRecogida = true;
        leche = Instantiate(prefabLeche);

        leche.transform.position = jugador.Mano.position;
        leche.transform.SetParent(jugador.Mano);
    }

    public void DejarLeche()
    {
        Destroy(leche);
        jugador.LecheRecogida = false;

        //para el tutorial
        ordenyoRealizado = false;
    }
}