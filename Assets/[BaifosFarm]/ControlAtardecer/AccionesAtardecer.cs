using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class AccionesAtardecer : MonoBehaviour 
{
    [SerializeField] private LlegadaCamión llegadaCamion;
    private ControlPrecioLeche controlPrecioLeche;
    private DeteccionCabrasNegras deteccionCabrasNegras;
    public static Action OnThreeBlackGoatsVictory;

    private ControlAvisos controlAvisos;

    public void EjecutarAccionesAtardecer()
    {
        desabilitarInteraccionesJugador();
        EsperarAlCamion();
        congelarBarrasCabras();
        EsconderAvisos();
        VerificarYCargarEscena(); 
        OcultarCursor();
    }

    private IEnumerator EsperarAlCamion()
    {
        if (llegadaCamion != null)
        {
            llegadaCamion.empezarMovimientoCamion();
        }
        while (llegadaCamion.enMovimiento)
        {
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);
    }

    public void CalcularDinero(SistemaMonetario sistemaMonetario, ControlPrecioLeche controlPrecioBotellas)
    {
        controlPrecioLeche = FindObjectOfType<ControlPrecioLeche>();
        if (controlPrecioLeche != null)
        {
            controlPrecioLeche.SumarDineroPorBotella();
            Debug.Log("Sumo el dinero por botella");
        }
    }

    private void OcultarCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void desabilitarInteraccionesJugador()
    {
        InteraccionesJugador interaccionesJugador = GetComponent<InteraccionesJugador>();
        if (interaccionesJugador != null)
        {
            interaccionesJugador.enabled = false;
        }
    }

    private void congelarBarrasCabras()
    {
        BarraAlimento[] barrasAlimento = FindObjectsOfType<BarraAlimento>();
        BarraLeche[] barrasLeche = FindObjectsOfType<BarraLeche>();

        foreach (BarraAlimento barraAlimento in barrasAlimento)
        {
            barraAlimento.enabled = false;
        }

        foreach (BarraLeche barraLeche in barrasLeche)
        {
            barraLeche.enabled = false;
        }
    }

    private void EsconderAvisos()
    {
        controlAvisos = FindObjectOfType<ControlAvisos>();
        controlAvisos.gameObject.SetActive(false);
    }


    void VerificarYCargarEscena()
    {
        if (deteccionCabrasNegras.CuidasteLasCabrasNegrasAlFinal())
        {
            Debug.Log("Intento invocar al evento");
            OnThreeBlackGoatsVictory?.Invoke();
            return;
        }
        else
        {
            deteccionCabrasNegras.DestruirCabrasCadaUna();
            SceneManager.LoadScene("Factura");
        }
    }
}


