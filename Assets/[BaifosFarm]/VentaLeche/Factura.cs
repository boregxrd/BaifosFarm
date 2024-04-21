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
        else if (dineroTotal > 1250)
        {
            Debug.Log("Entra al if del invoke victoria dinero");
            OnMoneyVictory?.Invoke();
        }
    }

    public void comprarCabra()
    {
        // Verificar si el jugador tiene suficiente dinero para comprar una cabra y si tiene menos de 20 cabras (20 es el limite)
        if (PlayerPrefs.GetInt("DineroTotal", 0) >= COSTO_CABRA && numCabrasBlancas+numCabrasNegras < 20)
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
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado");
        //Si tienes suficiente dinero, y no has comprado heno especial aun, puede comprarlo
        if (PlayerPrefs.GetInt("DineroTotal", 0) >= COSTO_HENO_ESPECIAL && valorHenoMejorado == 0) 
        {
            sistemaMonetario.RestarDinero(COSTO_HENO_ESPECIAL);
            PlayerPrefs.SetInt("HenoMejorado", 1);
            Debug.Log("¡Has comprado heno especial!");
            ActualizarTexto();
        }
        else
        {
            Debug.Log("¡No tienes suficiente dinero para comprar heno especial, o ya lo has comprado!");
            // Aquí puedes mostrar un mensaje al jugador indicando que no tiene suficiente dinero
        }
    }

    private void ActualizarTexto()
    {
        int leches = PlayerPrefs.GetInt("LechesGuardadas", 0);
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado");

        // Inicializar el texto con el valor de la leche vendida
        txtFactura.text = "Leche vendida - " + leches.ToString();

        // Agregar cabras compradas si hay nuevas
        if (cabrasNuevas >= 1)
        {
            txtFactura.text += "\nCabras compradas - " + cabrasNuevas.ToString();
        }

        // Agregar mensaje si se ha comprado heno especial
        if (valorHenoMejorado == 1)
        {
            txtFactura.text += "\nHeno Especial Comprado!";
        }

        // Agregar el dinero total y el gasto de heno
        txtFactura.text += "\nDinero total - $" + PlayerPrefs.GetInt("DineroTotal", 0).ToString();
        txtFactura.text += "\nGasto heno siguiente día - $" + sistemaMonetario.CalcularGastoHeno().ToString();
    }

}
