using System.Collections.Generic;
using UnityEngine;

public class CantidadCabrasAtardecer : MonoBehaviour
{
    private static CantidadCabrasAtardecer instance;

    private CondicionesAvisos avisos;

    private List<Cabra> cabrasEnEscena = new List<Cabra>();
    private List<Cabra> cabrasBlancas = new List<Cabra>();
    private CabraNegra[] cabrasNegras;

    private int cabrasNegrasMuertas = 0;

    public int cabrasVivas { get; private set; }
    public int cabrasBlancasVivas { get; private set; }
    public int cabrasNegrasVivas { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destruye el objeto si ya hay una instancia
        }
    }

    public static CantidadCabrasAtardecer ObtenerInstancia()
    {
        return instance;
    }

    public void Calcular()
    {
        ObtenerCabrasBlancasVivas();
        ObtenerCabrasNegrasMuertas();

        cabrasVivas = cabrasEnEscena.Count - cabrasNegrasMuertas;
        cabrasBlancasVivas = cabrasBlancas.Count;
        cabrasNegrasVivas = cabrasVivas - cabrasBlancasVivas;
    }

    private void ObtenerCabrasBlancasVivas()
    {
        cabrasEnEscena = avisos.ObtenerCabrasDeEscena();
        cabrasBlancas.Clear(); // Limpiamos la lista antes de llenarla de nuevo
        foreach (Cabra cabra in cabrasEnEscena)
        {
            CabraNegra cabraNegra = cabra.GetComponent<CabraNegra>();
            if (cabraNegra == null) // Si no tiene el componente CabraNegra, es una cabra blanca
            {
                cabrasBlancas.Add(cabra);
            }
        }
    }

    private void ObtenerCabrasNegrasMuertas()
    {
        cabrasNegras = FindObjectsOfType<CabraNegra>();
        cabrasNegrasMuertas = 0; // Reiniciamos el contador antes de contar las muertas
        foreach (CabraNegra cabra in cabrasNegras)
        {
            if (cabra.cabraNegraMuerta)
            {
                cabrasNegrasMuertas++;
            }
        }
    }
}
