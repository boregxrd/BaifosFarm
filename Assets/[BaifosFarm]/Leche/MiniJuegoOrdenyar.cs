using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//Este script ha de estar en CanvasMiniJuegoOrdenyar

public class MiniJuegoOrdenyar : MonoBehaviour
{
    [SerializeField] private GameObject objetoMiniJuegoOrdenyar;
    [SerializeField] private Text porcentaje;


    private float valorMaximo = 100f;
    [SerializeField] private float valorActual = 15f;
    [SerializeField] private float velocidadVaciado = 5f;
    [SerializeField] private float incremento = 15f;

    [SerializeField] private Image barraOrdenyar;

    [SerializeField] private ControladorAccionesPersonaje controladorAccionesPersonaje;
    [SerializeField] private GameObject prefabLeche;
    [SerializeField] private GameObject leche;

    [SerializeField] private ManejarLeche manejarLeche;


    [SerializeField] private bool iniciarProceso = false;
    public bool miniJuegoReseteado = false;
    
    private void OnEnable()
    {
        objetoMiniJuegoOrdenyar.SetActive(true);
        iniciarProceso = true;
        barraOrdenyar.fillAmount = valorActual / valorMaximo;
    }

    private void Awake()
    {
        enabled = false;
        objetoMiniJuegoOrdenyar.SetActive(false);
        manejarLeche = FindObjectOfType<ManejarLeche>();
    }

    private void Update()
    {
        if (iniciarProceso)
        {
            VaciarConElTiempo();

            if(Input.GetKeyUp(KeyCode.Q))
            {
                resetearMiniJuego();
            }

            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                incrementar();
            }

            if(valorActual >= valorMaximo)
            {
                valorActual = valorMaximo;
                porcentaje.text = valorActual.ToString();
                generarLeche();
            }
        } 

    }

    private void incrementar()
    {
        valorActual += incremento;
        barraOrdenyar.fillAmount = valorActual / valorMaximo;
        mostrarPorcentaje();
    }

    private void VaciarConElTiempo()
    {
        if (valorActual > 0)
        {
            valorActual -= velocidadVaciado * Time.deltaTime;
            barraOrdenyar.fillAmount = valorActual / valorMaximo; 
            mostrarPorcentaje();
        }
        else //si la barra llega a 0
        {
            valorActual = 0;
            mostrarPorcentaje();
            resetearMiniJuego();
            
        }
    }

    private void generarLeche()
    {
        manejarLeche.CogerLeche(prefabLeche);
        resetearMiniJuego();
    }

    public void resetearMiniJuego()
    {
        valorActual = 15f;
        enabled = false;
        miniJuegoReseteado = true;
        objetoMiniJuegoOrdenyar.SetActive(false);
    }

    private void mostrarPorcentaje()
    {
        int valorRedondeado = (int)Math.Round(valorActual);
        porcentaje.text = $"{valorRedondeado}%";
    }

    private void OnDisable()
    {
        objetoMiniJuegoOrdenyar.SetActive(false);
    }

}
