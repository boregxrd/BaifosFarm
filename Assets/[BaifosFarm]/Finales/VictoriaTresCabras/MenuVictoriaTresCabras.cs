using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoriaTresCabras : MenuBase
{
    protected override void Start()
    {
        base.Start();
        DeteccionCabrasNegras.OnThreeBlackGoatsVictory += ShowMenu;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        DeteccionCabrasNegras.OnThreeBlackGoatsVictory -= ShowMenu;
    }
}
