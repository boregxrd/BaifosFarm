using Unity.VisualScripting;
using UnityEngine;

public class BarrasHandler: MonoBehaviour
{
    BarraAlimento[] barrasAlimento;
    BarraLeche[] barrasLeche;

    private void Start()
    {
        barrasAlimento = FindObjectsOfType<BarraAlimento>();
        barrasLeche = FindObjectsOfType<BarraLeche>();
    }
    public void CongelarBarrasCabras()
    {
        foreach (BarraAlimento barraAlimento in barrasAlimento)
        {
            if(barraAlimento!=null)
            {
                barraAlimento.enabled = false;
            }
        }

        foreach (BarraLeche barraLeche in barrasLeche)
        {
            if (barraLeche != null)
            {
                barraLeche.enabled = false;
            }
        }
    }
}
