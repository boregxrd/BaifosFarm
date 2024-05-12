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
        Debug.Log("showmenuinvocado");
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        DeteccionCabrasNegras.OnThreeBlackGoatsVictory -= ShowMenu;
    }
}
