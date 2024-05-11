using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionesAtardecer : MonoBehaviour 
{
    [SerializeField] private MovimientoCamion camion;
    private ControlPrecioLeche controlPrecioLeche;
    private DeteccionCabrasNegras deteccionCabrasNegras;
    public static Action OnThreeBlackGoatsVictory;

    private ControlAvisos controlAvisos;

    private void Awake()
    {
        // Obtener la referencia al componente MovimientoCamion
        camion = FindObjectOfType<MovimientoCamion>();

        // Verificar si la referencia es válida
        if (camion != null)
        {
            // Suscribirse al evento
            camion.CamionLlegoADestino += EjecutarAccionesRestantes;
        }
        else
        {
            Debug.LogError("No se encontró el componente MovimientoCamion.");
        }
    }


    public IEnumerator EjecutarAccionesAtardecer()
    {
        DesabilitarInteraccionesJugador();
        CongelarBarrasCabras();
        EsconderAvisos();
        
        yield return StartCoroutine(camion.EmpezarMovimiento());
    }

    private void EjecutarAccionesRestantes()
    {
        Debug.Log("Se ejecutan restantes");
        CalcularDinero();
        VerificarYCargarEscena();
        OcultarCursor();
    }

    public void CalcularDinero()
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

    private void DesabilitarInteraccionesJugador()
    {
        InteraccionesJugador interaccionesJugador = GetComponent<InteraccionesJugador>();
        if (interaccionesJugador != null)
        {
            interaccionesJugador.enabled = false;
        }
    }

    private void CongelarBarrasCabras()
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
        deteccionCabrasNegras = GetComponent<DeteccionCabrasNegras>();
        Debug.Log("Si no hay nada debajo deteccion es nulo");
        if(deteccionCabrasNegras != null)
        {
            Debug.Log("ooooo");
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
}


