using UnityEngine;

public class OrdenyarSoundHandler : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] ordeñarSounds; // Array de sonidos de ordeñar

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró el componente AudioSource en el modelo.");
        }
    }

    public void PlayOrdenyarSound()
    {
        if (ordeñarSounds.Length > 0 && audioSource != null)
        {
            AudioClip sonidoRandom = ordeñarSounds[Random.Range(0, ordeñarSounds.Length)];
            audioSource.PlayOneShot(sonidoRandom);
        }
    }
}
