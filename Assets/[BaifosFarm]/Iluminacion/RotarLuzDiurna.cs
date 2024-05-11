using UnityEngine;

public class RotarLuzDiurna : MonoBehaviour
{
    public float anguloInicial = -30f; // �ngulo inicial de rotaci�n
    public float anguloFinal = 180f; // �ngulo final de rotaci�n
    private float tiempoTotalRotacion; // Tiempo total para rotar desde el �ngulo inicial al final
    private float velocidadRotacion; // Velocidad de rotaci�n calculada en funci�n del tiempo total

    private void Start()
    {
        // Obtener la referencia al script de control de tiempo
        Temporizador temporizador = FindObjectOfType<Temporizador>();

        // Calcular el tiempo total de rotaci�n
        tiempoTotalRotacion = temporizador.tiempoRestante;

        // Calcular la velocidad de rotaci�n en funci�n del tiempo total
        velocidadRotacion = (anguloFinal - anguloInicial) / tiempoTotalRotacion;

        // Establecer la posici�n fija en el eje X
        transform.rotation = Quaternion.Euler(50f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    private void Update()
    {
        // Obtener el tiempo transcurrido desde el inicio del juego
        float tiempoTranscurrido = Time.timeSinceLevelLoad;

        // Calcular el �ngulo actual de rotaci�n
        float anguloActual = Mathf.Lerp(anguloInicial, anguloFinal, tiempoTranscurrido / tiempoTotalRotacion);

        // Construir la rotaci�n actual manteniendo la posici�n fija en el eje X
        Quaternion rotacionActual = Quaternion.Euler(50f, anguloActual, 0f);

        // Aplicar la rotaci�n actual
        transform.rotation = rotacionActual;
    }
}
