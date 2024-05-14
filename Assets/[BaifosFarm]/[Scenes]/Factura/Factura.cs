using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Factura : MonoBehaviour
{
    public int cabrasNuevas = 0;
    public SistemaMonetario sistemaMonetario; // Referencia al Singleton del SistemaMonetario

    private const int COSTO_CABRA = 20;
    private const int COSTO_ALIMENTAR_CABRA = 5;
    private const int COSTO_HENO_ESPECIAL = 20;
    private const int GANANCIA_LECHE = 10;

    private int numCabrasBlancas;
    private int numCabrasNegras;

    //CantidadCabrasAtardecer cantidadCabrasAtardecer;
    
    public static Action OnGameOver; 
    public static Action OnMoneyVictory;

    // textos 
    [SerializeField] Text cantidadLeche;
    [SerializeField] Text cantidadCabras;
    [SerializeField] Text gananciaLeche;
    [SerializeField] Text costoHeno;
    [SerializeField] Text costoCabras;
    [SerializeField] GameObject henoEspecial;
    [SerializeField] GameObject objCabras;
    [SerializeField] Text dineroTotal;
    [SerializeField] Text contadorDinero;

    // valores para total
    int dinero;
    int sumaDinero;
    int dineroLeche;
    int dineroCabras;
    int dineroHeno;
    int dineroHenoEspecial;

    MenuDerrota menuDerrota;

    PopUpsFacturaTutorial popUpsFacturaTutorial;

    private void Awake()
    {
        //cantidadCabrasAtardecer = CantidadCabrasAtardecer.ObtenerInstancia();
        popUpsFacturaTutorial = GetComponent<PopUpsFacturaTutorial>();
        menuDerrota = FindObjectOfType<MenuDerrota>();

        numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
        numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);
        dinero = PlayerPrefs.GetInt("DineroTotal", 0);
        PlayerPrefs.SetInt("HenoMejorado", 0);

        ActualizarTexto();
    }

    private void Start()
    {
        contadorDinero.text = dinero.ToString();
        cantidadLeche.text = PlayerPrefs.GetInt("LechesGuardadas", 0).ToString(); 

        if (PlayerPrefs.GetInt("TutorialCompleto") == 0)
        {
            
            StartCoroutine(popUpsFacturaTutorial.ShowPopUps());
        }
        else
        {
            popUpsFacturaTutorial.HidePopUps();
        }

        //Debug.Log("cabras negras: " + numCabrasNegras);
        //Debug.Log("cabras blancas: " + numCabrasBlancas);
        //Debug.Log("dinero: " + dinero);
        //Debug.Log("COSTOCABRA + COSTOALIMENTAR: " + (COSTO_ALIMENTAR_CABRA + COSTO_CABRA));
        //Debug.Log("Gastodiario: " + sistemaMonetario.CalcularGastoHeno());
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
            //menuDerrota.ShowMenu();
        }

        else if (dinero >= 200)
        {
            OnMoneyVictory?.Invoke();
        }
    }

    private bool IsGameOver()
    {
        if ((numCabrasBlancas + numCabrasNegras) == 0 && dinero < COSTO_CABRA + COSTO_ALIMENTAR_CABRA)
        {
            return true;
        }
        else if (sistemaMonetario.CalcularGastoHeno() > dinero)
        {
            return true;
        }
        return false;
    }

    public void ComprarCabra()
    {
        dinero = PlayerPrefs.GetInt("DineroTotal", 0);
        // Verificar si el jugador tiene suficiente dinero para comprar una cabra y si tiene menos de 20 cabras (20 es el limite)
        //tambien si tiene suficiente dinero para comprar heno para el siguiente dia
        if (dinero >= COSTO_CABRA && numCabrasBlancas + numCabrasNegras < 20 && dinero - COSTO_CABRA >= (sistemaMonetario.CalcularGastoHeno() + SistemaMonetario.PRECIO_HENO_POR_CABRA))
        {
            // Restar el costo de la cabra del dinero total
            sistemaMonetario.RestarDinero(COSTO_CABRA);


            // comprobar si hay cabra negra y 10% de que salga 
            if (numCabrasNegras < 3 && UnityEngine.Random.value <= 0.3f)
            {
                numCabrasNegras++;
            }
            else
            {
                numCabrasBlancas++;
            }
            PlayerPrefs.SetInt("cabrasBlancas", numCabrasBlancas);
            PlayerPrefs.SetInt("cabrasNegras", numCabrasNegras);

            cabrasNuevas++;
            dineroCabras = cabrasNuevas * COSTO_CABRA;
            ActualizarTexto();
        }
        else
        {
            Debug.Log("¡No tienes suficiente dinero para comprar una cabra!");
            // Aquí puedes mostrar un mensaje al jugador indicando que no tiene suficiente dinero
        }
    }

    public void Continuar()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Juego");
        sistemaMonetario.RestarDinero(sistemaMonetario.CalcularGastoHeno());
    }

    public void ComprarHenoEspecial()
    {
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado");
        int dineroTotal = PlayerPrefs.GetInt("DineroTotal", 0);
        //Si tienes suficiente dinero, y no has comprado heno especial aun, puede comprarlo
        if (dineroTotal >= COSTO_HENO_ESPECIAL && valorHenoMejorado == 0 && dineroTotal - COSTO_HENO_ESPECIAL >= sistemaMonetario.CalcularGastoHeno())
        {
            sistemaMonetario.RestarDinero(COSTO_HENO_ESPECIAL);
            PlayerPrefs.SetInt("HenoMejorado", 1);
            ActualizarTexto();
        }
        else
        {
            Debug.Log("¡No tienes suficiente dinero para comprar heno especial, o ya lo has comprado!");
            // Aquí puedes mostrar un mensaje al jugador indicando que no tiene suficiente dinero
        }
    }

    private void ActualizarTexto()
    {
        // cogemos valores necesarios
        int leches = PlayerPrefs.GetInt("LechesGuardadas", 0);
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado", 0);
        int cabras = numCabrasBlancas + numCabrasNegras;

        // LECHE
        cantidadLeche.text = "X" + leches.ToString();
        if (leches > 0)
        {
            dineroLeche = leches * GANANCIA_LECHE;
            gananciaLeche.text = "+" + dineroLeche;
            gananciaLeche.color = Color.green;
        }
        else
        {
            dineroLeche = 0;
            gananciaLeche.text = "0";
            gananciaLeche.color = Color.black;
        }

        // HENO
        if(cabras > 0) {
            dineroHeno = cabras * COSTO_ALIMENTAR_CABRA;
            costoHeno.text = "-" + dineroHeno;
        } else {
            dineroHeno = 0;
            costoHeno.text = "0";
        }

        // CABRAS COMPRADAS
        if (cabrasNuevas >= 1)
        {
            objCabras.SetActive(true);
            RectTransform objCabrasRect = objCabras.GetComponent<RectTransform>();
            objCabrasRect.anchoredPosition = new Vector3(-155, -36, 0);
            cantidadCabras.text = "X" + cabrasNuevas.ToString();
            costoCabras.text = "-" + dineroCabras.ToString();
        }
        else
        {
            objCabras.SetActive(false);
            dineroCabras = 0;
        }

        // HENO ESPECIAL
        if (valorHenoMejorado == 0)
        {
            henoEspecial.SetActive(false);
        }
        else
        {
            dineroHenoEspecial = COSTO_HENO_ESPECIAL;
            henoEspecial.SetActive(true);
            RectTransform objHenoEspecialRect = objCabras.GetComponent<RectTransform>();
            
            if (cabrasNuevas > 0)
            {
                objHenoEspecialRect.anchoredPosition = new Vector3(-147, -107, 226);
            }
            else
            {
                objHenoEspecialRect.anchoredPosition = new Vector3(-155, -36, 0);
            }
        }

        // TOTAL FACTURA
        sumaDinero = dineroLeche - dineroCabras - dineroHeno - dineroHenoEspecial;

        if (sumaDinero > 0)
        {
            dineroTotal.text = "+" + sumaDinero.ToString();
            dineroTotal.color = Color.green;
        }
        else if (sumaDinero < 0)
        {
            dineroTotal.text = sumaDinero.ToString();
            dineroTotal.color = Color.red;
        }
        else
        {
            dineroTotal.text = "0";
            dineroTotal.color = Color.black;
        }

        // CONTADOR DINERO
        //contadorDinero.text = (dinero + sumaDinero).ToString();
    }
}
