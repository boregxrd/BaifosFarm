using UnityEngine;

public class ManejoCompras : MonoBehaviour 
{
    UIFactura uIFactura;
    ContadorCabras contadorCabras;
    ContadorDinero contadorDinero;

    public int costoCabra = 20;
    public int costoAlimentacion = 5;
    public int costoHenoEspecial = 20;
    public int gananciaLeche = 10;
    public int cabrasMaximas = 20;
    public int precioHenoPorCabra = 5;

    private void Awake()
    {
        contadorCabras = FindObjectOfType<ContadorCabras>();
        contadorDinero = FindObjectOfType<ContadorDinero>();
        uIFactura = GetComponent<UIFactura>();
    }

    public void ComprarCabra()
    {
        int dinero = PlayerPrefs.GetInt("DineroTotal", 0);
        if (PuedeComprarCabra(dinero))
        {
            contadorDinero.RestarDinero(costoCabra);
            AsignarCabra();
            uIFactura.cabrasNuevas++;
            uIFactura.ActualizarUI();
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar una cabra!");
        }
    }

    private bool PuedeComprarCabra(int dinero)
    {
        return dinero >= costoCabra &&
               contadorCabras.NumCabrasBlancas + contadorCabras.NumCabrasNegras < cabrasMaximas &&
               dinero - costoCabra >= (CalcularGastoHeno() + precioHenoPorCabra);
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
            contadorDinero.RestarDinero(costoHenoEspecial);
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
        return dinero >= costoHenoEspecial && valorHenoMejorado == 0 && dinero - costoHenoEspecial >= CalcularGastoHeno();
    }

    public void RestarDinero()
    {
        contadorDinero.RestarDinero(CalcularGastoHeno());
    }

    public bool EsGastoMayorQue(int dineroEnMano)
    {
        if (CalcularGastoHeno() > dineroEnMano)
        {
            return true;
        }
        return false;
    }

    
    public int CalcularGastoHeno()
    {
        if (contadorCabras.NumCabrasBlancas + contadorCabras.NumCabrasNegras == 0)
        {
            return 0;
        }
        else
        {
            return (contadorCabras.NumCabrasBlancas + contadorCabras.NumCabrasNegras) * precioHenoPorCabra;
        }
    }
}
