using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioData data;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public AudioData GetData() => data;
    public void SetAudioScale(float vol) => source.volume = vol;
    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void PlayPoint(AudioClip clip,GameObject obj)
    {
        AudioSource audioSource;
        audioSource = obj.AddComponent<AudioSource>();
        audioSource.volume = source.volume;
        audioSource.PlayOneShot(clip);
    }
}
