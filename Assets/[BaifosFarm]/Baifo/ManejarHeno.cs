using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarHeno : MonoBehaviour
{
    private Jugador jugador;
    private GameObject heno;

    // Para el tutorial
    public bool alimentacionRealizada = false;

    [SerializeField] ParticleSystem particulasHeno; 

    private void Start()
    {
        jugador = GetComponent<Jugador>();
    }

    public void CogerHeno(GameObject prefabheno, Transform mano)
    {
        // Para el tutorial
        alimentacionRealizada = false;

        jugador.HenoRecogido = true;
        heno = Instantiate(prefabheno);

        heno.transform.position = mano.position;
        heno.transform.SetParent(mano);

        MostrarParticulasHeno();
    }

    public void DejarHeno()
    {
        Destroy(heno);
        jugador.HenoRecogido = false;

        // Para el tutorial
        alimentacionRealizada = true;
    }

    private void MostrarParticulasHeno()
    {
        // if (jugador.HenoParticlesPrefab != null)
        // {
        //     var particles = Instantiate(jugador.HenoParticlesPrefab, jugador.Mano.position, Quaternion.identity);
        //     particles.transform.SetParent(jugador.Mano);

        //     // Ajustar la escala de las part�culas
        //     particles.transform.localScale = Vector3.one * 0.3f;

        //     var particleSystem = particles.GetComponent<ParticleSystem>();
        //     if (particleSystem != null)
        //     {
        //         particleSystem.Play();
        //         StartCoroutine(StopParticles(particleSystem, 0.5f));
        //     }
        // }

        particulasHeno.Play();
    }

    private IEnumerator StopParticles(ParticleSystem particleSystem, float delay)
    {
        yield return new WaitForSeconds(delay);
        particleSystem.Stop();
        Destroy(particleSystem.gameObject, particleSystem.main.startLifetime.constantMax); // Destruir despu�s de que las part�culas se hayan detenido
    }
}
