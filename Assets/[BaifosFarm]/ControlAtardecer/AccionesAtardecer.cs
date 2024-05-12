using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionesAtardecer : MonoBehaviour 
{
    [SerializeField] private MovimientoCamion camion;
    private DeteccionCabrasNegras deteccionCabrasNegras;
    private BarrasHandler barrasHandler;
    private InteraccionesJugador interaccionesJugador;
    private ControlPrecioLeche controlPrecioLeche;
    private ControlAvisos controlAvisos;
    private CantidadCabrasAtardecer cantidadCabrasAtardecer;


    private void Awake()
    {
        barrasHandler = gameObject.AddComponent<BarrasHandler>();
        interaccionesJugador = FindObjectOfType<InteraccionesJugador>();
        controlPrecioLeche = FindObjectOfType<ControlPrecioLeche>();
        controlAvisos = FindObjectOfType<ControlAvisos>();
        deteccionCabrasNegras = GetComponent<DeteccionCabrasNegras>();
        cantidadCabrasAtardecer = GetComponent<CantidadCabrasAtardecer>();

        camion = FindObjectOfType<MovimientoCamion>();
        if (camion != null)
        {
            camion.CamionLlegoADestino += EjecutarAccionesRestantes;
        }
    }

    public IEnumerator EjecutarAccionesAtardecer()
    {
        interaccionesJugador.DesabilitarInteraccionesJugador();
        barrasHandler.CongelarBarrasCabras();
        controlAvisos.EsconderTodosLosAvisos();
        
        yield return StartCoroutine(camion.EmpezarMovimiento());
    }

    private void EjecutarAccionesRestantes()
    {
        controlPrecioLeche.SumarDineroPorBotella();
        cantidadCabrasAtardecer.Calcular();
        deteccionCabrasNegras.InvocarVictoria();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}


