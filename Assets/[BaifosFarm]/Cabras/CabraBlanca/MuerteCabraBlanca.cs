using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteCabraBlanca : MonoBehaviour
{
    [SerializeField] BarraAlimento barraAlimento;
    public int cabrasBlancasAlMomento;

    private void Start()
    {
        barraAlimento = transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();
    }

    private void Update()
    {
        cabrasBlancasAlMomento = PlayerPrefs.GetInt("cabrasBlancas", 0);
        if(barraAlimento.ValorActual == 0)
        {
            PlayerPrefs.SetInt("cabrasBlancas", cabrasBlancasAlMomento - 1);
            Morir();
        }
    }


    public void Morir()
    {
        Destroy(gameObject);
    }
}
