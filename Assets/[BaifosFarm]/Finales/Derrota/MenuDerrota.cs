using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDerrota : MenuBase
{
    protected override void Start()
    {
        enabled = true;
        base.Start();
        Factura.OnGameOver += ShowMenu;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Factura.OnGameOver -= ShowMenu;
    }
}
