using UnityEngine;
using UnityEngine.UI;

public class BarraAlimento : MonoBehaviour
{
    [SerializeField] private float valorMaximo = 100f;
    public float ValorMaximo { get { return valorMaximo; } }

    private float valorActual = 100f;
    public float ValorActual { get { return valorActual; } }

    [SerializeField]
    private float velocidadReduccion = 1.7f;
    private Image barraAlimento;

    private Cabra cabra; // Referencia a la cabra

    void Start()
    {
        barraAlimento = GetComponent<Image>();
        barraAlimento.fillAmount = valorActual / valorMaximo;
        cabra = GetComponentInParent<Cabra>(); // Obtener la referencia a la cabra
    }

    void Update()
    {
        if (valorActual > 0)
        {
            valorActual -= velocidadReduccion * Time.deltaTime;
            barraAlimento.fillAmount = valorActual / valorMaximo;
        }
        else
        {
            valorActual = 0;
        }
    }

    public void incrementarNivelAlimentacion(float incremento)
    {
        float valorActualProvisional = valorActual;
        if ((valorActualProvisional += incremento) > valorMaximo)
        {
            incremento = valorMaximo - valorActual;
        }
        valorActual += incremento;
        barraAlimento.fillAmount = valorActual / valorMaximo;

        // Activar part�culas de heno si se incrementa la alimentaci�n
        if (incremento > 0)
        {
            cabra.MostrarParticulasHeno();
        }
    }
}
