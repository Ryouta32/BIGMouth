using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioData data;
    public static AudioManager manager;
    [SerializeField] float BGMvol;
    [SerializeField] float SEvol;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = BGMvol;
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
        if (clip == null)
            Debug.Log("音源が設定されてないよ");
        AudioSource audioSource;
        if (!obj.GetComponent<AudioSource>())
            audioSource = obj.AddComponent<AudioSource>();
        else
            audioSource = obj.GetComponent<AudioSource>();

        audioSource.volume = manager.SEvol;
        audioSource.PlayOneShot(clip);
    }
    public void PlayPoint(AudioClip clip, GameObject obj,int count)
    {
        AudioSource audioSource;
        if (!obj.GetComponent<AudioSource>())
            audioSource = obj.AddComponent<AudioSource>();
        else
            audioSource = obj.GetComponent<AudioSource>();

        audioSource.volume = manager.SEvol;
        StartCoroutine( loop(audioSource, count, clip));
    }

    IEnumerator loop(AudioSource souce, int loop, AudioClip clip)
    {
        for (int i = 0; i < loop; i++)
        {
            //Debug.Log("ああ");
            souce.PlayOneShot(clip);
            yield return new WaitWhile(() => source.isPlaying);
        }
    }
    
}
