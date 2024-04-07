using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMonetario : MonoBehaviour
{
    private static SistemaMonetario instance;
    public int totalDinero;

    public static SistemaMonetario Instance
    {
        get { return instance; }
    }

    // Asegurar que solo haya una instancia del SistemaMonetario
    void Awake()
    {
        if (instance == null)
        {
            // Mantener este objeto en todas las escenas
            DontDestroyOnLoad(gameObject);
            instance = this;
            PlayerPrefs.SetInt("DineroTotal", totalDinero); // Guardar el valor predeterminado
        }
        else
        {
            // Destruir objetos duplicados
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("DineroTotal"))
        {
            totalDinero = PlayerPrefs.GetInt("DineroTotal");
        }
        else
        {
            // Si no hay dinero guardado, usar un valor predeterminado
            totalDinero = 100; // Por ejemplo, 100$
            PlayerPrefs.SetInt("DineroTotal", totalDinero); // Guardar el valor predeterminado
        }
    }

    public void AgregarDinero(int cantidad)
    {
        totalDinero += cantidad;
    }

    public void RestarDinero(int cantidad)
    {
        totalDinero -= cantidad;
        if (totalDinero < 0)
        {
            totalDinero = 0;
        }
        PlayerPrefs.SetInt("DineroTotal", ObtenerTotalDinero());
    }

    public int ObtenerTotalDinero()
    {
        return totalDinero;
    }
}
