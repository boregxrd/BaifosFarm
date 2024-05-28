using UnityEngine;
using UnityEngine.UI;

public class RotarLuzDiurna : MonoBehaviour
{
    public float anguloInicial = -30f; // Ángulo inicial de rotación
    public float anguloFinal = 180f; // Ángulo final de rotación
    private float tiempoTotalRotacion; // Tiempo total para rotar desde el ángulo inicial al final
    private float velocidadRotacion; // Velocidad de rotación calculada en función del tiempo total
    public Color colorInicial = new Color(1f, 0.96f, 0.84f); // Color inicial (FFF4D6)
    public Color colorFinal = new Color(1f, 0.73f, 0f); // Color final (FFBB00)
    private Temporizador temporizador; // Referencia al script de Temporizador
    private Light luz; // Referencia al componente Light

    private void Start()
    {
        // Obtener la referencia al script de Temporizador
        temporizador = FindObjectOfType<Temporizador>();

        // Obtener la referencia al componente Light
        luz = GetComponent<Light>();

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

        // Calcular el color actual mediante interpolación
        Color colorActual = Color.Lerp(colorInicial, colorFinal, tiempoTranscurrido / tiempoTotalRotacion);

        // Aplicar el color al componente de luz
        luz.color = colorActual;
    }
}
