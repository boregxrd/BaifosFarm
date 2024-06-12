using System.Collections;
using UnityEditor;
using UnityEngine;

public class MuerteCabraBlanca : MonoBehaviour
{
    BarraAlimento barraAlimento;
    private Animator animator;
    private bool isDead = false;

    AudioSource audioSource;
    [SerializeField] AudioClip[] gritos;
    [SerializeField] GameObject explosion;
    MovimientoAleatorioCabras mov;
    ContadorCabras contadorCabras;


    private void Start()
    {
        contadorCabras = FindObjectOfType<ContadorCabras>();
        barraAlimento = transform.GetComponentInChildren<BarraAlimento>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        if (audioSource == null) Debug.LogError("audioSource null");
        mov = GetComponent<MovimientoAleatorioCabras>();
    }

    private void Update()
    {
        if (barraAlimento.ValorActual == 0 && !isDead)
        {
            StartCoroutine(Morir());
        }
    }

    private IEnumerator Morir()
    {
        isDead = true;

        // random delay para evitar muerte simultanea y asi evitar audio petado
        yield return new WaitForSeconds(Random.Range(0.1f, 0.6f));
        animator.SetTrigger("Muerte");
    }

    public void PlayGrito()
    {
        contadorCabras.MuerteCabraGris();
        mov.pararCabra(gameObject);
        AudioClip sonidoRandom = gritos[Random.Range(0, gritos.Length)];
        audioSource.PlayOneShot(sonidoRandom);
    }

    public void PlayExplosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}