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
        if (cabra.nivelDeAlimentacion() > CondicionesAvisos.valorAlertaHambre){
            hambrienta = false;   
        }
        else if(!hambrienta){
            hambrienta = true;
            AudioClip sonidoRandom = necesidad[Random.Range(0, necesidad.Length)];
            audioSource.PlayOneShot(sonidoRandom);
        }

        if (cabra.nivelDeLeche() == -1) return;

        if(cabra.nivelDeLeche() != CondicionesAvisos.valorLecheCompleta){
            lecheLista = false;
        }
        else if(!lecheLista){
            lecheLista = true;
            AudioClip sonidoRandom = necesidad[Random.Range(0, necesidad.Length)];
            audioSource.PlayOneShot(sonidoRandom);
        }
    }
}
