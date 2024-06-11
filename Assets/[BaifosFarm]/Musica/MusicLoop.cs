using UnityEngine;
using System.Collections;

public static class MusicLoop
{public static IEnumerator HandleMusicLoop(AudioSource audioSource, float loopStartTime, float loopEndTime)
{
    while (true)
    {
        if (audioSource.time >= loopEndTime)
        {
            Debug.Log("Looping music...");
            audioSource.Play();
            audioSource.time = loopStartTime;
            
        }
        yield return null;
    }
}

}
