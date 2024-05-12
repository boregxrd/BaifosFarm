using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoriaMetaDinero : MenuBase
{
    protected override void Start()
    {
        base.Start();
        Factura.OnMoneyVictory += ShowMenu;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Factura.OnMoneyVictory -= ShowMenu;
    }
}

