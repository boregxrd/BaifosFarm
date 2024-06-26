using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    public AudioSource musica;
    public AudioMixer audioMixer; // Referencia al AudioMixer
    private ITransicionMusica transicionMusica;
    private float fadeOutDuration = 1f;
    private Coroutine musicLoopCoroutine;
    public float loopStart;
    public float loopEnd;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            musica = gameObject.AddComponent<AudioSource>();
            musica.playOnAwake = false;
            musica.loop = false; // Ensure it's false for manual looping
            musica.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Musica")[0]; // Asignar el grupo de mezcla
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void PlayMusica(AudioClip clip, float loopStartTime, float loopEndTime, ITransicionMusica transicion = null)
    {
        Debug.Log("PlayMusica called with clip: " + clip.name + " loopStartTime: " + loopStartTime + " loopEndTime: " + loopEndTime);

        loopStart = loopStartTime;
        loopEnd = loopEndTime;

        if (musicLoopCoroutine != null)
        {
            StopCoroutine(musicLoopCoroutine);
        }

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

        musicLoopCoroutine = StartCoroutine(MusicLoop.HandleMusicLoop(musica, loopStart, loopEnd));
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

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        float startVolume = musica.volume;
        float timer = 0f;

        while (timer < fadeOutDuration)
        {
            musica.volume = Mathf.Lerp(startVolume, 0f, timer / fadeOutDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void SetVolumenMusica(float volumen)
    {
        audioMixer.SetFloat("VolumenMusica", ConvertToDecibels(volumen));
    }

    public void SetVolumenSFX(float volumen)
    {
        audioMixer.SetFloat("VolumenSFX", ConvertToDecibels(volumen));
    }

    private float ConvertToDecibels(float volumen)
    {
        if (volumen <= 0)
        {
            return -80f;
        }
        return Mathf.Log10(volumen) * 20;
    }

    // Métodos para pausar y reanudar la música
    public void PauseMusic()
    {
        musica.Pause();
    }

    public void ResumeMusic()
    {
        musica.UnPause();
    }
}
