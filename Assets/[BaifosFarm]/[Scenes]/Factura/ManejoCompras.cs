using UnityEngine;

public class ManejoCompras : MonoBehaviour 
{
    public SistemaMonetario sistemaMonetario;
    UIFactura uIFactura;
    ContadorCabras contadorCabras;
    public int costoCabra = 20;
    public int costoAlimentacion = 5;
    public int costoHenoEspecial = 20;
    public int gananciaLeche = 10;
    public int cabrasMaximas = 20;

    private void Awake()
    {
        contadorCabras = FindObjectOfType<ContadorCabras>();
        uIFactura = GetComponent<UIFactura>();
    }

    public void ComprarCabra()
    {
        int dinero = PlayerPrefs.GetInt("DineroTotal", 0);
        if (PuedeComprarCabra(dinero))
        {
            sistemaMonetario.RestarDinero(costoCabra);
            AsignarCabra();
            uIFactura.cabrasNuevas++;
            uIFactura.ActualizarUI();
        }
        else
        {
            Debug.Log("�No tienes suficiente dinero para comprar una cabra!");
        }
    }

    private bool PuedeComprarCabra(int dinero)
    {
        return dinero >= costoCabra &&
               contadorCabras.NumCabrasGrises + contadorCabras.NumCabrasNegras < cabrasMaximas &&
               dinero - costoCabra >= (sistemaMonetario.CalcularGastoHeno() + SistemaMonetario.PRECIO_HENO_POR_CABRA);
    }

    private void AsignarCabra()
    {
        if (contadorCabras.NumCabrasNegras < 3 && UnityEngine.Random.value <= 0.3f)
        {
            contadorCabras.NuevaCabraNegra();
        }
        else
        {
            contadorCabras.NuevaCabraGris();
        }
    }

    public void ComprarHenoEspecial()
    {
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado");
        int dineroTotal = PlayerPrefs.GetInt("DineroTotal", 0);
        if (PuedeComprarHenoEspecial(dineroTotal, valorHenoMejorado))
        {
            sistemaMonetario.RestarDinero(costoHenoEspecial);
            PlayerPrefs.SetInt("HenoMejorado", 1);
            uIFactura.ActualizarUI();
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar heno especial, o ya lo has comprado!");
        }
    }

    private bool PuedeComprarHenoEspecial(int dinero, int valorHenoMejorado)
    {
        return dinero >= costoHenoEspecial && valorHenoMejorado == 0 && dinero - costoHenoEspecial >= sistemaMonetario.CalcularGastoHeno();
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
