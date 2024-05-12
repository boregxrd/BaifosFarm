using UnityEngine;

public class RotarLuzDiurna : MonoBehaviour
{
    public float anguloInicial = -30f; // Ángulo inicial de rotación
    public float anguloFinal = 180f; // Ángulo final de rotación
    private float tiempoTotalRotacion; // Tiempo total para rotar desde el ángulo inicial al final
    private float velocidadRotacion; // Velocidad de rotación calculada en función del tiempo total

    private void Start()
    {
        // Obtener la referencia al script de control de tiempo
        Temporizador temporizador = FindObjectOfType<Temporizador>();

        // Calcular el tiempo total de rotación
        tiempoTotalRotacion = temporizador.tiempoRestante;

        // Calcular la velocidad de rotación en función del tiempo total
        velocidadRotacion = (anguloFinal - anguloInicial) / tiempoTotalRotacion;

        // Establecer la posición fija en el eje X
        transform.rotation = Quaternion.Euler(50f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    private void Update()
    {
        // Obtener el tiempo transcurrido desde el inicio del juego
        float tiempoTranscurrido = Time.timeSinceLevelLoad;

        // Calcular el ángulo actual de rotación
        float anguloActual = Mathf.Lerp(anguloInicial, anguloFinal, tiempoTranscurrido / tiempoTotalRotacion);

        // Construir la rotación actual manteniendo la posición fija en el eje X
        Quaternion rotacionActual = Quaternion.Euler(50f, anguloActual, 0f);

        // Aplicar la rotación actual
        transform.rotation = rotacionActual;
    }
}
