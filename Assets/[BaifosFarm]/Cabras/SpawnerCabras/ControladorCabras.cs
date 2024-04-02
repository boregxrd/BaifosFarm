using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCabras : MonoBehaviour
{
    public GameObject cabraBlanca;
    public GameObject cabraNegra;
    [SerializeField]
    public float rangoSpawn = 9f;
    public float tamCabra = 2f;

    void Start()
    {
        Debug.Log("START");
        SpawnCabras();
    }

    void SpawnCabras()
    {
        // get num cabras blancas/negras
        int numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
        int numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);
        Debug.Log("GET DONE: " + numCabrasBlancas + ", " + numCabrasNegras);
        // si hay cabra negra spawn
        if (numCabrasNegras != 0)
        {
            Vector3 spawnPosition = posicionAleatoria();
            Instantiate(cabraNegra, spawnPosition, Quaternion.identity);
            Debug.Log("CABRA NEGRA");
        }
        else if (numCabrasBlancas != 0)
        {
            // spawn cabras blancas
            for (int i = 0; i < numCabrasBlancas; i++)
            {
                Vector3 spawnPosition = posicionAleatoria();
                Instantiate(cabraBlanca, spawnPosition, Quaternion.identity);
                Debug.Log("CABRA BLANCA " + i);
            }
        }

    }

    Vector3 posicionAleatoria()
    {
        // posicion aleatoria dentro de escenario (rango definido)
        Vector3 spawnPosition = new Vector3(Random.Range(-rangoSpawn, rangoSpawn), 0f, Random.Range(-rangoSpawn, rangoSpawn));

        Collider[] colliders = Physics.OverlapSphere(spawnPosition, tamCabra);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("cabraBlanca") || collider.CompareTag("cabraNegra"))
            {
                // Si hay una cabra cerca, recalcular
                return posicionAleatoria();
            }
        }

        return spawnPosition;
    }

    public void disminuirNumCabrasBlancas()
    {
        // get num cabras y restar uno al PlayerRefs
        int numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
        numCabrasBlancas--;
        PlayerPrefs.SetInt("cabrasBlancas", numCabrasBlancas);
    }

    public void disminuirNumCabrasNegras()
    {
        // lo mismo que con blancas
        int numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);
        numCabrasNegras--;
        PlayerPrefs.SetInt("cabrasNegras", numCabrasNegras);
    }
}
