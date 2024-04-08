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
        /* if (instance == null)
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
        } */
        totalDinero = PlayerPrefs.GetInt("DineroTotal", 0);
        Debug.Log(totalDinero);
    }

    public void AgregarDinero(int cantidad)
    {
        totalDinero = PlayerPrefs.GetInt("DineroTotal", 0);
        totalDinero += cantidad;
        PlayerPrefs.SetInt("DineroTotal", totalDinero);
    }

    public void RestarDinero(int cantidad)
    {
        totalDinero = PlayerPrefs.GetInt("DineroTotal", 0);
        totalDinero -= cantidad;
        if (totalDinero < 0)
        {
            Debug.Log("Dinero negativo alcanzado");
            totalDinero = 0;
        }
        PlayerPrefs.SetInt("DineroTotal", totalDinero);
    }
}
