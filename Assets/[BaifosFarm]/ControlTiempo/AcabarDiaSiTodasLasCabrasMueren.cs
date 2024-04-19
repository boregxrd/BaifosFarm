using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcabarDiaSiTodasLasCabrasMueren : MonoBehaviour
{
    private CondicionesAvisos condicionesAvisos;
    private ControlTiempo controlTiempo;

    [SerializeField] private List<Cabra> cabrasEscena;


    private void Awake()
    {
        condicionesAvisos = FindObjectOfType<CondicionesAvisos>();
        controlTiempo = transform.GetChild(0).GetComponent<ControlTiempo>();
    }

    private void Update()
    {
        cabrasEscena = condicionesAvisos.ObtenerCabrasDeEscena();
        if(cabrasEscena.Count == 0 ) 
        {
            if(controlTiempo.tiempoRestante > 5f)
            {
                controlTiempo.tiempoRestante = 5f;
            }
            
        }
    }
}
