using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAleatorioCabras : MonoBehaviour
{
    public Vector3 destino;
    public Vector3 posicionMin;
    public Vector3 posicionMax;
    [SerializeField] public float velocidad = 3f; 
    
    public float delayMin = 1.0f;
    public float delayMax = 5.0f;

    void Start()
    {
        nuevaPosicionAleatoria();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        if(transform.position == destino) {
            float delay = Random.Range(delayMin, delayMax);
            Invoke("SetRandomTargetPosition", delay);
        }
    }

    void nuevaPosicionAleatoria() {
        float randomX = Random.Range(posicionMin.x, posicionMax.x);
        float randomZ = Random.Range(posicionMin.z, posicionMax.z);

        destino = new Vector3(randomX, 0, randomZ);
    }
}
