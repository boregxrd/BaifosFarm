using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCabras : MonoBehaviour
{
    [SerializeField]
    public int numCabrasBlancas = 1;
    [SerializeField]
    public int numCabrasNegras;
    public GameObject cabraBlanca;
    public GameObject cabraNegra;
    [SerializeField]
    public float rangoSpawn = 9f;
    public float tamCabra = 2f;

    void Start()
    {
        SpawnCabras();
    }

    void SpawnCabras()
    {
        // get num cabras blancas/negras

        // si hay cabra negra spawn

        // spawn cabras blancas
        for (int i = 0; i < numCabrasBlancas; i++)
        {
            Vector3 spawnPosition = posicionAleatoria();
            Instantiate(cabraBlanca, spawnPosition, Quaternion.identity);
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
        // int currentValue = PlayerPrefs.GetInt("YourKey", 0);
        // currentValue++;
        // PlayerPrefs.SetInt("YourKey", currentValue);
        numCabrasBlancas--;
    }

    public void disminuirNumCabrasNegras()
    {
        // lo mismo que con blancas
        numCabrasNegras--;
    }
}
