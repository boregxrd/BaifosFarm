using UnityEngine;

public class FootstepSoundRedirector : MonoBehaviour
{
    private MovimientoAleatorioCabras movimientoAleatorioCabras;

    private void Start()
    {
        // Buscar el componente MovimientoAleatorioCabras en el padre
        movimientoAleatorioCabras = GetComponentInParent<MovimientoAleatorioCabras>();
        if (movimientoAleatorioCabras == null)
        {
            Debug.LogError("No se encontró el componente MovimientoAleatorioCabras en el padre.");
        }
    }

    public void PlayFootstepSound()
    {
        if (movimientoAleatorioCabras != null)
        {
            movimientoAleatorioCabras.PlayFootstepSound();
        }
    }
}
