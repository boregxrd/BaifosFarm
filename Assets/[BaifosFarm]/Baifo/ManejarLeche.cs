using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarLeche : MonoBehaviour
{
    private Jugador jugador;
    private GameObject leche;
    Animator animator;

    //para el tutorial
    public bool ordenyoRealizado = false;

    private void Start()
    {
        jugador = GetComponent<Jugador>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void CogerLeche(GameObject prefabLeche)
    {
        //para el tutorial
        ordenyoRealizado = true;

        jugador.LecheRecogida = true;
        leche = Instantiate(prefabLeche);

        animator.SetTrigger("leche");

        leche.transform.position = jugador.Mano.position;
        leche.transform.SetParent(jugador.Mano);
    }

    public void DejarLeche()
    {
        Destroy(leche);
        jugador.LecheRecogida = false;
        animator.SetTrigger("dejarObjeto");

        //para el tutorial
        ordenyoRealizado = false;
    }
}
