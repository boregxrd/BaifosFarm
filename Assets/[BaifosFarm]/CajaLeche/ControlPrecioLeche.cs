using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPrecioLeche : MonoBehaviour
{
    [SerializeField] private SistemaMonetario sistemaMonetario;
    [SerializeField] int PRECIO_POR_BOTELLA = 10;
    [SerializeField] ControladorTextoCaja controladorTextoCaja;

    private void Start()
    {
        controladorTextoCaja = GetComponent<ControladorTextoCaja>();
    }

    public void SumarDineroPorBotella()
    {
        int dineroGanado = controladorTextoCaja.LechesEnCaja * PRECIO_POR_BOTELLA;
        sistemaMonetario.AgregarDinero(dineroGanado);
        controladorTextoCaja.ResetearContador();
    }
}
