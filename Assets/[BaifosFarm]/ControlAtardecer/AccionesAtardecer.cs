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
    private BarrasHandler barrasHandler;
    private InteraccionesJugador interaccionesJugador;
    private ControlAvisos controlAvisos;

    private void Awake()
    {
        barrasHandler = gameObject.AddComponent<BarrasHandler>();
        interaccionesJugador = FindObjectOfType<InteraccionesJugador>();
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


