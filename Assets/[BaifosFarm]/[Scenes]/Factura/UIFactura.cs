using UnityEngine;
using UnityEngine.UI;

public class UIFactura : MonoBehaviour
{
    ManejoCompras manejoCompras;
    public SistemaMonetario sistemaMonetario;

    [SerializeField] Text cantidadLeche;
    [SerializeField] Text cantidadCabras;
    [SerializeField] Text gananciaLeche;
    [SerializeField] Text costoHeno;
    [SerializeField] Text costoCabras;
    [SerializeField] GameObject henoEspecial;
    [SerializeField] GameObject objCabras;
    [SerializeField] Text dineroTotal;
    [SerializeField] Text contadorDinero;

    Color customGreen = new Color(92f / 255f, 167f / 255f, 81f / 255f);

    int sumaDinero;
    int dineroLeche;
    int dineroCabras;
    int dineroHeno;
    int dineroHenoEspecial;
    int numCabras;
    public int dinero;
    public int cabrasNuevas = 0;
    RectTransform objHenoEspecialRect;
    bool dineroSumadoFlag = false;

    public Texture2D cursorMano; // Textura del cursor de mano
    public Texture2D cursorNormal; // Textura del cursor normal
    
    private void Awake()
    {
        manejoCompras = GetComponent<ManejoCompras>();
        objHenoEspecialRect = henoEspecial.GetComponent<RectTransform>();
        PlayerPrefs.SetInt("HenoMejorado", 0);
    }

    private void Start()
    {
        contadorDinero.text = PlayerPrefs.GetInt("DineroTotal", 0).ToString();
        ActualizarUI();
    }

    public void ActualizarUI()
    {
        ActualizarCantidadLeche();
        ActualizarCostoHeno();
        ActualizarCabrasCompradas();
        ActualizarHenoEspecial();
        ActualizarTotalFactura();
    }

    private void ActualizarCantidadLeche()
    {
        int leches = PlayerPrefs.GetInt("LechesGuardadas", 0);
        cantidadLeche.text = "X" + leches.ToString();

        if (!dineroSumadoFlag)
        {
            sistemaMonetario.AgregarDinero(leches * manejoCompras.GANANCIA_LECHE);
            dinero = PlayerPrefs.GetInt("DineroTotal", 0);
            dineroSumadoFlag = true;
        }
        
        if (leches > 0)
        {
            dineroLeche = leches * manejoCompras.GANANCIA_LECHE;
            gananciaLeche.text = "+" + dineroLeche;
            gananciaLeche.color = customGreen;
        }
        else
        {
            dineroLeche = 0;
            gananciaLeche.text = "0";
            gananciaLeche.color = Color.black;
        }
    }

    private void ActualizarCostoHeno()
    {
        numCabras = manejoCompras.numCabrasBlancas + manejoCompras.numCabrasNegras;

        if (numCabras > 0)
        {
            dineroHeno = numCabras * manejoCompras.COSTO_ALIMENTAR_CABRA;
            costoHeno.text = "-" + dineroHeno;
        }
        else
        {
            dineroHeno = 0;
            costoHeno.text = "0";
        }
    }

    private void ActualizarCabrasCompradas()
    {
        dineroCabras = cabrasNuevas * manejoCompras.COSTO_CABRA;

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
    }

    private void ActualizarHenoEspecial()
    {
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado", 0);

        if (valorHenoMejorado == 0)
        {
            henoEspecial.SetActive(false);
        }
        else
        {
            dineroHenoEspecial = manejoCompras.COSTO_HENO_ESPECIAL;
            henoEspecial.SetActive(true);

            if (cabrasNuevas > 0)
            {
                objHenoEspecialRect.anchoredPosition = new Vector3(-147, -85, 226);
            }
            else
            {
                objHenoEspecialRect.anchoredPosition = new Vector3(-155, -36, 0);
            }
        }
    }

    private void ActualizarTotalFactura()
    {    
        sumaDinero = dineroLeche - dineroCabras - dineroHeno - dineroHenoEspecial;

        if (sumaDinero > 0)
        {
            dineroTotal.text = "+" + sumaDinero.ToString();
            dineroTotal.color = customGreen;
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
    }

    public void OnButtonCursorEnter()
    {
        // Cambiar el cursor a mano
        Cursor.SetCursor(cursorMano, Vector2.zero, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        // Cambiar el cursor a normal
        Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
    }
}