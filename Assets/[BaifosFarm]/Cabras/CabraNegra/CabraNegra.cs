using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CabraNegra : MonoBehaviour
{
    [SerializeField] GameObject objetoControlTiempo;
    [SerializeField] ControlTiempo controlTiempo;
    public Transform targetBaifo;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        objetoControlTiempo = GameObject.Find("CanvasTiempo");
        controlTiempo = objetoControlTiempo.GetComponentInChildren<ControlTiempo>();
        targetBaifo = GameObject.Find("Personaje").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(!Quaternion.Euler(0, 0, 90).Equals(transform.rotation))
        {
            navMeshAgent.SetDestination(targetBaifo.position);
        }
    }
    public void MuerteDeCabraNegra()
    {
        if (Quaternion.Euler(0, 0, 90) != transform.rotation)
        {
            navMeshAgent.enabled = false; // Desactivar el NavMeshAgent
            transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        }
    }

    public void DestruirCabrasNegrasMuertas()
    {
        if(Quaternion.Euler(0, 0, 90) == transform.rotation && controlTiempo.tiempoRestante < 1f)
            {
                Debug.Log("cabraNegraDestruida");
                Destroy(gameObject);
            }
    }
}
