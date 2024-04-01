using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factura : MonoBehaviour
{
    public Text txtFactura;

    private void Awake() {
        ControladorAccionesPersonaje controladorAcciones = FindObjectOfType<ControladorAccionesPersonaje>();
        int leches = controladorAcciones.lechesGuardadas;
        txtFactura.text = txtFactura.text + leches.ToString();
    }
}
