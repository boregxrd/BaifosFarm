using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtardecerSiCabrasMuertas : MonoBehaviour
{
    private CondicionesAvisos condicionesAvisos;
    private Temporizador temporizador;

    [SerializeField] private List<Cabra> cabrasEscena;
    CantidadCabrasAtardecer cantidadCabrasAtardecer;


    private void Awake()
    {
        cantidadCabrasAtardecer = GetComponent<CantidadCabrasAtardecer>();
        temporizador = FindObjectOfType<Temporizador>();
    }

    private void Update()
    {
        cantidadCabrasAtardecer.Calcular();

        if (cantidadCabrasAtardecer.cabrasVivas == 0 ) 
        {
            if(temporizador.tiempoRestante > 5f)
            {
                temporizador.tiempoRestante = 1f;
            }
            
        }
    }
}
