using UnityEngine;

public class OrdenyarSoundHandler : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] orde�arSounds; // Array de sonidos de orde�ar

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontr� el componente AudioSource en el modelo.");
        }
    }

    public void PlayOrdenyarSound()
    {
        if (orde�arSounds.Length > 0 && audioSource != null)
        {
            AudioClip sonidoRandom = orde�arSounds[Random.Range(0, orde�arSounds.Length)];
            audioSource.PlayOneShot(sonidoRandom);
        }
    }
}
