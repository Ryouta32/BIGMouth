using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioData data;
    public static AudioManager manager;
    [SerializeField] float BGMvol;
    [SerializeField] float SEvol;
    AudioSource source;
    AudioClip loopClip;
    AudioSource loopSouce;
    int loopCount;
    private void Awake()
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
    public void Play(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.Log("音源が設定されてないよ");
            return;
        }
        source.PlayOneShot(clip);
    }
    public void PlayPoint(AudioClip clip,GameObject obj)
    {
        if (clip == null)
        {
            Debug.Log("音源が設定されてないよ");
            return;
        }
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
        loopClip = clip;
        loopCount= count;
        source = audioSource;
        StartCoroutine("loop");
    }

    public void StopPoint(GameObject obj)
    {
        if (obj.GetComponent<AudioSource>())
        {
            obj.GetComponent<AudioSource>().Stop();
        }
    }
    IEnumerator loop()
    {
        for (int i = 0; i < loopCount; i++)
        {
            source.PlayOneShot(loopClip);
            yield return new WaitWhile(() => source.isPlaying);
        }
    }
    
}
