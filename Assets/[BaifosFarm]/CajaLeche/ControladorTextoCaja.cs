using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorTextoCaja : MonoBehaviour
{
    [SerializeField] private TextMeshPro textoCaja;

    private int lechesEnCaja = 0;

    public int LechesEnCaja { get => lechesEnCaja; }

    public void GuardarLeche()
    {
        lechesEnCaja++;
        ActualizarTextoCaja();
        PlayerPrefs.SetInt("LechesGuardadas", lechesEnCaja);
    }

    public void ResetearContador()
    {
        lechesEnCaja = 0;
        ActualizarTextoCaja();
    }

    private void ActualizarTextoCaja()
    {
        if (lechesEnCaja < 10)
        {
            textoCaja.text = "0" + lechesEnCaja.ToString();
        }
        else
        {
            textoCaja.text = lechesEnCaja.ToString();
        }
    }
}
