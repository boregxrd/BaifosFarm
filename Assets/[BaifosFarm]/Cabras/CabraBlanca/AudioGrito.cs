using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGrito : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] gritos;
    [SerializeField] AudioClip explosion;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null) Debug.LogError("audioSource null");
    }

    public void PlayGrito() {
        AudioClip sonidoRandom = gritos[Random.Range(0, gritos.Length)];
        audioSource.PlayOneShot(sonidoRandom);
    }

    public void PlayExplosion() {
        audioSource.PlayOneShot(explosion);
    }
}
