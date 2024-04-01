using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraAlimento : MonoBehaviour
{
    private float valorMaximo = 100f;
    [SerializeField] private float valorActual = 100f;
    [SerializeField] private float velocidadReduccion = 3f; // Velocidad a la que se reduce la barra de alimentacion

    private Image barraAlimento;
    [SerializeField] private GameObject cabra;

    // ref al otro script
    public ControladorCabras controladorCabras;

    void Start()
    {
        barraAlimento = GetComponent<Image>();
        barraAlimento.fillAmount = valorActual / valorMaximo; // Asegarate de que la barra se inicialice correctamente
    }

    void Update()
    {
        // Reducir la barra de alimentacion con el tiempo
        if (valorActual > 0)
        {
            valorActual -= velocidadReduccion * Time.deltaTime; // Reduce el valor de la alimentacion con el tiempo
            barraAlimento.fillAmount = valorActual / valorMaximo; // Actualiza la barra de alimentacion visualmente
        }
        else
        {
            // Destruir la cabra cuando la barra de alimentacion llegue a cero
            if (cabra != null)
            {
                Destroy(cabra);

                // bajar numCabras del color
                if (cabra.CompareTag("cabraBlanca"))
                {
                    controladorCabras.disminuirNumCabrasBlancas();
                }
                else if (cabra.CompareTag("cabraNegra"))
                {
                    controladorCabras.disminuirNumCabrasNegras();
                }
            }
        }
    }

    public void incrementarNivelAlimentacion(float incremento)
    {
        float valorActualProvisional = valorActual;


        if((valorActualProvisional += incremento) > valorMaximo)
        {
            incremento = (valorMaximo - valorActual); //El nivel nunca pasara del valor maximo
            valorActual += incremento;
        }
        else
        {
            valorActual += incremento;
        }
    }



}
