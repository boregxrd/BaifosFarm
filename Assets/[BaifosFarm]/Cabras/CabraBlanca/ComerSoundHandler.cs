using UnityEngine;

public class ComerSoundHandler : MonoBehaviour
{
    private MovimientoAleatorioCabras movimientoAleatorioCabras;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] comerSounds; // Array de sonidos de comer

    private void Start()
    {
        // Buscar el componente MovimientoAleatorioCabras en el padre
        movimientoAleatorioCabras = GetComponentInParent<MovimientoAleatorioCabras>();
        if (movimientoAleatorioCabras == null)
        {
            Debug.LogError("No se encontró el componente MovimientoAleatorioCabras en el padre.");
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró el componente AudioSource en el modelo.");
        }
    }

    public void PlayComerSound()
    {
        if (comerSounds.Length > 0 && audioSource != null)
        {
            AudioClip sonidoRandom = comerSounds[Random.Range(0, comerSounds.Length)];
            audioSource.PlayOneShot(sonidoRandom);
        }
    }
}
