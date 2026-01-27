using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarraAlimento : MonoBehaviour
{
    [SerializeField] private float valorMaximo = 100f;
    public float ValorMaximo { get { return valorMaximo; } }

    private float valorActual = 100f;
    public float ValorActual { get { return valorActual; } }

    [SerializeField, Range(0f, 1f)]
    private float porcentajeMinimoTutorial = 0.6f; // 60%

    private float velocidadReduccion;
    private float velocidadReduccionInicial = 5f;
    private Image barraAlimento;

    private Cabra cabra; // Referencia a la cabra

    ContadorCabras contadorCabras;
    bool alimentacionParadaFlag = false;

    void Start()
    {
        contadorCabras = FindAnyObjectByType<ContadorCabras>();
        barraAlimento = GetComponent<Image>();
        barraAlimento.fillAmount = valorActual / valorMaximo;
        cabra = GetComponentInParent<Cabra>(); // Obtener la referencia a la cabra

        if (contadorCabras.NumCabrasBlancas > 2 && contadorCabras.NumCabrasBlancas < 5)
        {
            velocidadReduccion = velocidadReduccionInicial / contadorCabras.NumCabrasBlancas;
        }
        else if (contadorCabras.NumCabrasBlancas >= 5)
        {
            velocidadReduccion = velocidadReduccionInicial / 4f;
        }
        else
        {
            velocidadReduccion = 2;
        }
    }

    void Update()
    {
        if (alimentacionParadaFlag)
            return;

        if (valorActual > 0)
        {
            valorActual -= velocidadReduccion * Time.deltaTime;

            // Tutorial protection
            if (TutorialManager.TutorialActivo)
            {
                float minimoTutorial = valorMaximo * porcentajeMinimoTutorial;

                if (valorActual <= minimoTutorial)
                {
                    valorActual = minimoTutorial;
                    Debug.Log("BarraAlimento pausado por tutorial");
                    Pausar();
                }
            }

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

        // Activar particulas de heno si se incrementa la alimentacion
        if (incremento > 0)
        {
            cabra.MostrarParticulasHeno();
        }
    }

    public void Pausar()
    {
        alimentacionParadaFlag = true;
    }

    public void Reanudar()
    {
        alimentacionParadaFlag = false;
    }
}
