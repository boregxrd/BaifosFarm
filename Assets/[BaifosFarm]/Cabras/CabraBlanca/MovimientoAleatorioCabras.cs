using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoAleatorioCabras : MonoBehaviour
{
    public Vector3 destino;
    public Vector3 posicionMin;
    public Vector3 posicionMax;
    [SerializeField] public float velocidad = 3f;

    public float delayMin = 1.0f;
    public float delayMax = 3.0f;
    public bool enMovimiento = false;

    void Start()
    {
        // Start the random movement coroutine
        StartCoroutine(RandomMovement());
    }

    IEnumerator RandomMovement()
    {
        while (true)
        {
            // Esperar unos segundos aleatorios antes del movimiento
            Debug.Log("Cabra en movimiento");
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
            enMovimiento = true;

            // Generar nuevo destino aleatorio
            destino = nuevaPosicionAleatoria();

            // Se mueve la cabra 
            NavMeshAgent agente = GetComponent<NavMeshAgent>();
            while (agente.velocity.x > 0 || agente.velocity.z > 0) 
            // tiene que ser diferente pq NavMesh para la cabra 
            // antes de su destino entonces el while no acaba nunca
            {
                transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
                // transform.LookAt(transform.position + destino); tiene que especificar que gire el cuerpo
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            Debug.Log("Cabra se para");
            enMovimiento = false;
        }
    }

    Vector3 nuevaPosicionAleatoria()
    {
        Debug.Log("Nueva pos aleatoria");
        float randomX = Random.Range(posicionMin.x, posicionMax.x);
        float randomZ = Random.Range(posicionMin.z, posicionMax.z);

        return new Vector3(randomX, 0, randomZ);
    }
}
