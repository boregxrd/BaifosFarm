using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosCabraNegra : MonoBehaviour
{
    Animator animator;
    private AudioSource audioSource;

    [SerializeField] AudioClip[] sonidoSaltitos; 
    [SerializeField] AudioClip[] sonidosIdle; 


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) Debug.LogError("audioSource null");
    }

    private void PlaySaltito() {
        AudioClip sonidoRandom = sonidoSaltitos[Random.Range(0, sonidoSaltitos.Length)];
        audioSource.PlayOneShot(sonidoRandom);
    }

    private void PlayIdle() {
        AudioClip sonidoRandom = sonidosIdle[Random.Range(0, sonidosIdle.Length)];
        audioSource.PlayOneShot(sonidoRandom);
    }
}
