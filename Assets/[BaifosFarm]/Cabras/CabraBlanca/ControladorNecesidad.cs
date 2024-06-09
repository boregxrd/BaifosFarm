using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNecesidad : MonoBehaviour
{
    BarraAlimento barraAlimento;
    AudioSource audioSource;
    [SerializeField] AudioClip[] necesidad;

    bool necesitada = false;

    void Start()
    {
        barraAlimento = GetComponentInChildren<BarraAlimento>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (!necesitada)
        {
            if (barraAlimento.ValorActual <= 50f)
            {
                necesitada = true;
                AudioClip sonidoRandom = necesidad[Random.Range(0, necesidad.Length)];
                audioSource.PlayOneShot(sonidoRandom);
            } else {
                necesitada = false;
            }
        }
    }
}
