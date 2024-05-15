using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFactura : MonoBehaviour
{
    ManejoCompras manejoCompras;

    [SerializeField] Text cantidadLeche;
    [SerializeField] Text cantidadCabras;
    [SerializeField] Text gananciaLeche;
    [SerializeField] Text costoHeno;
    [SerializeField] Text costoCabras;
    [SerializeField] GameObject henoEspecial;
    [SerializeField] GameObject objCabras;
    [SerializeField] Text dineroTotal;
    [SerializeField] Text contadorDinero;

    public int dinero;
    int sumaDinero;
    int dineroLeche;
    int dineroCabras;
    int dineroHeno;
    int dineroHenoEspecial;
    public int cabrasNuevas = 0;
    int numCabras;

    private void Awake()
    {
        manejoCompras = GetComponent<ManejoCompras>();
        dinero = PlayerPrefs.GetInt("DineroTotal", 0);
        PlayerPrefs.SetInt("HenoMejorado", 0);
        //numCabras = manejoCompras.numCabrasBlancas + manejoCompras.numCabrasNegras;
        //dineroHeno = numCabras * manejoCompras.COSTO_ALIMENTAR_CABRA
    }

    private void Start()
    {
        contadorDinero.text = dinero.ToString();
        cantidadLeche.text = PlayerPrefs.GetInt("LechesGuardadas", 0).ToString();
        ActualizarUI();
    }

    public void ActualizarUI()
    {
        // cogemos valores necesarios
        int leches = PlayerPrefs.GetInt("LechesGuardadas", 0);
        int valorHenoMejorado = PlayerPrefs.GetInt("HenoMejorado", 0);
        numCabras = manejoCompras.numCabrasBlancas + manejoCompras.numCabrasNegras;
        dineroCabras = cabrasNuevas * manejoCompras.COSTO_CABRA;

        // LECHE
        cantidadLeche.text = "X" + leches.ToString();
        if (leches > 0)
        {
            dineroLeche = leches * manejoCompras.GANANCIA_LECHE;
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
        if (numCabras > 0)
        {
            dineroHeno = numCabras * manejoCompras.COSTO_ALIMENTAR_CABRA;
            Debug.Log("dinero heno: " + dineroHeno);
            costoHeno.text = "-" + dineroHeno;
        }
        else
        {
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
            dineroHenoEspecial = manejoCompras.COSTO_HENO_ESPECIAL;
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
    }
}