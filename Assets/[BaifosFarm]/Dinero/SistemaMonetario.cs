
using UnityEngine;
using UnityEngine.UI;

public class SistemaMonetario : MonoBehaviour
{
    private static SistemaMonetario instance;
    public int totalDinero;
    public const int PRECIO_HENO_POR_CABRA = 5;
    [SerializeField] Text dineroTexto;

    void Awake()
    {
        totalDinero = PlayerPrefs.GetInt("DineroTotal", 0);
        dineroTexto.text = totalDinero.ToString();
    }

    public void AgregarDinero(int cantidad)
    {
        totalDinero = PlayerPrefs.GetInt("DineroTotal", 0);
        totalDinero += cantidad;
        PlayerPrefs.SetInt("DineroTotal", totalDinero);
    }

    public void RestarDinero(int cantidad)
    {
        totalDinero = PlayerPrefs.GetInt("DineroTotal", 0);
        totalDinero -= cantidad;
        if (totalDinero < 0)
        {
            Debug.Log("Dinero negativo alcanzado");
            totalDinero = 0;
        }
        PlayerPrefs.SetInt("DineroTotal", totalDinero);
    }

    public int CalcularGastoHeno()
    {
        int numCabrasBlancas = PlayerPrefs.GetInt("cabrasBlancas", 0);
        int numCabrasNegras = PlayerPrefs.GetInt("cabrasNegras", 0);

        if (numCabrasBlancas + numCabrasNegras == 0)
        {
            return 0;
        } else
        {
            return (numCabrasBlancas + numCabrasNegras) * PRECIO_HENO_POR_CABRA;
        }
    }
}
