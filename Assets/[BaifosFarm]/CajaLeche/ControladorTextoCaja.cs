using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorTextoCaja : MonoBehaviour
{
    [SerializeField] ControladorAccionesPersonaje controladorAccionesPersonaje;
    [SerializeField] private TextMeshPro textoCaja;

    void Update()
    {
        textoCaja.text = "Botellas: " + controladorAccionesPersonaje.lechesGuardadas.ToString();
    }
}
