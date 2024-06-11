using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNecesidad : MonoBehaviour
{
    BarraAlimento barraAlimento;
    AudioSource audioSource;
    [SerializeField] AudioClip[] necesidad;

    bool hambrienta = false;
    bool lecheLista = false;

    Cabra cabra;

    void Start()
    {
        cabra = GetComponent<Cabra>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (!hambrienta)
        {
            if (cabra.nivelDeAlimentacion() <= 40f)
            {
                hambrienta = true;
                AudioClip sonidoRandom = necesidad[Random.Range(0, necesidad.Length)];
                audioSource.PlayOneShot(sonidoRandom);
            } else {
                hambrienta = false;
            }
        }

        if(!lecheLista) {
            if(cabra.nivelDeLeche() == 100f) {
                lecheLista = true;
                AudioClip sonidoRandom = necesidad[Random.Range(0, necesidad.Length)];
                audioSource.PlayOneShot(sonidoRandom);
            } else {
                lecheLista = false;
            }
        }
    }
}
