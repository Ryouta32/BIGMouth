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
        NullCheck();
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
        NullCheck();
        source.PlayOneShot(clip);
    }
    public void Stop()
    {
        source.Stop();
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

        audioSource.spatialBlend = 1;
        audioSource.volume = manager.SEvol;
        audioSource.PlayOneShot(clip);
    }
    public void PlayPoint(AudioClip clip, GameObject obj,float val)
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

        audioSource.spatialBlend = 1;
        audioSource.volume = manager.SEvol*val;
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
        audioSource.spatialBlend = 1;
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
    private void NullCheck()
    {
        if (source == null)
            source.GetComponent<AudioSource>();
    }
    IEnumerator loop()
    {
        source.clip = loopClip;
        for (int i = 0; i < loopCount; i++)
        {

            if (source != null)
            {
                source.PlayOneShot(loopClip);
                //Debug.Log(source.isPlaying);
                yield return new WaitForSeconds(source.time);
            }
            else break;
        }
        if(source!=null)
        source.clip = null;
    }
    public AudioSource GetSource() => source;
}
