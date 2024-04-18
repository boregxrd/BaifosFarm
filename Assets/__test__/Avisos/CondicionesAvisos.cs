using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionesAvisos : MonoBehaviour
{

    [SerializeField] private List<Cabra> cabrasEnEscena;
    private LimitesCamara limitesCamara;

    private float valorAlertaHambre = 30f;
    private float valorAlertaMuerte = 5f;
    private float valorLecheCompleta = 100f;

    private void Awake()
    {
        limitesCamara = GetComponent<LimitesCamara>();
    }

    private void Update()
    {
        if(cabrasEnEscena.Count == 0) //para que solo ejecute este código una vez
        {
            cabrasEnEscena = ObtenerCabrasDeEscena(); //las cabras se crean después de start() por eso lo he puesto en update(), sería mejor cambiar esto en un futuro
        }
        else
        {
            comprobarDondeEstanLasCabras();
        }

    }

    private List<Cabra> ObtenerCabrasDeEscena()
    {
        // Inicializa una lista para almacenar las cabras
        List<Cabra> cabrasEnEscena = new List<Cabra>();

        // Encuentra todos los objetos en la escena que tengan el script Cabra adjunto
        Cabra[] cabrasEncontradas = FindObjectsOfType<Cabra>();

        // Agrega cada cabra encontrada a la lista
        foreach (Cabra cabra in cabrasEncontradas)
        {
            cabrasEnEscena.Add(cabra);
        }

        return cabrasEnEscena;
    }

    private void comprobarDondeEstanLasCabras()
    {
        
        foreach (Cabra cabra in cabrasEnEscena)
        {
            if (cabra != null)
            {
                bool estaFueraDeCamara = limitesCamara.ObjetoFueraDeCamara(cabra.transform.position);

                if (estaFueraDeCamara)
                {
                    if(cabra.nivelDeAlimentacion() <= valorAlertaHambre && 
                        cabra.nivelDeAlimentacion() > valorAlertaMuerte)
                    {
                        Debug.Log($"{cabra.name} tiene hambre");
                    }

                    if (cabra.nivelDeAlimentacion() <= valorAlertaMuerte)
                    {
                        Debug.Log($"{cabra.name} va a morir");
                    }

                    if (cabra.nivelDeLeche() == valorLecheCompleta)
                    {
                        Debug.Log($"{cabra.name} tiene LECHE");
                    }
              
                }
            }
            else
            {
                cabrasEnEscena.Clear();
            }
           
            
        }
    }
    
}
