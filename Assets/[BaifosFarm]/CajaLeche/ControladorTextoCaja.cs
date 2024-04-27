using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorTextoCaja : MonoBehaviour
{
    [SerializeField] private ControladorAccionesPersonaje controladorAccionesPersonaje;
    [SerializeField] private TextMeshPro textoCaja;
    [SerializeField] private SistemaMonetario sistemaMonetario; // Agrega referencia al SistemaMonetario
    [SerializeField] int PRECIO_POR_BOTELLA = 10;

    void Update()
    {
        int botellasObtenidas = controladorAccionesPersonaje.lechesGuardadas;
        textoCaja.text = "Botellas: " + botellasObtenidas.ToString();
    }

    public void SumarDineroPorBotella()
    {
        int botellasObtenidas = controladorAccionesPersonaje.lechesGuardadas;
        int dineroGanado = botellasObtenidas * PRECIO_POR_BOTELLA; // Cada botella vale $10
        sistemaMonetario.AgregarDinero(dineroGanado);
    }
}
