using System.Collections;
using UnityEngine;

public class MuerteCabraBlanca : MonoBehaviour
{
    [SerializeField] private BarraAlimento barraAlimento;
    [SerializeField] private GameObject muerteCabraPrefab; // Prefab que contiene la animación de muerte
    private bool isDead = false;

    private void Start()
    {
        barraAlimento = transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();
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
        // Crear el objeto de muerte de la cabra en la misma posición
        GameObject muerteCabra = Instantiate(muerteCabraPrefab, transform.position, Quaternion.identity);
        // Reducir la escala de la animación
        muerteCabra.transform.localScale *= 0.5f;
        // Elevar un poco la animación
        muerteCabra.transform.position += Vector3.up * 2f;
        // Calcular la dirección hacia la cámara del jugador
        Vector3 dirToCamera = Camera.main.transform.position - muerteCabra.transform.position;
        dirToCamera.y = 0f; // Asegurar que la rotación sea plana en el eje Y
        // Rotar el objeto de muerte de la cabra para que mire hacia la cámara
        muerteCabra.transform.rotation = Quaternion.LookRotation(dirToCamera);
        // Iniciar la animación de muerte
        muerteCabra.GetComponent<Animator>().SetTrigger("Death");
        // Destruir la cabra blanca después de la animación
        Destroy(gameObject);
    }
}
