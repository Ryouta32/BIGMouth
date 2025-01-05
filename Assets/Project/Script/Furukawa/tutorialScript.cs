using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject fastBeta;
    [SerializeField] GameObject Timeline;
    private GameObject obj;
    AudioSource source;
    private bool isAudio=true;
    void Start()
    {

        Timeline.SetActive(false);
        //AudioManager.manager.PlayPoint(AudioManager.manager.data.announce, this.gameObject);
        source = GetComponent<AudioSource>();
        source.clip = AudioManager.manager.data.announce;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if ((!source.isPlaying && isAudio)||(OVRInput.Get(OVRInput.RawButton.RHandTrigger)))
        {
            isAudio = false;
            Play();
        }
    }
    public void Play()
    {
        obj = Instantiate(fastBeta, transform.position, Quaternion.identity);
        obj.GetComponent<TutorialEnemy>().SetTutorial(this);
    }
    public void Retry()
    {
        obj = Instantiate(fastBeta, transform.position, Quaternion.identity);
        obj.GetComponent<TutorialEnemy>().SetTutorial(this);
        source.clip = AudioManager.manager.data.announce;

    }
    public void CLEAR()
    {
        //スタート処理。ドラゴンどうやったら時間弄れるんや
        source.clip = AudioManager.manager.data.announce;
        source.Play();
        Timeline.SetActive(true);
        Debug.Log("げーむかいしー");
    }
}
