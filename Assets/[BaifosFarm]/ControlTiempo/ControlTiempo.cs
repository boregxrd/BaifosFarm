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
    public GameObject spawnerCabras;

    void Awake()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("LechesGuardadas", 0);
        dineroTotal = PlayerPrefs.GetInt("DineroTotal", 0);
        if (contadorText == null)
        {
            contadorText = GetComponent<Text>();
        }
        contadorText.text = "Tiempo restante: " + obtenerTemporizadorActual();
        // Comenzar la cuenta regresiva
        StartCoroutine(CuentaRegresiva());

        sistemaMonetario = FindObjectOfType<SistemaMonetario>();

        // Actualizar el texto del dinero total
        textoDinero.text = "Dinero: $" + dineroTotal.ToString();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        alimentar = GetComponent<Alimentar>();
        alimentar.GestionarAparienciaMontonHeno();
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

        // Cuando el tiempo llega a cero...
        
        llegaCamion();
        congelarBarrasCabras();


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

        VerificarYCargarEscena();
    }

    private void congelarBarrasCabras()
    {
        Cabra[] cabrasBlancas = spawnerCabras.GetComponentsInChildren<Cabra>();
        CabraNegra[] cabrasNegras = spawnerCabras.GetComponentsInChildren<CabraNegra>();

        foreach (Cabra cabraBlanca in cabrasBlancas)
        {
            if (cabraBlanca != null)
            {
                BarraAlimento barraAlimento = cabraBlanca.GetComponent<BarraAlimento>();
                if (barraAlimento != null)
                {
                    barraAlimento.enabled = false;
                }

                BarraLeche barraLeche = cabraBlanca.GetComponent<BarraLeche>();
                if (barraLeche != null)
                {
                    barraLeche.enabled = false;
                }
            }
        }

        foreach (CabraNegra cabraNegra in cabrasNegras)
        {
            if (cabraNegra != null)
            {
                BarraAlimento barraAlimento = cabraNegra.GetComponent<BarraAlimento>();
                if (barraAlimento != null)
                {
                    barraAlimento.enabled = false;
                }

                BarraLeche barraLeche = cabraNegra.GetComponent<BarraLeche>();
                if (barraLeche != null)
                {
                    barraLeche.enabled = false;
                }
            }
        }
    }

    private static IEnumerator llegaCamion()
    {
        GameObject camion = GameObject.Find("Camion");
        LlegadaCamión llegadaCamión = camion.GetComponent<LlegadaCamión>();
        llegadaCamión.empezarMovimientoCamion();

        while (llegadaCamión.enMovimiento)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);
    }

    void VerificarYCargarEscena()
    {
        CabraNegra[] cabrasNegras = FindObjectsOfType<CabraNegra>();
        foreach (CabraNegra cabra in cabrasNegras)
        {
            cabra.DestruirCabrasNegrasMuertas();
        }
        SceneManager.LoadScene("Factura");
    }
    private string obtenerTemporizadorActual()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        return minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}
