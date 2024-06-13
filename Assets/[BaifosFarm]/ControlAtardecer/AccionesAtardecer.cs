using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AccionesAtardecer : MonoBehaviour 
{
    private DeteccionCabrasNegras deteccionCabrasNegras;
    private BarrasHandler barrasHandler;
    private InteraccionesJugador interaccionesJugador;
    private ControlAvisos controlAvisos;
    [SerializeField] PlayableDirector animaticaCamion;
    [SerializeField] CinemachineVirtualCamera camaraJuego;
    //private CantidadCabrasAtardecer cantidadCabrasAtardecer;
    [SerializeField] private ContadorDias contadorDias;
    ContadorLeche contadorLeche;

    private void Awake()
    {
        barrasHandler = gameObject.AddComponent<BarrasHandler>();
        interaccionesJugador = FindObjectOfType<InteraccionesJugador>();
        contadorLeche = FindObjectOfType<ContadorLeche>();
        controlAvisos = FindObjectOfType<ControlAvisos>();
        deteccionCabrasNegras = GetComponent<DeteccionCabrasNegras>();
        contadorDias = FindObjectOfType<ContadorDias>();
    }

    public IEnumerator EjecutarAccionesAtardecer()
    {
        barrasHandler.CongelarBarrasCabras();
        interaccionesJugador.DesabilitarInteraccionesJugador();
        controlAvisos.EsconderTodosLosAvisos();
        
        yield return StartCoroutine(AnimaticaCamion());

        EjecutarAccionesRestantes();
    }

    private IEnumerator AnimaticaCamion()
    {
        Debug.Log("camion");
        animaticaCamion.Play();
        camaraJuego.enabled = false;
        while (animaticaCamion.state == PlayState.Playing) {
            yield return null;
        }

    }

    private void EjecutarAccionesRestantes()
    {
        deteccionCabrasNegras.InvocarVictoria();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        contadorDias.SumarUnDiaAlContador();
    }
}