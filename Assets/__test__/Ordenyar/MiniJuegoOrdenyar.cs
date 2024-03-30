using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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


    void Start()
    {
        objetoMiniJuegoOrdenyar.SetActive(false);
        barraOrdenyar.fillAmount = valorActual / valorMaximo;
    }

    private void Update()
    {

        VaciarConElTiempo();

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            objetoMiniJuegoOrdenyar.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            incrementar();
        }

        if(valorActual >= valorMaximo)
        {
            valorActual = valorMaximo;
            objetoMiniJuegoOrdenyar.SetActive(false);
            generarLeche();
        }

    }

    private void incrementar()
    {
        valorActual += incremento;
        barraOrdenyar.fillAmount = valorActual / valorMaximo;
    }

    private void VaciarConElTiempo()
    {
        if (valorActual > 0)
        {
            valorActual -= velocidadVaciado * Time.deltaTime;
            barraOrdenyar.fillAmount = valorActual / valorMaximo; // Actualiza la barra de alimentaci�n visualmente
        }
        else //si la barra llega a 0
        {
            valorActual = 0;
            objetoMiniJuegoOrdenyar.SetActive(false);
        }
    }

    private void generarLeche()
    {
        leche = Instantiate(prefabLeche);

        leche.GetComponent<Rigidbody>().useGravity = false;
        leche.GetComponent<Rigidbody>().isKinematic = true;

        leche.transform.position = controladorAccionesPersonaje.puntoDeMano.transform.position;
        leche.transform.SetParent(controladorAccionesPersonaje.puntoDeMano.transform);
        controladorAccionesPersonaje.objetoEnMano = leche;
    }
}
