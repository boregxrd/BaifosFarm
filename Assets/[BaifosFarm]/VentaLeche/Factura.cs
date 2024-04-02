using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Factura : MonoBehaviour
{
    public Text txtFactura;
    public int cabrasNuevas;
    private void Awake()
    {
        Debug.Log("INICIO FACTURA");
        cabrasNuevas = 0;
        ActualizarTexto();
    }

    public void comprarCabra()
    {
        // Get valores de PlayerPrefs
        int numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
        int numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);
        Debug.Log("GET DONE: " + numCabrasBlancas + ", " + numCabrasNegras);

        // comprobar si hay cabra negra
        if (numCabrasNegras == 0)
        {
            Debug.Log("no hay negra");
            // si no hay, 1/10 de que salga 
            float random = Random.value;
            if (random <= 0.1f)
            {
                Debug.Log("salio negra");
                // si sale añadir cabra negra 
                numCabrasNegras++;
            }
            Debug.Log("no salio negra");
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
    }
}
