using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CabraNegra : MonoBehaviour
{
    public Transform targetBaifo;
    private NavMeshAgent navMeshAgent;
    private NavMeshObstacle obstaculo;
    [SerializeField] BarraAlimento barraAlimento;
    [SerializeField] Temporizador temporizador;
    public bool cabraNegraMuerta = false;

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

    public void DestruirCabrasNegrasMuertas()
    {
        if (Quaternion.Euler(0, 0, 180) == transform.rotation && temporizador.tiempoRestante < 1f)
        {
            Destroy(gameObject);
        }
    }
    

}
