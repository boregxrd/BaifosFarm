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
    Animator animator;
    public bool cabraNegraMuerta = false;
    private bool muerteRealizada = false;

    private void Start()
    {
        barraAlimento = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<BarraAlimento>();
        targetBaifo = GameObject.Find("Personaje").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        obstaculo = GetComponent<NavMeshObstacle>();
        animator = GetComponentInChildren<Animator>();

        navMeshAgent.enabled = true;
        obstaculo.enabled = false;
    }

    private void Update()
    {
        if (barraAlimento.ValorActual > 0 && !cabraNegraMuerta)
        {
            SeguirAlJugador();
        }
        else
        {
            NoSeguirAlJugador();
        }

        if (cabraNegraMuerta)
        {
            if (!muerteRealizada)
            {
                Muerte();
            }
        }
        else
        {
            if (navMeshAgent.enabled && navMeshAgent.velocity.magnitude > 0.1f)
            {
                animator.SetBool("EnMovimiento", true);
            }
            else
            {
                animator.SetBool("EnMovimiento", false);
            }
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

    private void Muerte()
    {
        //navMeshAgent.isStopped = true;
        navMeshAgent.enabled = false;

        animator.SetBool("EnMovimiento", false);
        animator.SetTrigger("HaMuerto");

        muerteRealizada = true;

        StartCoroutine(DesactivarAnimator());
    }

    private IEnumerator DesactivarAnimator()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        animator.enabled = false;
    }
}
