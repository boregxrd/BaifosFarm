using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxPierna : MonoBehaviour
{
    Animator animator;
    [SerializeField] ParticleSystem particulas;

    public bool enSuelo = true;
    public bool enMovimiento;
    Vector3 particlePosition;
    ParticleSystem fx;

    void Awake()
    {
        BoxCollider collider = GetComponent<BoxCollider>();

        // More robust search for the MovimientoAleatorioCabras component
        animator = GetComponentInParent<Animator>();

        if (animator == null)
        {
            Debug.LogWarning("null");
        }
        // Adjust the position of the particle system relative to the leg's pivot point
        float offsetY = 0.16f; // Adjust this value as needed

        particlePosition = transform.position - new Vector3(0, offsetY, 0);
        
        // Instantiate the particle system at the adjusted position
        fx = Instantiate<ParticleSystem>(particulas, particlePosition, Quaternion.identity, transform);

    }

    private void OnCollisionEnter(Collision other)
    {
        enMovimiento = animator.GetBool("enMovimiento");
        // Debug.Log("enmov" + enMovimiento);
        // Debug.Log("ensuelo" + enSuelo);

        if (enMovimiento == true && enSuelo == false && other.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
            //Debug.Log("contacto mientras se mueve");
            fx.Play();
        }

    }

    private void OnCollisionExit(Collision other)
    {
        enSuelo = false;
    }
}
