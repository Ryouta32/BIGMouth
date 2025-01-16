﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class tutorialScript : MonoBehaviour
{
    [SerializeField] GameObject fastBeta;
    [SerializeField] SceneName.sceneName sceneName;
    [SerializeField] Animator UIanima;
    Animator StageAnima;
    [SerializeField] TutorialUIScript uIScript;
    //[SerializeField] GameObject Timeline;
    GameObject obj;
    AudioSource source;
    bool isAudio = true;
    bool isClear=false;
    bool isRetry = false;
    bool uianima = false;
    Vector3 fastPos;
    void Start()
    {
        //Timeline.SetActive(false);
        source = GetComponent<AudioSource>();
        source.clip = AudioManager.manager.data.announce;
        source.Play();
        uIScript.gameObject.SetActive(false);
    }

    void Update()
    {
        if(!isClear){
            if ((!source.isPlaying && isAudio) || (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && isAudio) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                isAudio = false;
                source.Stop();
                Play();
                //CLEAR();
                //if (Input.GetKeyDown(KeyCode.LeftShift))
                    //CLEAR();
            }
        }else
        if(!source.isPlaying && isAudio)
        {
            isAudio=false;
            DebugText.LogText.Log(StageAnima.name);
            StageAnima.SetTrigger("Start");
            //SceneManager.LoadScene(sceneName.ToString());
            Debug.Log("げーむかいしー");
            uIScript.gameObject.SetActive(true);

            if (obj != null)
                Destroy(obj);
        }

        if (isRetry && !source.isPlaying&&uianima)
        {
            isRetry = false;
            obj = Instantiate(fastBeta, transform.position, Quaternion.identity);
            obj.GetComponent<TutorialEnemy>().SetTutorial(this);
            source.clip = AudioManager.manager.data.announce;
        }

    }
    public void Play()
    {
        obj = Instantiate(fastBeta,transform.position, Quaternion.identity);
        obj.GetComponent<TutorialEnemy>().SetTutorial(this);
        uIScript.gameObject.SetActive(false);
    }
    public void Retry()
    {
        isRetry = true;
        UIanima.gameObject.SetActive(true);
        uIScript.Retry();
    }
    public void SetState(tutorialUIState state)
    {
        uIScript.SetState(state);
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
    public void setanima(bool a) => uianima = a;
    public void setStageAnima(Animator animator) => StageAnima = animator;
    public void SetObj(Vector3 pos) => fastPos = pos;
}
