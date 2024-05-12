using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtardecerSiCabrasMuertas : MonoBehaviour
{
    private CondicionesAvisos condicionesAvisos;
    private Temporizador temporizador;

    private List<Cabra> cabrasEscena;
    private DeteccionCabrasNegras deteccionCabras;

    private void Awake()
    {
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
