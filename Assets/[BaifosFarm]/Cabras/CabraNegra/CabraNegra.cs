using UnityEngine;
using UnityEngine.AI;

public class CabraNegra : MonoBehaviour
{
    [SerializeField] GameObject objetoControlTiempo;
    [SerializeField] ControlTiempo controlTiempo;
    public Transform targetBaifo;
    private NavMeshAgent navMeshAgent;

    [SerializeField] float alturaDeseada = 1f;
    public bool cabraNegraMuerta = false;

    private void Start()
    {
        objetoControlTiempo = GameObject.Find("CanvasTiempo");
        controlTiempo = objetoControlTiempo.GetComponentInChildren<ControlTiempo>();
        targetBaifo = GameObject.Find("Personaje").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }   

    private void Update()
    {
        if(!Quaternion.Euler(0, 0, 180).Equals(transform.rotation) && !cabraNegraMuerta)
        {
            navMeshAgent.SetDestination(targetBaifo.position);
        }
    }
    public void MuerteDeCabraNegra()
    {
        if (Quaternion.Euler(0, 0, 180) != transform.rotation)
        {
            navMeshAgent.enabled = false; // Desactivar el NavMeshAgent
            transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
            transform.position += new Vector3(0, alturaDeseada, 0);
            cabraNegraMuerta = true;
        }
    }

    public void DestruirCabrasNegrasMuertas()
    {
        if(Quaternion.Euler(0, 0, 180) == transform.rotation && controlTiempo.tiempoRestante < 1f)
            {
                Destroy(gameObject);
            }
    }
}
