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


    private void Start()
    {
        barraAlimento = transform.GetComponentInChildren<BarraAlimento>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();
        if(audioSource == null) Debug.LogError("audioSource null");
        mov = GetComponent<MovimientoAleatorioCabras>();
    }

    private void Update()
    {
        if (barraAlimento.ValorActual == 0 && !isDead)
        {
            Morir();
        }
    }

    private void Morir()
    {
        isDead = true;

        animator.SetTrigger("Muerte");
    }

    public void PlayGrito() {
        mov.pararCabra(gameObject);
        AudioClip sonidoRandom = gritos[Random.Range(0, gritos.Length)];
        audioSource.PlayOneShot(sonidoRandom);
    }

    public void PlayExplosion() {
        Instantiate(explosion, transform.position, transform.rotation);

        int blancasAntesDeMorir = PlayerPrefs.GetInt("cabrasBlancas", 0);
        PlayerPrefs.SetInt("cabrasBlancas", blancasAntesDeMorir - 1);
        Destroy(gameObject);
    }
}


    // private void InstanciarFX()
    // {
    //     GameObject muerteCabra = Instantiate(muerteCabraPrefab, transform.position, Quaternion.identity);
        
    //     // ajustes de tamaño y posicion
    //     muerteCabra.transform.localScale *= 0.5f;
    //     muerteCabra.transform.position += Vector3.up * 2f;
        
        
    //     // Rotar el objeto de muerte de la cabra para que mire hacia la c�mara
    //     Vector3 dirToCamera = Camera.main.transform.position - muerteCabra.transform.position;
    //     dirToCamera.y = 0f;
    //     muerteCabra.transform.rotation = Quaternion.LookRotation(dirToCamera);
    // }