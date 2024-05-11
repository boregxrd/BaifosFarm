using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CabraNegra : MonoBehaviour
{
    [SerializeField] BarraAlimento barraAlimento;
    public Transform targetBaifo;
    private NavMeshAgent navMeshAgent;
    private NavMeshObstacle obstaculo;

    private void Start()
    {
        barraAlimento = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();
        targetBaifo = GameObject.Find("Personaje").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        obstaculo = GetComponent<NavMeshObstacle>();

        navMeshAgent.enabled = true;
        obstaculo.enabled = false;
    }

    private void Update()
    {
        if(barraAlimento.ValorActual > 0)
        {
            SeguirAlJugador();
        }
        else
        {
            NoSeguirAlJugador();
        }
    }

    private void SeguirAlJugador()
    {
        navMeshAgent.SetDestination(targetBaifo.position);
    }

    public void NoSeguirAlJugador()
    {
        navMeshAgent.enabled = false;
        obstaculo.enabled = true;
    }

    
    //[SerializeField] GameObject objetoControlTiempo;
    [SerializeField] ControlTiempo controlTiempo;
    public bool cabraNegraMuerta = false;
    /*
    

    private void Start()
    {
        objetoControlTiempo = GameObject.Find("CanvasTiempo");
        controlTiempo = objetoControlTiempo.GetComponentInChildren<ControlTiempo>();
    }

   

    public void MuerteDeCabraNegra()
    {
       

        cabraNegraMuerta = true;
    }
    */

    public void DestruirCabrasNegrasMuertas()
    {
        if (Quaternion.Euler(0, 0, 180) == transform.rotation && controlTiempo.tiempoRestante < 1f)
        {
            Destroy(gameObject);
        }
    }
    

}
