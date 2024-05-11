using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtardecerSiCabrasMuertas : MonoBehaviour
{
    private CondicionesAvisos condicionesAvisos;
    private Temporizador temporizador;

    [SerializeField] private List<Cabra> cabrasEscena;


    private void Awake()
    {
        condicionesAvisos = FindObjectOfType<CondicionesAvisos>();
        temporizador = FindObjectOfType<Temporizador>();
    }

    private void Update()
    {
        cabrasEscena = condicionesAvisos.ObtenerCabrasDeEscena();
        if(cabrasEscena.Count == 0 ) 
        {
            if(temporizador.tiempoRestante > 5f)
            {
                temporizador.tiempoRestante = 1f;
            }
            
        }
    }
}
