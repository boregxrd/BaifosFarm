using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraAlimento : MonoBehaviour
{
    private float valorMaximo = 100f;
    public float valorActual = 100f;
    [SerializeField] private float velocidadReduccion = 40f; // Velocidad a la que se reduce la barra de alimentacion

    private Image barraAlimento;
    [SerializeField] private GameObject cabra;
    [SerializeField] private GameObject canvasBarra;

    // ref al otro script
    public ControladorCabras controladorCabras;

    [SerializeField] private GameObject personaje;
    [SerializeField] private ControladorAccionesPersonaje controladorAccionesPersonaje;
    [SerializeField] private CabraNegra cabraNegra;


    void Start()
    {
        barraAlimento = GetComponent<Image>();
        barraAlimento.fillAmount = valorActual / valorMaximo; // Aseg�rate de que la barra se inicialice correctamente

        //Para encontrar el script ControladorAccionesPersonaje en Personaje:
        personaje = GameObject.Find("Personaje");

        
        var children = personaje.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            if (child.name == "Mano")
            {
                controladorAccionesPersonaje = child.GetComponent<ControladorAccionesPersonaje>();
            }
        }
        
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
            if (cabra != null)
            {
                controladorAccionesPersonaje.cabraMuerta = true;

                // bajar numCabras del color
                if (cabra.CompareTag("cabraBlanca"))
                {
                    controladorCabras.disminuirNumCabrasBlancas();
                    Destroy(cabra);
                }
                else if (cabra.CompareTag("cabraNegra"))
                {
                    controladorCabras.disminuirNumCabrasNegras();
                    cabraNegra.MuerteDeCabraNegra();
                    canvasBarra.SetActive(false);
                }
            }
        }
    }

    public void incrementarNivelAlimentacion(float incremento)
    {
        float valorActualProvisional = valorActual;

        if ((valorActualProvisional += incremento) > valorMaximo)
        {
            incremento = (valorMaximo - valorActual); //El nivel nunca pasara del valor maximo
        }
        valorActual += incremento;
    }
}
