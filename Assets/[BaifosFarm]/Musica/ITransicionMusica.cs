using UnityEngine;

public interface ITransicionMusica
{
    AudioManager AudioManager { set; }
    void Start(AudioClip clip);
    void Update();
    bool End();
}

