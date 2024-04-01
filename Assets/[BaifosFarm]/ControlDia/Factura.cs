using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factura : MonoBehaviour
{
    public Text txtFactura;

    private void Awake() {
        int leches = PlayerPrefs.GetInt("LechesGuardadas", 0);
        txtFactura.text = txtFactura.text + leches.ToString();
    }
}
