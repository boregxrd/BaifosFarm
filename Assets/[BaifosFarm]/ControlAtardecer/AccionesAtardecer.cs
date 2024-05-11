using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionesAtardecer : MonoBehaviour 
{
    [SerializeField] private MovimientoCamion camion;

    public static Action OnThreeBlackGoatsVictory;

    private DeteccionCabrasNegras deteccionCabrasNegras;
    private BarrasHandler barrasHandler;
    private InteraccionesJugador interaccionesJugador;
    private ControlPrecioLeche controlPrecioLeche;
    private ControlAvisos controlAvisos;

    private void Awake()
    {
        barrasHandler = gameObject.AddComponent<BarrasHandler>();
        interaccionesJugador = FindObjectOfType<InteraccionesJugador>();
        controlPrecioLeche = FindObjectOfType<ControlPrecioLeche>();
        controlAvisos = FindObjectOfType<ControlAvisos>();
        
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
        Debug.Log("Se ejecutan restantes");
        controlPrecioLeche.SumarDineroPorBotella();
        VerificarYCargarEscena();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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


