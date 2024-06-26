using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoAleatorioCabras : MonoBehaviour
{
    [SerializeField] public float velocidad = 3f;
    private Vector3 destino;
    private Vector3 posicionMin;
    private Vector3 posicionMax;

    [SerializeField] private float delayMin = 2.0f;
    [SerializeField] private float delayMax = 6.0f;

    public bool enMovimiento = false;
    private NavMeshAgent agente;
    private Animator animator;
    [SerializeField] private AudioClip[] footstepSounds; // Array de sonidos de pisadas
    private AudioSource audioSource; // AudioSource

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        if (agente == null) Debug.LogError("NavMeshAgent null");

        animator = GetComponentInChildren<Animator>();
        if (animator == null) Debug.LogError("Animator null");

        audioSource = GetComponentInChildren<AudioSource>();
        if (audioSource == null) Debug.LogError("AudioSource null");
    }

    IEnumerator Start()
    {
        animator.SetBool("enMovimiento", true);
        while (true)
        {
            if (agente.isActiveAndEnabled)
            {
                agente.SetDestination(RandomNavmeshLocation(7f));
                animator.SetBool("enMovimiento", true);

                float elapsedTime = 0f;
                while (agente.isActiveAndEnabled && (agente.pathPending || agente.remainingDistance > agente.stoppingDistance))
                {
                    elapsedTime += Time.deltaTime;

                    if (elapsedTime >= 10)
                    {
                        break;
                    }

                    yield return null;
                }

                if (agente.isActiveAndEnabled && agente.remainingDistance > agente.stoppingDistance)
                {
                    agente.isStopped = true;
                    agente.SetDestination(RandomNavmeshLocation(7f));
                }

                animator.SetBool("enMovimiento", false);
                yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
            }
            else
            {
                yield return null;
            }
        }
    }

    public void PlayFootstepSound()
    {
        StartCoroutine(PlayFootstepSoundCoroutine());
    }

    private IEnumerator PlayFootstepSoundCoroutine()
    {
        yield return new WaitForSeconds(0.01f);

        if (footstepSounds.Length > 0 && audioSource != null)
        {
            AudioClip sonidoRandom = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(sonidoRandom);
        }
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public void pararCabra(GameObject cabra)
    {
        animator.SetBool("enMovimiento", false);
        NavMeshAgent agente = cabra.transform.GetComponent<NavMeshAgent>();
        agente.enabled = false;
        enabled = false;
    }

    public void continuarMov(GameObject cabra)
    {
        NavMeshAgent agente = cabra.transform.GetComponent<NavMeshAgent>();
        agente.enabled = true;
        enabled = true;
    }
}
