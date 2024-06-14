using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] Button btCabras;
    [SerializeField] Button btHenoEspecial;

    private void Awake()
    {
        contadorCabras = FindObjectOfType<ContadorCabras>();
        contadorDinero = FindObjectOfType<ContadorDinero>();
        uIFactura = GetComponent<UIFactura>();
    }

    private void Update() {
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado");
        if(!PuedeComprarCabra(contadorDinero.Dinero)) btCabras.interactable = false;
        if(!PuedeComprarHenoEspecial(contadorDinero.Dinero, valorHenoMejorado)) btHenoEspecial.interactable = false;
    }

    public void ComprarCabra()
    {
        if (PuedeComprarCabra(contadorDinero.Dinero))
        {
            contadorDinero.RestarDinero(costoCabra);
            AsignarCabra();
            uIFactura.cabrasNuevas++;
            uIFactura.ActualizarUI();

            if (PuedeComprarCabra(contadorDinero.Dinero) == false) btCabras.interactable = false;
        }
    }

    private bool PuedeComprarCabra(int dinero)
    {
        if (dinero >= costoCabra &&
               contadorCabras.NumCabrasBlancas + contadorCabras.NumCabrasNegras < cabrasMaximas &&
               dinero - costoCabra >= (CalcularGastoHeno() + precioHenoPorCabra)) return true;
        else return false;
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

        if (PuedeComprarHenoEspecial(contadorDinero.Dinero, valorHenoMejorado))
        {
            contadorDinero.RestarDinero(costoHenoEspecial);
            PlayerPrefs.SetInt("HenoMejorado", 1);
            uIFactura.ActualizarUI();

            if (!PuedeComprarHenoEspecial(contadorDinero.Dinero, valorHenoMejorado)) btHenoEspecial.interactable = false;
        }
    }

    private bool PuedeComprarHenoEspecial(int dinero, int valorHenoMejorado)
    {
        if (dinero >= costoHenoEspecial && valorHenoMejorado == 0 && dinero - costoHenoEspecial >= CalcularGastoHeno()) return true;
        else return false;
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
