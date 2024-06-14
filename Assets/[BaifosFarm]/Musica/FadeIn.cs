using UnityEngine;

public class FadeIn : ITransicionMusica
{
    private AudioManager manager;
    public AudioManager AudioManager { set => manager = value; }

    public bool End()
    {
        return manager.musica.volume >= 1;
    }

    public void Start(AudioClip clip)
    {
        manager.musica.clip = clip;
        manager.musica.Play();
        manager.musica.volume = 0;
    }

    public void Update()
    {
        manager.musica.volume += Time.deltaTime;
    }
}
