using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxCaminar : MonoBehaviour
{
    [SerializeField] ParticleSystem particulas;
    List<BoxCollider> collidersPiernas;

    private void Start()
    {
        // crear lista
        collidersPiernas = new List<BoxCollider>();

        // buscar piernas
        GameObject[] piernas = GameObject.FindGameObjectsWithTag("Pierna");

        // anyadir a la lista solo los BoxColliders de las piernas
        foreach (var pierna in piernas) {
            BoxCollider collider = pierna.GetComponent<BoxCollider>();
            if (collider != null)
            {
                collidersPiernas.Add(collider);
            }
        }
    }

    private void OnCollisionEnter(Collision colision)
    {
        if (colision.gameObject.CompareTag("Suelo"))
        {
            foreach (var collider in collidersPiernas)
            {
                foreach (var contacto in colision.contacts)
                {
                    if (contacto.thisCollider == collider)
                    {
                        // instanciar particulas en el punto de contacto con el suelo
                        Instantiate(particulas, contacto.point, Quaternion.identity).Play();
                    }
                }
            }
        }
    }

}
