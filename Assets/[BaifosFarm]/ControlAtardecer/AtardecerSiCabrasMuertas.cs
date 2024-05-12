using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtardecerSiCabrasMuertas : MonoBehaviour
{
    private Temporizador temporizador;

    [SerializeField] private List<Cabra> cabrasEscena;
    CantidadCabrasAtardecer cantidadCabrasAtardecer;
    CondicionesAvisos avisos;

    private void Awake()
    {
        //cantidadCabrasAtardecer = CantidadCabrasAtardecer.ObtenerInstancia();
        avisos = FindObjectOfType<CondicionesAvisos>();
        temporizador = FindObjectOfType<Temporizador>();
    }

    private void Update()
    {
        //cantidadCabrasAtardecer.Calcular();

        /*if (cantidadCabrasAtardecer.cabrasVivas == 0 ) 
        {*/
        if (avisos.ObtenerCabrasDeEscena().Count == 0) 
        { 
            if(temporizador.tiempoRestante > 5f)
            {
                temporizador.tiempoRestante = 1f;
            }
            
        }
    }
}
