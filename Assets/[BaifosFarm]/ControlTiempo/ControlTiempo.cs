using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlTiempo : MonoBehaviour
{
    public Text contadorText; // Referencia al objeto Text donde se mostrará el contador
    [SerializeField]
    private float tiempoRestante = 120f; // 2 minutos en segundos

    // Awake se llama cuando se instancia el script antes de que Start sea llamado
    void Awake()
    {
        if (contadorText == null)
        {
            contadorText = GetComponent<Text>();
        }
        contadorText.text = "Tiempo restante: " + obtenerTemporizadorActual();
        // Comenzar la cuenta regresiva
        StartCoroutine(CuentaRegresiva());
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

        // Cuando el tiempo llega a cero, detener el juego
    // Time.timeScale = 0f;
    //  Debug.Log("Tiempo terminado. Juego detenido.");
        // Aquí mostrar mensaje final juego o trigger de leche o factura
        SceneManager.LoadScene("Factura");
    }
    private string obtenerTemporizadorActual(){
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        return minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}
