using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialScript : MonoBehaviour
{
    [SerializeField] GameObject fastBeta;
    [SerializeField] SceneName.sceneName sceneName;
    //[SerializeField] GameObject Timeline;
    GameObject obj;
    AudioSource source;
    bool isAudio = true;
    bool isClear=false;
    void Start()
    {
        //Timeline.SetActive(false);
        source = GetComponent<AudioSource>();
        source.clip = AudioManager.manager.data.announce;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isClear){
            if ((!source.isPlaying && isAudio) || (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && isAudio) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                isAudio = false;
                source.Stop();
                Play();
                //CLEAR();
                if (Input.GetKeyDown(KeyCode.LeftShift))
                    CLEAR();
            }
        }else
        if(!source.isPlaying && isAudio)
        {
            isAudio=false;
            SceneManager.LoadScene(sceneName.ToString());
            Debug.Log("げーむかいしー");
            if (obj != null)
                Destroy(obj);
            Destroy(gameObject);
        }
    }
    public void Play()
    {
        obj = Instantiate(fastBeta,transform.position, Quaternion.identity);
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
        source.clip = AudioManager.manager.data.TutorialClear;
        source.Play();
        isAudio = true;
        //Timeline.SetActive(true);
        isClear = true;

    }
}
