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
    public Text textoDinero; // Referencia al objeto de texto que mostrará el dinero total

    void Update()
    {
        int botellasObtenidas = controladorAccionesPersonaje.lechesGuardadas;
        textoCaja.text = "Botellas: " + botellasObtenidas.ToString();
    }

    public void SumarDineroPorBotella()
    {
        int botellasObtenidas = controladorAccionesPersonaje.lechesGuardadas;
        int dineroGanado = botellasObtenidas * 10; // Cada botella vale $10
        sistemaMonetario.AgregarDinero(dineroGanado);
        Debug.Log("Dinero ganado: " + dineroGanado);
        Debug.Log("Dinero total: $" + sistemaMonetario.ObtenerTotalDinero());
        // Comprobar si textoDinero es nulo antes de intentar actualizarlo
        if (textoDinero != null)
        {
            textoDinero.text = "Dinero: $" + sistemaMonetario.ObtenerTotalDinero().ToString();
        }
        else
        {
            Debug.LogWarning("El objeto de texto para el dinero total no está asignado en el inspector.");
        }
    }
}
