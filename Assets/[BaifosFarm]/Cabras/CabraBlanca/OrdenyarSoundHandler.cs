using UnityEngine;

public class OrdenyarSoundHandler : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] ordeņarSounds; // Array de sonidos de ordeņar

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontrķ el componente AudioSource en el modelo.");
        }
    }

    public void PlayOrdenyarSound()
    {
        if (ordeņarSounds.Length > 0 && audioSource != null)
        {
            AudioClip sonidoRandom = ordeņarSounds[Random.Range(0, ordeņarSounds.Length)];
            audioSource.PlayOneShot(sonidoRandom);
        }
    }
}
