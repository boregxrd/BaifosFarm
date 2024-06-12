using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    public AudioSource musica;

    private ITransicionMusica transicionMusica;

    private float fadeOutDuration = 1f;

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

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // Inicia el fade out
        float startVolume = musica.volume;
        float timer = 0f;

        while (timer < fadeOutDuration)
        {
            musica.volume = Mathf.Lerp(startVolume, 0f, timer / fadeOutDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Carga la nueva escena de forma asincrónica
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Espera a que la nueva escena se cargue completamente
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
