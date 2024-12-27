using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioData data;
    public static AudioManager manager;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        manager = this;
    }

    public AudioData GetData() => data;
    public void SetAudioScale(float vol) => source.volume = vol;
    public void PlayBGM(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
    public void PlayPoint(AudioClip clip,GameObject obj)
    {
        AudioSource audioSource;
        if (obj.GetComponent<AudioSource>())
            audioSource = obj.AddComponent<AudioSource>();
        else
            audioSource = obj.GetComponent<AudioSource>();

        audioSource.volume = source.volume;
        audioSource.PlayOneShot(clip);
    }
}
