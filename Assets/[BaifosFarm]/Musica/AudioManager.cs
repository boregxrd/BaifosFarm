using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    public AudioSource musica;

    private ITransicionMusica transicionMusica;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            musica = gameObject.AddComponent<AudioSource>();
            musica.playOnAwake = false;
            musica.loop = false; // Ensure it's false for manual looping
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void PlayMusica(AudioClip clip, float loopStartTime, float loopEndTime, ITransicionMusica transicion = null)
    {
        Debug.Log("PlayMusica called with clip: " + clip.name + " loopStartTime: " + loopStartTime + " loopEndTime: " + loopEndTime);
        if (transicion != null)
        {
            transicion.AudioManager = this;
            transicion.Start(clip);
        }
        else
        {
            musica.clip = clip;
            musica.Play();
        }
        StartCoroutine(MusicLoop.HandleMusicLoop(musica, loopStartTime, loopEndTime));
        transicionMusica = transicion;
    }

    private void Update()
    {
        if (transicionMusica != null)
        {
            transicionMusica.Update();
            if (transicionMusica.End()) transicionMusica = null;
        }
    }
}
