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
    private void Awake()
    {
        Debug.Log("INICIO FACTURA");
        cabrasNuevas = 0;
        ActualizarTexto();
    }

    public void comprarCabra()
    {
        int costoCabra = 20;
        if (PlayerPrefs.GetInt("DineroTotal", 0) >= costoCabra)
        {
            sistemaMonetario.RestarDinero(costoCabra);

            // Get valores de PlayerPrefs
            int numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
            int numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);

            // comprobar si hay cabra negra y 10% de que salga 
            if (numCabrasNegras == 0 && Random.value <= 0.1f)
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
