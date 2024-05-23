using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class CabraNegra : MonoBehaviour
{
    public Transform targetBaifo;
    private NavMeshAgent navMeshAgent;
    private NavMeshObstacle obstaculo;
    [SerializeField] BarraAlimento barraAlimento;
    [SerializeField] Temporizador temporizador;
    private Animator animator;
    public bool cabraNegraMuerta = false;
    private bool muerteRealizada = false;
    CabraNegraInteracciones interacciones;
    Collider collider;

    private void Start()
    {
        barraAlimento = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();
        targetBaifo = GameObject.Find("Personaje").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        obstaculo = GetComponent<NavMeshObstacle>();
        animator = GetComponentInChildren<Animator>();
        interacciones = GetComponent<CabraNegraInteracciones>();
        collider = GetComponent<Collider>();

        navMeshAgent.enabled = true;
        obstaculo.enabled = false;
    }

    private void Update()
    {
        if (!cabraNegraMuerta && barraAlimento.ValorActual > 0)
        {
            SeguirAlJugador();
            ControlAnimacionMovimiento();
        }
        else if (!muerteRealizada)
        {
            Muerte();
        }
    }

    private void ControlAnimacionMovimiento()
    {
        if (navMeshAgent.enabled && navMeshAgent.velocity.magnitude > 0.5f)
        {
            animator.SetBool("EnMovimiento", true);
        }
        else
        {
            animator.SetBool("EnMovimiento", false);
        }
    }

    private void SeguirAlJugador()
    {
        if(!interacciones.estaComiendo)
        {
            navMeshAgent.SetDestination(targetBaifo.position);
        }
    }

    public void DestruirCabrasNegrasMuertas()
    {
        if (Quaternion.Euler(0, 0, 180) == transform.rotation && temporizador.tiempoRestante < 1f)
        {
            Destroy(gameObject);
        }
    }

    private void Muerte()
    {
        navMeshAgent.enabled = false;
        obstaculo.enabled = true;
        animator.SetBool("EnMovimiento", false);
        animator.SetTrigger("HaMuerto");
        AdjustColliderForDeath();
        muerteRealizada = true;
    }

    private void AdjustColliderForDeath()
    {
        BoxCollider boxCollider = collider as BoxCollider;
        if (boxCollider != null)
        {
            boxCollider.center = new Vector3(-0.9f, 0.4f, 0.18f); 
            boxCollider.size = new Vector3(0.48f, 0.77f, 1);
        }
        Debug.Log("Collider ajustado para el estado de muerte");
    }
}
