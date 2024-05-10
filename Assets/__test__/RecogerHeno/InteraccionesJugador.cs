using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionesJugador : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    private bool enRango = false;
    private Jugador jugador;

    void Start()
    {
        jugador = GetComponent<Jugador>();
    }

    private void Update()
    {
        if(Physics.Raycast(transform.position + Vector3.up, transform.forward, out RaycastHit hitInfo, 1f, mask))
        {
            enRango = true;

            if (Input.GetKey(KeyCode.E)) hitInfo.transform.GetComponent<IInteractuable>().Interactuar(jugador);
            

            if (Input.GetKey(KeyCode.Space))
            {
                if (hitInfo.transform.gameObject.CompareTag("cabraBlanca")) hitInfo.transform.GetComponent<CabraBlancaInteracciones>().Ordenyar(jugador); 
            }

            else
            {
                enRango = false;
                return;
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Color rayColor = enRango ? Color.red : Color.white;
        Debug.DrawRay(transform.position + Vector3.up, transform.forward * 3, rayColor);
    }

}
