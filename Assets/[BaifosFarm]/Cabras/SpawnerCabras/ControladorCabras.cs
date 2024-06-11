using UnityEngine;

public class ControladorCabras : MonoBehaviour
{
    public GameObject cabraBlanca;
    public GameObject cabraNegra;
    [SerializeField]
    public float rangoSpawn = 9f;
    public float tamCabra = 2f;

    ContadorCabras contadorCabras;

    void Start()
    {
        contadorCabras = FindObjectOfType<ContadorCabras>();
        SpawnCabras();
    }

    void SpawnCabras()
    {
        for (int i = 0; i < contadorCabras.NumCabrasGrises; i++)
        {
            Vector3 spawnPosition = posicionAleatoria();
            Instantiate(cabraBlanca, spawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < contadorCabras.NumCabrasNegras; i++)
        {
            Vector3 spawnPosition = posicionAleatoria();
            Instantiate(cabraNegra, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 posicionAleatoria()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-rangoSpawn, rangoSpawn), 0f, Random.Range(-rangoSpawn, rangoSpawn));

        Collider[] colliders = Physics.OverlapSphere(spawnPosition, tamCabra);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("cabraBlanca") || collider.CompareTag("cabraNegra"))
            {
                return posicionAleatoria();
            }
        }

        return spawnPosition;
    }
}
