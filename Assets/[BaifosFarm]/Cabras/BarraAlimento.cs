using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarraAlimento : MonoBehaviour
{
    [SerializeField] private float valorMaximo = 100f;
    public float ValorMaximo { get { return valorMaximo; } }

    private float valorActual = 100f;
    public float ValorActual { get { return valorActual; }
    }

    [SerializeField] private float velocidadReduccion = 2f;
    private Image barraAlimento;

    void Start()
    {
        barraAlimento = GetComponent<Image>();
        barraAlimento.fillAmount = valorActual / valorMaximo;
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
    }
}
