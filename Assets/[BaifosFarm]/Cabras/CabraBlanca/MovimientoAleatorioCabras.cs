using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    IEnumerator Start()
    {
        agente = GetComponent<NavMeshAgent>();
        while (true)
        {
            if (agente.isActiveAndEnabled) // Check if the agent is active and enabled
            {
                agente.SetDestination(RandomNavmeshLocation(7f));
                enMovimiento = true;
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
                    enMovimiento = false;
                    agente.isStopped = true;
                    agente.SetDestination(RandomNavmeshLocation(7f));
                }

                yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
            }
            else
            {
                yield return null;
            }
        }
    }


    void nuevaPosicionAleatoria()
    {
        //Debug.Log("Nueva pos aleatoria");

        posicionMin = new Vector3(9, 0, 9);
        posicionMax = new Vector3(9, 0, 9);

        float randomX = Random.Range(posicionMin.x, posicionMax.x);
        float randomZ = Random.Range(posicionMin.z, posicionMax.z);

        destino = new Vector3(randomX, 0, randomZ);
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
        enMovimiento = false;

        NavMeshAgent agente = cabra.transform.GetComponent<NavMeshAgent>();

        agente.enabled = false;
        enabled = false;

        Debug.Log("parado movimiento");
    }

    public void continuarMov(GameObject cabra)
    {
        enMovimiento = true;

        NavMeshAgent agente = cabra.transform.GetComponent<NavMeshAgent>();

        agente.enabled = true;
        enabled = true;

        Debug.Log("movimiento continuado");
    }

}
