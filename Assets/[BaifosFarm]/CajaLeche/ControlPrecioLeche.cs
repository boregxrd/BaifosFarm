using UnityEngine;

public class ControlPrecioLeche : MonoBehaviour
{
    [SerializeField] int precioPorBotella = 10;
    [SerializeField] ControladorTextoCaja controladorTextoCaja;

    private void Start()
    {
        controladorTextoCaja = GetComponent<ControladorTextoCaja>();
    }

    public void SumarDineroPorBotella()
    {
        int dineroGanado = controladorTextoCaja.LechesEnCaja * precioPorBotella;
        controladorTextoCaja.ResetearContador();
    }
}
