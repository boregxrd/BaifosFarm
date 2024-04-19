using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Factura : MonoBehaviour
{
    public Text txtFactura;
    public int cabrasNuevas;
    public SistemaMonetario sistemaMonetario; // Referencia al Singleton del SistemaMonetario

    private const int COSTO_CABRA = 20;
    private const int COSTO_HENO_ESPECIAL = 30;
    private void Awake()
    {
        cabrasNuevas = 0;
        ActualizarTexto();
        PlayerPrefs.SetInt("HenoMejorado", 0);
    }

    public void comprarCabra()
    {
        // Verificar si el jugador tiene suficiente dinero para comprar una cabra
        if (PlayerPrefs.GetInt("DineroTotal", 0) >= COSTO_CABRA)
        {
            // Restar el costo de la cabra del dinero total
            sistemaMonetario.RestarDinero(COSTO_CABRA);

            // Get valores de PlayerPrefs
            int numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
            int numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);

            // comprobar si hay cabra negra y 10% de que salga 
            if (numCabrasNegras == 0 && Random.value <= 0.3f)
            {
                numCabrasNegras++;
            }
            else
            {
                numCabrasBlancas++;
            }
            PlayerPrefs.SetInt("cabrasBlancas", numCabrasBlancas);
            PlayerPrefs.SetInt("cabrasNegras", numCabrasNegras);
            cabrasNuevas++;
            ActualizarTexto();
        }
        else
        {
            Debug.Log("¡No tienes suficiente dinero para comprar una cabra!");
            // Aquí puedes mostrar un mensaje al jugador indicando que no tiene suficiente dinero
        }
    }

    public void continuar()
    {
        SceneManager.LoadScene("Juego");
        sistemaMonetario.RestarDinero(sistemaMonetario.CalcularGastoHeno());
    }

    public void comprarHenoEspecial()
    {
        if (PlayerPrefs.GetInt("DineroTotal", 0) >= COSTO_HENO_ESPECIAL)
        {
            sistemaMonetario.RestarDinero(COSTO_HENO_ESPECIAL);
            PlayerPrefs.SetInt("HenoMejorado", 1);
            Debug.Log("¡Has comprado heno especial!");
            ActualizarTexto();
        }
        else
        {
            Debug.Log("¡No tienes suficiente dinero para comprar heno especial!");
            // Aquí puedes mostrar un mensaje al jugador indicando que no tiene suficiente dinero
        }
    }

    private void ActualizarTexto()
    {
        int leches = PlayerPrefs.GetInt("LechesGuardadas", 0);
        txtFactura.text = "Leche vendida - " + leches.ToString();
        if (cabrasNuevas >= 1)
        {
            txtFactura.text += "\nCabras nuevas - " + cabrasNuevas.ToString();
        }

        // Actualizar el dinero total en el texto
        txtFactura.text += "\nDinero total - $" + PlayerPrefs.GetInt("DineroTotal", 0).ToString();
        txtFactura.text += "\nGasto heno siguiente día - $" + sistemaMonetario.CalcularGastoHeno().ToString();
    }
}
