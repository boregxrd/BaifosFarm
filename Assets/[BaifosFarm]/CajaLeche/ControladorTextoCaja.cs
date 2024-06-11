using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorTextoCaja : MonoBehaviour
{
    [SerializeField] private TextMeshPro textoCaja;

    public void ActualizarTextoCaja(int leches)
    {
        if (leches < 10)
        {
            textoCaja.text = "0" + leches.ToString();
        }
        else
        {
            textoCaja.text = leches.ToString();
        }
    }
}
