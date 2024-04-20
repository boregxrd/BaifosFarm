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

    public bool enInteraccion = false;

    IEnumerator Start()
    {
        while (true)
        {
            if (!enInteraccion) // si la cabra no esta siendo alimentada u ordeñada
            {
                Debug.Log("Cabra en movimiento");

                // Se mueve la cabra 
                agente = GetComponent<NavMeshAgent>();
                agente.SetDestination(RandomNavmeshLocation(7f));


                float elapsedTime = 0f;
                while (agente.pathPending || agente.remainingDistance > agente.stoppingDistance)
                {
                    elapsedTime += Time.deltaTime;

                    // Comprobar si lleva mas de 10 segundos en movimiento
                    if (elapsedTime >= 10)
                    {
                        Debug.LogWarning("Cabra ha excedido el tiempo de movimiento máximo");
                        break;
                    }

                    yield return null;
                }

                // Comprobar si la cabra llego a su destino o excedio el tiempo máximo
                if (agente.remainingDistance <= agente.stoppingDistance)
                {
                    // Llego a su destino
                    Debug.Log("Cabra llegó a su destino");
                }
                else
                {
                    // Excedio el tiempo
                    agente.isStopped = true;
                    Debug.LogWarning("Cabra detenida debido a tiempo de movimiento máximo excedido");
                    agente.SetDestination(RandomNavmeshLocation(7f));
                }

                agente.isStopped = false;
                Debug.Log("Cabra se para");

                // Esperar segundos aleatorios hasta el siguiente movimiento
                yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
            }
            else
            {
                // parar movimiento y esperar que se acabe de ordeñar o alimentar
                agente.isStopped = true;
                yield return null;
            }
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
