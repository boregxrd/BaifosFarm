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
    public bool lechePreparada = false;

    [SerializeField] private Image barraOrdenyar;
    


    void Start()
    {
        objetoMiniJuegoOrdenyar.SetActive(true);
        barraOrdenyar.fillAmount = valorActual / valorMaximo; // Asegúrate de que la barra se inicialice correctamente
    }

    private void Update()
    {
        
    }
}
