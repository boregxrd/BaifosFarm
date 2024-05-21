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
        if (!cabraNegraMuerta && barraAlimento.ValorActual > 0)
        {
            SeguirAlJugador();
            ControlAnimacionMovimiento();
        }
        else if (!muerteRealizada)
        {
            NoSeguirAlJugador();
            Muerte();
        }
    }

    private void ControlAnimacionMovimiento()
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
        navMeshAgent.enabled = false;
        animator.SetBool("EnMovimiento", false);
        animator.SetTrigger("HaMuerto");
        StartCoroutine(PlayAnimacionMuerte());
    }

    private IEnumerator PlayAnimacionMuerte()
    {
        // Espera hasta que la animación de muerte termine
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Desactivar el Animator para detener todas las animaciones
        animator.enabled = false;

        // Asegurar que la cabra se queda quieta
        muerteRealizada = true;
    }
}
