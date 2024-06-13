using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtardecerSiCabrasMuertas : MonoBehaviour
{
    private Temporizador temporizador;
    CondicionesAvisos condicionesAvisos;
    private List<Cabra> cabrasEscena;
    private DeteccionCabrasNegras deteccionCabras;

    bool diaAcabando = false;

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
        if (!diaAcabando)
        {
            cabrasEscena = condicionesAvisos.ObtenerCabrasDeEscena();
            if ((cabrasEscena.Count - deteccionCabras.CabrasNegrasMuertas()) == 0)
            {
                if (temporizador.tiempoRestante > 3f)
                {
                    diaAcabando = true;
                    temporizador.AcabarDia();
                }
            }
        }
    }
}
