using UnityEngine;

public class ManejoCompras : MonoBehaviour 
{
    public SistemaMonetario sistemaMonetario;
    UIFactura uIFactura;
    public int numCabrasBlancas;
    public int numCabrasNegras;
    public int COSTO_CABRA = 20;
    public int COSTO_ALIMENTAR_CABRA = 5;
    public int COSTO_HENO_ESPECIAL = 20;
    public int GANANCIA_LECHE = 10;
    public int MAX_CABRAS = 20;

    private void Awake()
    {
        //sistemaMonetario = GetComponent<SistemaMonetario>();
        //sistemaMonetario = FindObjectOfType<SistemaMonetario>();
        uIFactura = GetComponent<UIFactura>();
        numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
        numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);
    }

    public void ComprarCabra()
    {
        int dinero = PlayerPrefs.GetInt("DineroTotal", 0);
        if (PuedeComprarCabra(dinero))
        {
            sistemaMonetario.RestarDinero(COSTO_CABRA);
            AsignarCabra();
            uIFactura.cabrasNuevas++;
            uIFactura.ActualizarUI();
        }
        else
        {
            Debug.Log("¡No tienes suficiente dinero para comprar una cabra!");
        }
    }

    private bool PuedeComprarCabra(int dinero)
    {
        return dinero >= COSTO_CABRA &&
               numCabrasBlancas + numCabrasNegras < MAX_CABRAS &&
               dinero - COSTO_CABRA >= (sistemaMonetario.CalcularGastoHeno() + SistemaMonetario.PRECIO_HENO_POR_CABRA);
    }

    private void AsignarCabra()
    {
        if (numCabrasNegras < 3 && UnityEngine.Random.value <= 0.3f)
        {
            numCabrasNegras++;
            PlayerPrefs.SetInt("cabrasNegras", numCabrasNegras);
        }
        else
        {
            numCabrasBlancas++;
            PlayerPrefs.SetInt("cabrasBlancas", numCabrasBlancas);
        }
    }

    public void ComprarHenoEspecial()
    {
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado");
        int dineroTotal = PlayerPrefs.GetInt("DineroTotal", 0);
        if (PuedeComprarHenoEspecial(dineroTotal, valorHenoMejorado))
        {
            sistemaMonetario.RestarDinero(COSTO_HENO_ESPECIAL);
            PlayerPrefs.SetInt("HenoMejorado", 1);
            uIFactura.ActualizarUI();
        }
        else
        {
            Debug.Log("¡No tienes suficiente dinero para comprar heno especial, o ya lo has comprado!");
        }
    }

    private bool PuedeComprarHenoEspecial(int dinero, int valorHenoMejorado)
    {
        return dinero >= COSTO_HENO_ESPECIAL && valorHenoMejorado == 0 && dinero - COSTO_HENO_ESPECIAL >= sistemaMonetario.CalcularGastoHeno();
    }

    public void RestarDinero()
    {
        sistemaMonetario.RestarDinero(sistemaMonetario.CalcularGastoHeno());
    }

    public bool EsGastoMayorQue(int dineroEnMano)
    {
        if (sistemaMonetario.CalcularGastoHeno() > dineroEnMano)
        {
            return true;
        }
        return false;
    }
}
