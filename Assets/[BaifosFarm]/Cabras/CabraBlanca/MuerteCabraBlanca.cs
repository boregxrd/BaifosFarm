using System.Collections;
using UnityEngine;

public class MuerteCabraBlanca : MonoBehaviour
{
    [SerializeField] private BarraAlimento barraAlimento;
    [SerializeField] private GameObject muerteCabraPrefab; // Prefab que contiene la animaci�n de muerte
    private bool isDead = false;

    private void Start()
    {
        barraAlimento = transform.GetComponentInChildren<BarraAlimento>();
    }

    private void Update()
    {
        if (barraAlimento.ValorActual == 0 && !isDead)
        {
            Morir();
        }
    }

    private void Morir()
    {
        isDead = true;
        // Crear el objeto de muerte de la cabra en la misma posici�n
        GameObject muerteCabra = Instantiate(muerteCabraPrefab, transform.position, Quaternion.identity);
        // Reducir la escala de la animaci�n
        muerteCabra.transform.localScale *= 0.5f;
        // Elevar un poco la animaci�n
        muerteCabra.transform.position += Vector3.up * 2f;
        // Calcular la direcci�n hacia la c�mara del jugador
        Vector3 dirToCamera = Camera.main.transform.position - muerteCabra.transform.position;
        dirToCamera.y = 0f; // Asegurar que la rotaci�n sea plana en el eje Y
        // Rotar el objeto de muerte de la cabra para que mire hacia la c�mara
        muerteCabra.transform.rotation = Quaternion.LookRotation(dirToCamera);
        // Iniciar la animaci�n de muerte
        muerteCabra.GetComponent<Animator>().SetTrigger("Death");
        // Destruir la cabra blanca despu�s de la animaci�n
        Destroy(gameObject);
        int blancasAntesDeMorir = PlayerPrefs.GetInt("cabrasBlancas", 0);
        PlayerPrefs.SetInt("cabrasBlancas", blancasAntesDeMorir - 1);
    }
}
