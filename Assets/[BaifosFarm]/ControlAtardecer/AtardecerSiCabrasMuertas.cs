using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtardecerSiCabrasMuertas : MonoBehaviour
{
    private Temporizador temporizador;
    CondicionesAvisos condicionesAvisos;
    private List<Cabra> cabrasEscena;
    private DeteccionCabrasNegras deteccionCabras;

    /*
    [SerializeField] private List<Cabra> cabrasEscena;
    CantidadCabrasAtardecer cantidadCabrasAtardecer;
    CondicionesAvisos avisos;
    */
    private void Awake()
    {
        //cantidadCabrasAtardecer = CantidadCabrasAtardecer.ObtenerInstancia();
        condicionesAvisos = FindObjectOfType<CondicionesAvisos>();
        temporizador = FindObjectOfType<Temporizador>();
        deteccionCabras = GetComponent<DeteccionCabrasNegras>();
    }

    private void Update()
    {
        cabrasEscena = condicionesAvisos.ObtenerCabrasDeEscena();
        if((cabrasEscena.Count - deteccionCabras.CabrasNegrasMuertas()) == 0 ) 
        {
            if(temporizador.tiempoRestante > 5f)
            {
                temporizador.tiempoRestante = 1f;
            }
            
        }
    }
}
