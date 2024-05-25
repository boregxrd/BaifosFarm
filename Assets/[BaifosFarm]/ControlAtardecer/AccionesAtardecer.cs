using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AccionesAtardecer : MonoBehaviour 
{
    private DeteccionCabrasNegras deteccionCabrasNegras;
    private BarrasHandler barrasHandler;
    private InteraccionesJugador interaccionesJugador;
    private ControlPrecioLeche controlPrecioLeche;
    private ControlAvisos controlAvisos;
    [SerializeField] PlayableDirector animaticaCamion;
    //private CantidadCabrasAtardecer cantidadCabrasAtardecer;


    private void Awake()
    {
        barrasHandler = gameObject.AddComponent<BarrasHandler>();
        interaccionesJugador = FindObjectOfType<InteraccionesJugador>();
        controlPrecioLeche = FindObjectOfType<ControlPrecioLeche>();
        controlAvisos = FindObjectOfType<ControlAvisos>();
        deteccionCabrasNegras = GetComponent<DeteccionCabrasNegras>();
    }

    public IEnumerator EjecutarAccionesAtardecer()
    {
        interaccionesJugador.DesabilitarInteraccionesJugador();
        barrasHandler.CongelarBarrasCabras();
        controlAvisos.EsconderTodosLosAvisos();
        
        yield return StartCoroutine(AnimaticaCamion());

        EjecutarAccionesRestantes();
    }

    private IEnumerator AnimaticaCamion()
    {
        animaticaCamion.Play();
        while (animaticaCamion.state == PlayState.Playing) {
            yield return null;
        }
    }

    private void EjecutarAccionesRestantes()
    {
        controlPrecioLeche.SumarDineroPorBotella();
        deteccionCabrasNegras.InvocarVictoria();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}


