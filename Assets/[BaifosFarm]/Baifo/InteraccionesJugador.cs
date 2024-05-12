using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class InteraccionesJugador : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    private Jugador jugador;
    [SerializeField] private float distanciaMaxima = 1f;
    private bool interaccionesActivas = true;

    void Start()
    {
        jugador = GetComponent<Jugador>();
    }

    private void FixedUpdate()
    {
        if (!interaccionesActivas) return; 

        Vector3 posicionEsfera = jugador.transform.position + jugador.transform.forward * distanciaMaxima;

        Collider[] colliders = Physics.OverlapSphere(posicionEsfera, 0.5f, mask);

        foreach (Collider collider in colliders)
        {
            if (Input.GetKey(KeyCode.E))
            {
                collider.GetComponent<IInteractuable>().Interactuar(jugador);
            }

            if (Input.GetKey(KeyCode.Space) && collider.gameObject.CompareTag("cabraBlanca"))
            {
                collider.GetComponent<CabraBlancaInteracciones>().Ordenyar(jugador);
            }
        }
    }

    public void DesabilitarInteraccionesJugador()
    {
        interaccionesActivas = false; 
    }
}

