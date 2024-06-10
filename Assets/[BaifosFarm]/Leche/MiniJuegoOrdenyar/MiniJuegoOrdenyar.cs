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


    [SerializeField] private float valorMaximo = 100f;
    [SerializeField] private float valorActual = 15f;
    [SerializeField] private float velocidadVaciado = 5f;
    [SerializeField] private float incremento = 15f;

    [SerializeField] private Image barraOrdenyar;
    [SerializeField] private Image iconoProgreso;

    [SerializeField] private GameObject prefabLeche;
    [SerializeField] private ManejarLeche manejarLeche;

    private bool ordenyoIniciado = false;
    public bool miniJuegoReseteado = false;

    [SerializeField] private CabraBlancaInteracciones instanciaCabra;

    private void Awake()
    {
        enabled = false;
        manejarLeche = FindObjectOfType<ManejarLeche>();
    }


    public void IniciarOrdenyado(GameObject cabra)
    {
        enabled = true;
        // Debug.Log("IniciarOrdenyado");
        instanciaCabra = cabra.GetComponent<CabraBlancaInteracciones>();
        
    }

    private void OnEnable()
    {
        objetoMiniJuegoOrdenyar.SetActive(true);
        ordenyoIniciado = true;
        barraOrdenyar.fillAmount = valorActual / valorMaximo;
    }

    private void Update()
    {
        if (ordenyoIniciado)
        {
            VaciarConElTiempo();

            if (Input.GetKeyUp(KeyCode.Q))
            {
                resetearMiniJuego();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                incrementar();
            }

            if (valorActual >= valorMaximo)
            {
                valorActual = valorMaximo;
                porcentaje.text = valorActual.ToString();
                generarLeche();
            }

            float barraWidth = barraOrdenyar.rectTransform.rect.width;
            float iconoPosX = barraOrdenyar.rectTransform.position.x + barraWidth * barraOrdenyar.fillAmount - barraWidth / 2f;
            iconoProgreso.rectTransform.position = new Vector3(iconoPosX, iconoProgreso.rectTransform.position.y, iconoProgreso.rectTransform.position.z);
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
        ordenyoIniciado = false;
        instanciaCabra.ResetearLeche();
        
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
