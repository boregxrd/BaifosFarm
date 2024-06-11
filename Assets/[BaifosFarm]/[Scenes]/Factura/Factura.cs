using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Factura : MonoBehaviour
{    
    public static Action OnGameOver; 
    public static Action OnMoneyVictory;

    //CantidadCabrasAtardecer cantidadCabrasAtardecer;
    PopUpsFacturaTutorial popUpsFacturaTutorial;
    ManejoCompras manejoCompras;
    UIFactura uIFactura;
    ContadorDinero contadorDinero;
    ContadorCabras contadorCabras;

    private void Awake()
    {
        //cantidadCabrasAtardecer = CantidadCabrasAtardecer.ObtenerInstancia();
        Application.targetFrameRate = 60;
        popUpsFacturaTutorial = GetComponent<PopUpsFacturaTutorial>();
        manejoCompras = GetComponent<ManejoCompras>();
        uIFactura = GetComponent<UIFactura>();
    }

    private void Start()
    {
        contadorDinero = FindObjectOfType<ContadorDinero>();
        contadorCabras = FindObjectOfType<ContadorCabras>();
        if (PlayerPrefs.GetInt("TutorialCompleto") == 0)
        {
            
            StartCoroutine(popUpsFacturaTutorial.ShowPopUps());
        }
        else
        {
            popUpsFacturaTutorial.HidePopUps();
        }
    }

    private void Update()
    {
        VerificarCondicionesVictoriaDerrota();
    }

    private void VerificarCondicionesVictoriaDerrota()
    {
        if (IsGameOver())
        {
            OnGameOver?.Invoke();
        }
        else if (contadorDinero.Dinero >= 350)
        {
            OnMoneyVictory?.Invoke();
        }
    }

    private bool IsGameOver()
    {
        if (contadorCabras.NumCabrasBlancas == 0 && contadorDinero.Dinero < manejoCompras.costoCabra + manejoCompras.costoAlimentacion)
        {
            return true;
        }
        else if (manejoCompras.EsGastoMayorQue(contadorDinero.Dinero))
        {
            return true;
        }
        return false;
    }

    public void Continuar()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Juego");
        PlayerPrefs.SetInt("LechesGuardadas", 0);
        manejoCompras.RestarDinero();
    }

}


//debugs

//Debug.Log("cabras negras: " + numCabrasNegras);
//Debug.Log("cabras blancas: " + numCabrasBlancas);
//Debug.Log("dinero: " + dinero);
//Debug.Log("COSTOCABRA + COSTOALIMENTAR: " + (COSTO_ALIMENTAR_CABRA + COSTO_CABRA));
//Debug.Log("Gastodiario: " + sistemaMonetario.CalcularGastoHeno());