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

    IEnumerator Start()
    {
        while (true)
        {
            // Se mueve la cabra 
            agente = GetComponent<NavMeshAgent>();
            agente.SetDestination(RandomNavmeshLocation(7f));

            float elapsedTime = 0f;
            while (agente.pathPending || agente.remainingDistance > agente.stoppingDistance)
            {
                if (agente.enabled == true)
                {
                    elapsedTime += Time.deltaTime;

                    // Si la cabra lleva 10s moviendose
                    if (elapsedTime >= 10)
                    {
                        break;
                    }

                    yield return null;
                }
            }

            // si despues de los 10s sigue sin llegar al destino
            if (agente.remainingDistance > agente.stoppingDistance && agente.enabled == true)
            {
                agente.isStopped = true;
                //Debug.LogWarning("Cabra detenida debido a tiempo de movimiento máximo excedido");
                agente.SetDestination(RandomNavmeshLocation(7f));
            }

            agente.isStopped = false;
            //Debug.Log("Cabra se para");

            // Esperar segundos aleatorios hasta el siguiente movimiento
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
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

    // public void pararCabra() {
    //     agente.isStopped = true;
    // }
}
