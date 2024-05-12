using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
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
}