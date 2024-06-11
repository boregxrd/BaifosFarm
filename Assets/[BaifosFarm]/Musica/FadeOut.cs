using UnityEngine;

public class FadeOut : ITransicionMusica
{
    private AudioManager manager;
    public AudioManager AudioManager { set => manager = value; }

    private AudioClip _clip;

    public bool End()
    {
        if(manager.musica.volume <= 0)
        {
            manager.musica.clip = _clip;
            manager.musica.Play();
            manager.musica.volume = 1;
            return true;
        }
        return false;
    }

    public void Start(AudioClip clip)
    {
        _clip = clip;
        manager.musica.volume = 1;
    }

    public void Update()
    {
        manager.musica.volume -= Time.deltaTime;
    }
}