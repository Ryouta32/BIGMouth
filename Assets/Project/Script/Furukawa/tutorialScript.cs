using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    [SerializeField] GameObject fastBeta;
    [SerializeField] GameObject Timeline;
    [SerializeField] MashSpawn BetaSpawnManager;
    GameObject obj;
    AudioSource source;
    bool isAudio = true;

    void Start()
    {
        Timeline.SetActive(false);
        source = GetComponent<AudioSource>();
        source.clip = AudioManager.manager.data.announce;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if ((!source.isPlaying && isAudio)||(OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)&&isAudio)||Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAudio = false;
            source.Stop();
            Play();
            //CLEAR();
            if (Input.GetKeyDown(KeyCode.LeftShift))
                CLEAR();
        }
    }
    public void Play()
    {
        obj = Instantiate(fastBeta, BetaSpawnManager.tutorialpos, Quaternion.identity);
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

        //中ベタ表示
        BetaSpawnManager.ActiveObj();

        Debug.Log("げーむかいしー");
        if (obj != null)
            Destroy(obj);
        Destroy(gameObject);
    }
}
