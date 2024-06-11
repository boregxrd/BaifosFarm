using UnityEngine;

public class SceneMusicController : MonoBehaviour
{
    public AudioClip sceneMusic;
    public float loopStartTime;
    public float loopEndTime;
    public bool useFadeIn;
    public bool useFadeOut;

    private void Start()
    {
        if (useFadeIn)
        {
            AudioManager.Instance.PlayMusica(sceneMusic, loopStartTime, loopEndTime, new FadeIn());
        }
        else if (useFadeOut)
        {
            AudioManager.Instance.PlayMusica(sceneMusic, loopStartTime, loopEndTime, new FadeOut());
        }
        else
        {
            AudioManager.Instance.PlayMusica(sceneMusic, loopStartTime, loopEndTime);
        }
    }
}
