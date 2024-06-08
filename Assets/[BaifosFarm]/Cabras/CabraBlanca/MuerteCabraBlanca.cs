using System;
using System.Collections;
using UnityEngine;

public class MuerteCabraBlanca : MonoBehaviour
{
    [SerializeField] private BarraAlimento barraAlimento;
    private Animator animator;
    [SerializeField] private GameObject muerteCabraPrefab; // Prefab que contiene la animaci�n de muerte
    private bool isDead = false;

    private void Start()
    {
        barraAlimento = transform.GetComponentInChildren<BarraAlimento>();
        animator = GetComponentInChildren<Animator>();
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

        animator.SetTrigger("Death");
        
        EsperarFinMuerte();
    }

    private void InstanciarFX()
    {
        GameObject muerteCabra = Instantiate(muerteCabraPrefab, transform.position, Quaternion.identity);
        
        // ajustes de tamaño y posicion
        muerteCabra.transform.localScale *= 0.5f;
        muerteCabra.transform.position += Vector3.up * 2f;
        
        
        // Rotar el objeto de muerte de la cabra para que mire hacia la c�mara
        Vector3 dirToCamera = Camera.main.transform.position - muerteCabra.transform.position;
        dirToCamera.y = 0f;
        muerteCabra.transform.rotation = Quaternion.LookRotation(dirToCamera);
    }

    private IEnumerator EsperarFinMuerte()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;
        
        yield return new WaitForSeconds(animationLength);
        
        InstanciarFX();

        int blancasAntesDeMorir = PlayerPrefs.GetInt("cabrasBlancas", 0);
        PlayerPrefs.SetInt("cabrasBlancas", blancasAntesDeMorir - 1);
        Destroy(gameObject); 
    }
}
