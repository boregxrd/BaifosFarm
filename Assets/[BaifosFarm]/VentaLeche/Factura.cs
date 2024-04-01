using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Factura : MonoBehaviour
{
    public Text txtFactura;
    public int cabrasNuevas;
    private void Awake() {
        ActualizarTexto();
    }

    public void comprarCabra() {
        cabrasNuevas++;
        PlayerPrefs.SetInt("cabrasNuevas", cabrasNuevas);
        ActualizarTexto();
    }

    public void continuar() {
        SceneManager.LoadScene("Juego");
    }

    private void ActualizarTexto() {
        int leches = PlayerPrefs.GetInt("LechesGuardadas", 0);
        txtFactura.text = "Leche vendida - " + leches.ToString();
        if(cabrasNuevas >= 1) {
            txtFactura.text += "\nCabras nuevas - " + cabrasNuevas.ToString();
        }
    }
}
