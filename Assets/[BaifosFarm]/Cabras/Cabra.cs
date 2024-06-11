using UnityEngine;

public class Cabra : MonoBehaviour
{
    [SerializeField]
    private BarraAlimento barraAlimento;
    [SerializeField]
    private BarraLeche barraLeche;
    
    private Transform bocaCabra; // Punto de emisi�n de part�culas
    [SerializeField]
    private GameObject henoParticlesPrefab; // Prefab de part�culas de heno

    private Vector3 posicionCabra;

    public Vector3 PosicionCabra { get => posicionCabra; }

    private void Awake()
    {
        bocaCabra = transform.GetChild(0).GetChild(0).GetChild(2);
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
            return -1f;
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

            // Ajustar la escala de las part�culas
            particles.transform.localScale = Vector3.one * 0.3f;

            Destroy(particles, 3f); // Destruir las part�culas despu�s de 3 segundos
        }
        henoParticlesPrefab.gameObject.SetActive(false);
    }
}
