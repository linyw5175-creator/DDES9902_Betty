using UnityEngine;
using System.Collections.Generic;

public class AudioPlayController : MonoBehaviour
{
    public List<AudioSource> audioSourceList = new List<AudioSource>();

    private int currentIndex = 0; // record index

  

   
    public void PlayNextAudio()
    {
        if (audioSourceList.Count == 0) return;

        StopAllSources();
        PlayCurrent();

        // Index count up
        currentIndex = (currentIndex + 1) % audioSourceList.Count;
    }
    public void PlayPreviousSource()
    {
        if (audioSourceList.Count == 0) return;

        StopAllSources();

        // Calculate pev index
        currentIndex = (currentIndex - 1 + audioSourceList.Count) % audioSourceList.Count;

        PlayCurrent();
    }

    private void PlayCurrent()
    {
        AudioSource target = audioSourceList[currentIndex];
        if (target != null)
        {
            target.Play();
            Debug.Log($"Playing{target.gameObject.name})");
        }
    }

    public void StopAllSources()
    {
        foreach (var source in audioSourceList)
        {
            if (source != null) source.Stop();
        }
    }
 
}
