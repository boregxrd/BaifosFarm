using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSaltitos : MonoBehaviour
{
    Animator animator;
    [SerializeField] AudioClip[] sonidoSaltitos; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) Debug.LogError("audioSource null");
    }

    private void PlaySaltito() {
        AudioClip sonidoRandom = sonidoSaltitos[Random.Range(0, sonidoSaltitos.Length)];
        audioSource.PlayOneShot(sonidoRandom);
    }

    
}
