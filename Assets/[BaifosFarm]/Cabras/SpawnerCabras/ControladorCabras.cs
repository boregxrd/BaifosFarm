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
        SpawnCabras();
    }

    void SpawnCabras()
    {
        int numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
        int numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);
       
        for (int i = 0; i < numCabrasBlancas; i++)
        {
            Vector3 spawnPosition = posicionAleatoria();
            Instantiate(cabraBlanca, spawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < numCabrasNegras; i++)
        {
            Vector3 spawnPosition = posicionAleatoria();
            Instantiate(cabraNegra, spawnPosition, Quaternion.identity);
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
