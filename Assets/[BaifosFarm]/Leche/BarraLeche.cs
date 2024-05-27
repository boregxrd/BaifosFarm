using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarraLeche : MonoBehaviour
{
    [SerializeField] private float valorMaximo = 100f;
    public float ValorMaximo {
        get { return valorMaximo; }
    }

    public float valorActual = 0f;
    public float ValorActual {
        get { return valorActual; }
    }

    public float valorAlerta = 30f;
    private float velocidadAumento = 4.5f;
    public bool lechePreparada = false;

    private Image barraLeche;
    [SerializeField] private BarraAlimento barraAlimento;

    private bool produccionDetenida = false;

    void Start()
    {
        barraLeche = GetComponent<Image>();
        barraLeche.fillAmount = valorActual / valorMaximo;
    }

    void Update()
    {
        if (barraAlimento == null)
        {
            Debug.LogError("BarraAlimento reference not set.");
            return;
        }

        produccionDetenida = barraAlimento.ValorActual < valorAlerta;

        if (!produccionDetenida)
        {
            if (valorActual < valorMaximo)
            {
                valorActual += velocidadAumento * Time.deltaTime;
                lechePreparada = false;
            }
            else
            {
                valorActual = valorMaximo;
                lechePreparada = true;
            }
        }
        barraLeche.fillAmount = valorActual / valorMaximo;
    }

    public void resetearLeche()
    {
        Debug.Log("ResetearLeche called");
        valorActual = 0f;
        produccionDetenida = false;
        lechePreparada = false;
        Debug.Log(valorActual + " Valor Actual after reset");
    }
}
