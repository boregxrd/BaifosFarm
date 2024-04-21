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
    // Obtener la cantidad actual de cabras
    int numTotalCabras = numCabrasBlancas + numCabrasNegras;

    // Calcular la cantidad máxima de cabras que se pueden comprar
    int maxNewCabras = 20 - numTotalCabras;

    // Si ya se tienen 20 o más cabras, no se puede comprar más
    if (numTotalCabras >= 20)
    {
        Debug.Log("¡Se ha alcanzado el máximo de cabras, no se pueden comprar más!");
        return;
    }

    // Calcular la cantidad de cabras que se pueden comprar
    int numCabrasToBuy = Mathf.Min(maxNewCabras, cabrasNuevas);

    // Comprobar si hay suficiente dinero para comprar la cantidad especificada de cabras
    int costoTotal = COSTO_CABRA * numCabrasToBuy;
    if (PlayerPrefs.GetInt("DineroTotal", 0) >= costoTotal)
    {
        // Restar el costo de las cabras del dinero total
        sistemaMonetario.RestarDinero(costoTotal);

        // Comprar las cabras
        for (int i = 0; i < numCabrasToBuy; i++)
        {
            // Si la cantidad total de cabras alcanza 20, detener la compra
            if (numTotalCabras + i >= 20)
            {
                Debug.Log("¡Se ha alcanzado el máximo de cabras, no se pueden comprar más!");
                break;
            }

            // Decidir aleatoriamente si se compra una cabra negra
            if (numCabrasNegras < 3 && UnityEngine.Random.value <= 0.3f)
            {
                numCabrasNegras++;
            }
            else
            {
                numCabrasBlancas++;
            }
        }

        // Actualizar la cantidad de cabras en PlayerPrefs
        PlayerPrefs.SetInt("cabrasBlancas", numCabrasBlancas);
        PlayerPrefs.SetInt("cabrasNegras", numCabrasNegras);

        // Actualizar la cantidad de nuevas cabras compradas
        cabrasNuevas -= numCabrasToBuy;

        // Actualizar la interfaz de usuario
        ActualizarTexto();
    }
    else
    {
        Debug.Log("¡No tienes suficiente dinero para comprar la cantidad de cabras seleccionada!");
        // Aquí puedes mostrar un mensaje indicando que no hay suficiente dinero para comprar la cantidad de cabras especificada
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
