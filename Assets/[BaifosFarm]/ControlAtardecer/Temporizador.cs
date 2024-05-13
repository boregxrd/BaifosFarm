using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{


    private AccionesAtardecer accionesAtardecer;
    private DeteccionCabrasNegras deteccionCabrasNegras;

    private DateTime horaInicio;
    private float duracionDia = 60; // Duración de un día en segundos (2 minutos)

    public float tiempoRestante = 60; // Tiempo restante en segundos
    [SerializeField] private Text contadorText;

    private void Awake()
    {
        IniciarCuentaRegresiva();
        deteccionCabrasNegras = gameObject.AddComponent<DeteccionCabrasNegras>();
    }

    public void IniciarCuentaRegresiva()
    {
        horaInicio = DateTime.Now;
        StartCoroutine(CuentaRegresiva());
    }

    private IEnumerator CuentaRegresiva()
    {
        while (tiempoRestante > 0)
        {
            yield return new WaitForSeconds(1f);
            tiempoRestante -= 1f;

            if (contadorText != null)
            {
                contadorText.text = "Hora en el juego: " + ObtenerTemporizadorActual();
            }
        }

        EjecutarAccionesAtardecer();
    }

    private void EjecutarAccionesAtardecer()
    {
        accionesAtardecer = GetComponent<AccionesAtardecer>();
        if (accionesAtardecer != null)
        {
            StartCoroutine(accionesAtardecer.EjecutarAccionesAtardecer());
        }
    }

    private string ObtenerTemporizadorActual()
    {
        // Calcular la hora en el juego
        int horaEnJuego = Mathf.FloorToInt(6 + (1 - tiempoRestante / duracionDia) * 12); // Empieza en las 6:00, termina en las 18:00
        if (horaEnJuego >= 18)
        {
            horaEnJuego = 18; // Si es después de las 18:00, ajustar a las 18:00
        }

        // Formatear la hora en formato de 24 horas
        string horaFormateada = horaEnJuego.ToString("00") + ":00";

        return horaFormateada;
    }

}

/*
private AccionesAtardecer accionesAtardecer;
private DeteccionCabrasNegras deteccionCabrasNegras;

private void Awake()
{
    IniciarCuentaRegresiva();
    deteccionCabrasNegras = gameObject.AddComponent<DeteccionCabrasNegras>();
}

public float tiempoRestante = 120;
[SerializeField] private Text contadorText;

public void IniciarCuentaRegresiva()
{
    contadorText.text = "Tiempo restante: " + ObtenerTemporizadorActual();
    StartCoroutine(CuentaRegresiva());
}

private IEnumerator CuentaRegresiva()
{
    while (tiempoRestante > 0)
    {
        yield return new WaitForSeconds(1f);
        tiempoRestante -= 1f;
        Debug.Log(tiempoRestante.ToString());

        if (contadorText != null)
        {
            int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
            contadorText.text = "Tiempo restante: " + ObtenerTemporizadorActual();
        }
    }

    accionesAtardecer = GetComponent<AccionesAtardecer>();
    if (accionesAtardecer != null)
    {
        StartCoroutine(accionesAtardecer.EjecutarAccionesAtardecer());
    }
}

private string ObtenerTemporizadorActual()
{
    int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
    int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
    return minutos.ToString("00") + ":" + segundos.ToString("00");
}
*/
