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
    public Text textoDinero; // Referencia al objeto de texto que mostrar� el dinero total
    [SerializeField] int PRECIO_POR_BOTELLA = 10;

    private void Awake() {
        textoDinero.text = "Dinero: $" + PlayerPrefs.GetInt("DineroTotal", 0);
    }
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
    
        if (textoDinero != null)
        {
            textoDinero.text = "Dinero: $" + PlayerPrefs.GetInt("DineroTotal", 0).ToString();
        }
        else
        {
            Debug.LogWarning("El objeto de texto para el dinero total no est� asignado en el inspector.");
        }
    }
}
