using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipoDeHeno : MonoBehaviour
{
    public GameObject montonHenoNormal;
    public GameObject montonHenoEspecial;
    public float incremento;

    private void Start()
    {
        ComprobarTipoDeHeno();
    }

    private void ActivarHenoNormal()
    {
        montonHenoNormal.SetActive(true);
        montonHenoEspecial.SetActive(false);
        incremento = 40f;
    }

    private void ActivarHenoEspecial()
    {
        montonHenoNormal.SetActive(false);
        montonHenoEspecial.SetActive(true);
        incremento = 80f;
    }

    private void ComprobarTipoDeHeno()
    {
        if (PlayerPrefs.GetInt("HenoMejorado", 0) == 1)
        {
            ActivarHenoEspecial();
        }
        else
        {
            ActivarHenoNormal();        }
        }
}
