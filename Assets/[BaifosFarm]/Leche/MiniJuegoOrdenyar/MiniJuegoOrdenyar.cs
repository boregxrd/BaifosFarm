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

    private AudioSource audioSource;
    private Animator animator;

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

    Character jugador;

    private void Awake()
    {
        jugador = FindObjectOfType<Character>();
        enabled = false;
        manejarLeche = FindObjectOfType<ManejarLeche>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }


    public void IniciarOrdenyado(GameObject cabra)
    {
        enabled = true;
        // Debug.Log("IniciarOrdenyado");
        instanciaCabra = cabra.GetComponent<CabraBlancaInteracciones>();
        
    }

    private void OnEnable()
    {
        animator.SetTrigger("Abrir");
        objetoMiniJuegoOrdenyar.SetActive(true);
        ordenyoIniciado = true;
        barraOrdenyar.fillAmount = valorActual / valorMaximo;
    }

    private void Update()
    {
        if (ordenyoIniciado)
        {
            jugador.PararMovimiento();
            VaciarConElTiempo();

            if (Input.GetKeyUp(KeyCode.Q))
            {
                cerrarMiniJuego();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                incrementar();
                audioSource.Play();
            }

            if (valorActual >= valorMaximo)
            {
                valorActual = valorMaximo;
                porcentaje.text = valorActual.ToString();
                generarLeche();
            }

            if (instanciaCabra.IsDestroyed()) {
                cerrarMiniJuego();
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
            cerrarMiniJuego();

        }
    }

    private void generarLeche()
    {
        manejarLeche.CogerLeche(prefabLeche);
        cerrarMiniJuego();
    }

    public void cerrarMiniJuego()
    {
        animator.SetTrigger("Cerrar");
    }

    public void resetearMiniJuego()
    {
        valorActual = 15f;
        enabled = false;
        miniJuegoReseteado = true;
        ordenyoIniciado = false;
        if(instanciaCabra != null) instanciaCabra.ResetearLeche();
        jugador.ContinuarMovimiento();
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
