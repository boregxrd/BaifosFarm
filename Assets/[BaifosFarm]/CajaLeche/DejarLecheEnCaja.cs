using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DejarLecheEnCaja : MonoBehaviour, IInteractuable
{
    private ManejarLeche manejarLeche;
    private ControladorTextoCaja controladorTextoCaja;

    //para el tutorial
    public bool lecheGuardada = false;

    private Animator animatorDejarLeche;
    private ParticleSystem particulasDejarLeche;
    private ParticleSystem childGameObjectParticle;

    private AudioSource audioSource;

    ContadorLeche contadorLeche;

    private void Start()
    {
        contadorLeche = FindObjectOfType<ContadorLeche>();
        audioSource = GetComponent<AudioSource>();
        controladorTextoCaja = GetComponent<ControladorTextoCaja>();
        animatorDejarLeche = GetComponent<Animator>();
        particulasDejarLeche = GetComponent<ParticleSystem>();
        childGameObjectParticle = GameObject.Find("ParticulasTutorialCajaLeche").GetComponent<ParticleSystem>();
    }

    public void Interactuar(Jugador jugador)
    {
        if (jugador.LecheRecogida)
        {
            manejarLeche = jugador.GetComponent<ManejarLeche>();
            manejarLeche.DejarLeche();
            contadorLeche.SumarLeche();
            controladorTextoCaja.ActualizarTextoCaja(contadorLeche.Contador);
            animatorDejarLeche.SetTrigger("DejarLeche");
            
            StartCoroutine(PlayParticlesAfterDelay(1.05f)); // Iniciar la corutina

            childGameObjectParticle.Stop();
            //para el tutorial
            lecheGuardada = true;
        }
    }

    // Corutina para reproducir las partículas después de un retraso
    private IEnumerator PlayParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Esperar el tiempo especificado
        particulasDejarLeche.Play(); // Reproducir las partículas
        audioSource.Play();
    }
}