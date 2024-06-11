using System.Collections;
using UnityEngine;

public class CabraNegraInteracciones : MonoBehaviour, IInteractuable
{
    [SerializeField] private BarraAlimento barraAlimento;
    private ManejarHeno manejadorHeno;
    private TipoDeHeno tipoDeHeno;
    Animator animator;
    public bool estaComiendo = false;
    
    AudioSource audioSource;
    [SerializeField] AudioClip[] sonidosComer;

    private void Start()
    {
        tipoDeHeno = FindObjectOfType<TipoDeHeno>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void Interactuar(Jugador jugador)
    {
        if (jugador.HenoRecogido)
        {
            manejadorHeno = jugador.transform.GetComponent<ManejarHeno>();
            manejadorHeno.DejarHeno();
            estaComiendo = true;
            StartCoroutine(ComerAnimacion());
            barraAlimento.incrementarNivelAlimentacion(tipoDeHeno.incremento);
        }

    }

    private IEnumerator ComerAnimacion()
    {
        AudioClip sonidoRandom = sonidosComer[Random.Range(0, sonidosComer.Length)];
        audioSource.PlayOneShot(sonidoRandom);
        for (int i = 0; i < 2; i++)
        {
            animator.SetBool("RecibeComida", true);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            animator.SetBool("RecibeComida", false);
        }
        estaComiendo = false;
    }
}

