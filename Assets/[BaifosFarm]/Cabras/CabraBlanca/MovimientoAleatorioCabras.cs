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
            Debug.Log("Cabra en movimiento");
            enMovimiento = true;

            // Generar nuevo destino aleatorio
            // nuevaPosicionAleatoria();

            // Se mueve la cabra 
            agente = GetComponent<NavMeshAgent>();
            // while (agente.velocity.x > 0 || agente.velocity.z > 0) 
            // // tiene que ser diferente pq NavMesh para la cabra 
            // // antes de su destino entonces el while no acaba nunca
            // {
            //     transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            //     // transform.LookAt(transform.position + destino); tiene que especificar que gire el cuerpo
            //     yield return null;
            // }

            agente.SetDestination(RandomNavmeshLocation(7f));
            // yield return new WaitUntil(() => agente.remainingDistance < 0.1f );
            float elapsedTime = 0f;
            while (agente.pathPending || agente.remainingDistance > agente.stoppingDistance)
            {
                elapsedTime += Time.deltaTime;

                // Check if the goat has been trying to move for too long
                if (elapsedTime >= 10)
                {
                    Debug.LogWarning("Cabra ha excedido el tiempo de movimiento máximo");
                    break;
                }

                yield return null;
            }

            // Check if the goat reached its destination or timed out
            if (agente.remainingDistance <= agente.stoppingDistance)
            {
                Debug.Log("Cabra llegó a su destino");
            }
            else
            {
                // The goat timed out, stop trying to move
                agente.isStopped = true;
                Debug.LogWarning("Cabra detenida debido a tiempo de movimiento máximo excedido");
                agente.SetDestination(RandomNavmeshLocation(7f));
            }

            agente.isStopped = false;
            Debug.Log("Cabra se para");
            enMovimiento = false;

            // Esperar segundos aleatorios hasta el siguiente movimiento
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
        }
    }

    void nuevaPosicionAleatoria()
    {
        Debug.Log("Nueva pos aleatoria");

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
}
