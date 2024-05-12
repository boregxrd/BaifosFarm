using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteCabraBlanca : MonoBehaviour
{
    [SerializeField] BarraAlimento barraAlimento;

    private void Start()
    {
        barraAlimento = transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();
    }

    private void Update()
    {
        if(barraAlimento.ValorActual == 0)
        {
            Morir();
        }
    }


    public void Morir()
    {
        Destroy(gameObject);
        PlayerPrefs.SetInt("cabrasBlancas", PlayerPrefs.GetInt("cabrasBlancas", 0) - 1);
    }
}
