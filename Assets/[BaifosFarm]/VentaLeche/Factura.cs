using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Factura : MonoBehaviour
{
    public Text txtFactura;
    public int cabrasNuevas;
    public SistemaMonetario sistemaMonetario; // Referencia al Singleton del SistemaMonetario

    private const int COSTO_CABRA = 20;
    private const int COSTO_HENO_ESPECIAL = 30;

    private int numCabrasBlancas;
    private int numCabrasNegras;
    private int dineroTotal;
    public static Action OnGameOver; // Eventos estático que se disparan al cumplirse una condicion
    public static Action OnMoneyVictory;
    public static Action OnBlackGoatsVictory;

    private void Awake()
    {
        cabrasNuevas = 0;
        ActualizarTexto();
        PlayerPrefs.SetInt("HenoMejorado", 0);
        //PlayerPrefs.SetInt("cabrasNegras", 0);
        // Get valores de PlayerPrefs
        numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
        numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);
        dineroTotal = PlayerPrefs.GetInt("DineroTotal", 0);
    }

    private void Start()
    {
        
        Debug.Log("cabras negras: " + numCabrasNegras);
        Debug.Log("cabras: " + (numCabrasBlancas + numCabrasNegras));
        Debug.Log("dinero: " + dineroTotal);

        if ((numCabrasBlancas + numCabrasNegras) == 0 && dineroTotal < COSTO_CABRA)
        {
            Debug.Log("Entra al if del invoke derrota");
            OnGameOver?.Invoke(); 
        }
        else if (dineroTotal > 250)
        {
            Debug.Log("Entra al if del invoke victoria dinero");
            OnMoneyVictory?.Invoke();
        }
    }

    public void comprarCabra()
    {
        // Verificar si el jugador tiene suficiente dinero para comprar una cabra
        if (PlayerPrefs.GetInt("DineroTotal", 0) >= COSTO_CABRA)
        {
            // Restar el costo de la cabra del dinero total
            sistemaMonetario.RestarDinero(COSTO_CABRA);

            // comprobar si hay cabra negra y 10% de que salga 
            if (numCabrasNegras < 3 && UnityEngine.Random.value <= 0.3f)
            {
                numCabrasNegras++;
            }
            else
            {
                numCabrasBlancas++;
            }
            PlayerPrefs.SetInt("cabrasBlancas", numCabrasBlancas);
            PlayerPrefs.SetInt("cabrasNegras", numCabrasNegras);
            //PlayerPrefs.SetInt("cabrasNegras", 3);
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
        if (PlayerPrefs.GetInt("TutorialCompleto", 0) == 1)
        {
            SceneManager.LoadScene("Main"); // Si el tutorial está completo, volver al menú de inicio
        }
        else
        {
            SceneManager.LoadScene("Juego"); // Si el tutorial no está completo, ir al juego
            sistemaMonetario.RestarDinero(sistemaMonetario.CalcularGastoHeno());
        }
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
