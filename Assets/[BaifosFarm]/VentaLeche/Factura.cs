using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Factura : MonoBehaviour
{
    public Text txtFactura;
    public int cabrasNuevas;

    private SistemaMonetario sistemaMonetario; // Referencia al Singleton del SistemaMonetario

    private void Awake()
    {
        Debug.Log("INICIO FACTURA");
        cabrasNuevas = 0;
        sistemaMonetario = SistemaMonetario.Instance; // Obtener la instancia del Singleton
        ActualizarTexto();
    }

    public void comprarCabra()
    {
        int costoCabra = 20; // Definir el costo de la cabra aquí

        // Verificar si el jugador tiene suficiente dinero para comprar una cabra
        if (sistemaMonetario.ObtenerTotalDinero() >= costoCabra)
        {
            // Restar el costo de la cabra del dinero total
            sistemaMonetario.RestarDinero(costoCabra);

            // Realizar cualquier acción adicional necesaria para agregar la cabra al jugador
            Debug.Log("¡Has comprado una cabra!");

            // Get valores de PlayerPrefs
            int numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
            int numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);
            Debug.Log("GET DONE: " + numCabrasBlancas + ", " + numCabrasNegras);
            Debug.Log("Dinero total: $" + sistemaMonetario.ObtenerTotalDinero());

            // comprobar si hay cabra negra y 10% de que salga 
            if (numCabrasNegras == 0 && Random.value <= 0.1f)
        {
            Debug.Log("salio negra");
            // si sale añadir cabra negra 
            numCabrasNegras++;
        }
        // si no sale o si ya hay negra anyadir blanca
        else
        {
            Debug.Log("se añade blanca");
            numCabrasBlancas++;
        }
        // añadir cabras nuevas a sus PlayerPrefs'
        PlayerPrefs.SetInt("cabrasBlancas", numCabrasBlancas);
        PlayerPrefs.SetInt("cabrasNegras", numCabrasNegras);
        Debug.Log("SET DONE: " + PlayerPrefs.GetInt("cabrasBlancas", 0) + ", " + PlayerPrefs.GetInt("cabrasNegras", 0));

        cabrasNuevas++; // variable para factura
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
        txtFactura.text += "\nDinero total - $" + sistemaMonetario.ObtenerTotalDinero().ToString();
    }
}
