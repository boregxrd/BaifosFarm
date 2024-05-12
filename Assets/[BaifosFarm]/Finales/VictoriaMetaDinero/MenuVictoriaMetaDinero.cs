using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoriaMetaDinero : MenuBase
{
    protected override void Start()
    {
        base.Start();
        //enabled = true;
        Factura.OnMoneyVictory += ShowMenu;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        //enabled = false;
        Factura.OnMoneyVictory -= ShowMenu;
        
    }
}

