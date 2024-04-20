using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlTiempo : MonoBehaviour
{
    public Text contadorText; // Referencia al objeto Text donde se mostrará el contador
    [SerializeField]
    public float tiempoRestante = 120f; // 2 minutos en segundos
    private Alimentar alimentar;
    public SistemaMonetario sistemaMonetario; // Referencia al C# Script de sistema de dinero
    public Text textoDinero; // Referencia al objeto de texto que mostrará el dinero total
    int dineroTotal;

    private CabraNegra[] cabrasNegras;
    private CabraNegra[] cabrasNegrasAlFinal;

    //-------------------------------------------------------------
    //  Esto debe ir en otra clase en otro momento cuando
    //  reorganizemos el codigo entre todos
    public static Action OnThreeBlackGoatsVictory;
    //-------------------------------------------------------------

    bool tresCabrasVivasAlFinal = false;

    void Awake()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("LechesGuardadas", 0);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        alimentar = GetComponent<Alimentar>();
        alimentar.GestionarAparienciaMontonHeno();

        RecogerDatosDinero();
        ActivarCuentaRegresiva();
        VerificarSiHayTresCabrasNegrasAlInicio();
    }

    private void RecogerDatosDinero()
    {
        dineroTotal = PlayerPrefs.GetInt("DineroTotal", 0);
        sistemaMonetario = FindObjectOfType<SistemaMonetario>();
        // Actualizar el texto del dinero total
        textoDinero.text = "Dinero: $" + dineroTotal.ToString();
    }

    private void ActivarCuentaRegresiva()
    {
        if (contadorText == null)
        {
            contadorText = GetComponent<Text>();
        }
        contadorText.text = "Tiempo restante: " + obtenerTemporizadorActual();
        // Comenzar la cuenta regresiva
        StartCoroutine(CuentaRegresiva());
    }

    private void VerificarSiHayTresCabrasNegrasAlInicio()
    {
        cabrasNegras = FindObjectsOfType<CabraNegra>();

        // Verifica si hay tres cabras negras al inicio
        if (cabrasNegras.Length >= 3)
        {
            int contadorCabrasNegras = cabrasNegras.Length;
            Debug.Log("cabras negras al inicio:" + contadorCabrasNegras);
        }
    }

    IEnumerator CuentaRegresiva()
    {
        while (tiempoRestante > 0)
        {

            yield return new WaitForSeconds(1f); // Esperar un segundo
            tiempoRestante -= 1f; // Restar un segundo al tiempo restante

            // Actualizar el contador Text en formato minutos:segundos
            if (contadorText != null)
            {
                int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
                int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
                contadorText.text = "Tiempo restante: " + obtenerTemporizadorActual();
            }
        }

        FinalizacionDelDia();

        TresCabrasNegrasAlFinal();

        VerificarYCargarEscena();
    }

    private IEnumerator FinalizacionDelDia()
    {
        // Cuando el tiempo llega a cero, llamar LlegadaCamion
        GameObject camion = GameObject.Find("Camion");
        LlegadaCamión llegadaCamión = camion.GetComponent<LlegadaCamión>();
        llegadaCamión.empezarMovimientoCamion();

        while (llegadaCamión.enMovimiento)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        Time.timeScale = 0f;
        // Llamada para sumar el dinero
        ControladorTextoCaja controladorTextoCaja = FindObjectOfType<ControladorTextoCaja>();
        if (controladorTextoCaja != null)
        {
            controladorTextoCaja.SumarDineroPorBotella();
        }
        // Aquí mostrar mensaje final juego o trigger de leche o factura

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void TresCabrasNegrasAlFinal()
    {
        cabrasNegrasAlFinal = FindObjectsOfType<CabraNegra>();
        Debug.Log("cabras negras al final: " + cabrasNegrasAlFinal);

        if (cabrasNegrasAlFinal.Length == cabrasNegras.Length)
        {
            tresCabrasVivasAlFinal = true;
            Debug.Log("Tres cabras vivas al final true");
        }
    }

    void VerificarYCargarEscena()
    {
        if (tresCabrasVivasAlFinal)
        {
            Debug.Log("Intento invocar al evento");
            OnThreeBlackGoatsVictory?.Invoke();
            return;
        }
        else
        {
            foreach (CabraNegra cabra in cabrasNegras)
            {
                cabra.DestruirCabrasNegrasMuertas();
            }

            SceneManager.LoadScene("Factura");
        }
    }

    private string obtenerTemporizadorActual()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        return minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}
