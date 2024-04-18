using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesAvisos : MonoBehaviour
{

    [SerializeField] private Cabra[] cabrasEnEscena;
    private LimitesCamara limitesCamara;

    private void Awake()
    {
        limitesCamara = GetComponent<LimitesCamara>();
    }

    private void Update()
    {
        if(cabrasEnEscena.Length == 0) //para que solo ejecute este código una vez
        {
            cabrasEnEscena = ObtenerCabrasDeEscena(); //las cabras se crean después de start() por eso lo he puesto en update(), sería mejor cambiar esto en un futuro
        }
        else
        {
            comprobarDondeEstanLasCabras();
        }

    }

    private Cabra[] ObtenerCabrasDeEscena()
    {
        Cabra[] cabrasEncontradas = FindObjectsOfType<Cabra>();

        return cabrasEncontradas;
    }

    private void comprobarDondeEstanLasCabras()
    {
        foreach (Cabra cabra in cabrasEnEscena)
        {
            bool estaFueraDeCamara = limitesCamara.ObjetoFueraDeCamara(cabra.transform.position);
            if (estaFueraDeCamara)
            {
                //comprobar nivel de todo
                Debug.Log($"{cabra.name} está fuera de camara");
            }
            
        }
    }
    
}
