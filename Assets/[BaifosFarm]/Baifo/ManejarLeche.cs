using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarLeche : MonoBehaviour
{
    private Jugador jugador;
    private GameObject leche;
    Animator animator;

    // para el tutorial
    public bool ordenyoRealizado = false;

    // Referencias de los archivos de sonido
    public AudioClip sonidoLeche1;
    public AudioClip sonidoLeche2;
    private AudioSource audioSource;

    private void Start()
    {
        jugador = GetComponent<Jugador>();
        animator = transform.GetChild(0).GetComponent<Animator>();

        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    public void CogerLeche(GameObject prefabLeche)
    {
        // para el tutorial
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

        // Reproducir un sonido aleatorio
        ReproducirSonidoAleatorio();

        // para el tutorial
        ordenyoRealizado = false;
    }

    private void ReproducirSonidoAleatorio()
    {
        int indice = Random.Range(0, 2); // Genera un número aleatorio 0 o 1
        AudioClip clip = indice == 0 ? sonidoLeche1 : sonidoLeche2;
        audioSource.PlayOneShot(clip);
    }
}
