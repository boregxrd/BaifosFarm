using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraAlimento : MonoBehaviour
{
    private float valorMaximo = 100f;
    public float valorActual = 100f;
    public float velocidadReduccion = 3f; // Velocidad a la que se reduce la barra de alimentaci�n

    private Image barraAlimento;
    public GameObject cabra;

    void Start()
    {
        barraAlimento = GetComponent<Image>();
        barraAlimento.fillAmount = valorActual / valorMaximo; // Aseg�rate de que la barra se inicialice correctamente
    }

    void Update()
    {
        // Reducir la barra de alimentaci�n con el tiempo
        if (valorActual > 0)
        {
            valorActual -= velocidadReduccion * Time.deltaTime; // Reduce el valor de la alimentaci�n con el tiempo
            barraAlimento.fillAmount = valorActual / valorMaximo; // Actualiza la barra de alimentaci�n visualmente
        }
        else
        {
            // Destruir la cabra cuando la barra de alimentaci�n llegue a cero
            if (cabra != null)
            {
                Destroy(cabra);
            }
        }
    }
}
