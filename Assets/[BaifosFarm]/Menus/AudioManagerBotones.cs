using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerBotones : MonoBehaviour
{
    static AudioManagerBotones instance;
    public static AudioManagerBotones Instance { get { return instance; } }

    private AudioSource audioSource;
    [SerializeField] private AudioClip sonidoBotonNormal;
    [SerializeField] private AudioClip sonidoBotonCerrar;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void ReproducirSonidoBotonNormal()
    {
        audioSource.PlayOneShot(sonidoBotonNormal);
    }

    public void ReproducirSonidoBotonCerrar()
    {
        audioSource.PlayOneShot(sonidoBotonCerrar);
    }


}
