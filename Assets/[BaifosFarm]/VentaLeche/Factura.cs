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
        cabrasNuevas = 0;
        ActualizarTexto();
    }

    public void comprarCabra()
    {
        // Get the current value from PlayerPrefs and add 1 to it
        // int currentValue = PlayerPrefs.GetInt("YourKey", 0);
        // currentValue++;
        // PlayerPrefs.SetInt("YourKey", currentValue);
        // comprobar si hay cabra negra
        // si no hay 1/10 de que salga 
        // si sale añadir cabra negra 
        // si no sale o si ya hay negra anyadir blanca
        // añadir cabra nueva
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
