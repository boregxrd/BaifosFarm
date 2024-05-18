using UnityEngine;

public class Cabra : MonoBehaviour
{
    [SerializeField]
    private BarraAlimento barraAlimento;
    [SerializeField]
    private BarraLeche barraLeche;
    [SerializeField]
    private Transform bocaCabra; // Punto de emisión de partículas
    [SerializeField]
    private GameObject henoParticlesPrefab; // Prefab de partículas de heno

    private Vector3 posicionCabra;

    public Vector3 PosicionCabra { get => posicionCabra; }

    private void Awake()
    {
        posicionCabra = transform.position;
    }

    public float nivelDeAlimentacion()
    {
        return barraAlimento.ValorActual;
    }

    public float nivelDeLeche()
    {
        if (barraLeche != null)
        {
            return barraLeche.valorActual;
        }
        else
        {
            return 0f;
        }
    }

    public void AlimentarCabra(float cantidad)
    {
        barraAlimento.incrementarNivelAlimentacion(cantidad);
    }

    public void MostrarParticulasHeno()
    {
        if (henoParticlesPrefab != null)
        {
            henoParticlesPrefab.gameObject.SetActive(true);

            var particles = Instantiate(henoParticlesPrefab, bocaCabra.position, Quaternion.identity);            
            particles.transform.SetParent(bocaCabra);

            // Ajustar la escala de las partículas
            particles.transform.localScale = Vector3.one * 0.3f;

            Destroy(particles, 3f); // Destruir las partículas después de 3 segundos
        }
        henoParticlesPrefab.gameObject.SetActive(false);
    }
}
