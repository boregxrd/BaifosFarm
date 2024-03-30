using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraAlimento : MonoBehaviour
{
    private float valorMaximo = 100f;
    [SerializeField] private float valorActual = 100f;
    public float velocidadReduccion = 3f; // Velocidad a la que se reduce la barra de alimentación

    private Image barraAlimento;
    public GameObject cabra;

    void Start()
    {
        barraAlimento = GetComponent<Image>();
        barraAlimento.fillAmount = valorActual / valorMaximo; // Asegúrate de que la barra se inicialice correctamente
    }

    void Update()
    {
        // Reducir la barra de alimentación con el tiempo
        if (valorActual > 0)
        {
            valorActual -= velocidadReduccion * Time.deltaTime; // Reduce el valor de la alimentación con el tiempo
            barraAlimento.fillAmount = valorActual / valorMaximo; // Actualiza la barra de alimentación visualmente
        }
        else
        {
            // Destruir la cabra cuando la barra de alimentación llegue a cero
            if (cabra != null)
            {
                Destroy(cabra);
            }
        }
    }

    public void incrementarNivelAlimentacion(float incremento)
    {
        float valorActualProvisional = valorActual;


        if((valorActualProvisional += incremento) > valorMaximo)
        {
            incremento = (valorMaximo - valorActual); //El nivel nunca pasará del valor máximo
            valorActual += incremento;
        }
        else
        {
            valorActual += incremento;
        }
    }



}
