using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Collections;
public class tutorialScript : MonoBehaviour
{
    [SerializeField] GameObject fastBeta;
    [SerializeField] SceneName.sceneName sceneName;
    [SerializeField] Animator UIanima;
    Animator StageAnima;
    [SerializeField] TutorialUIScript uIScript;
    [SerializeField]List<TutorialPieceManager> pieceManagers = new List<TutorialPieceManager>();
    //[SerializeField] GameObject Timeline;
    GameObject obj;
    bool isAudio = true;
    bool isClear = false;
    bool koko = false;
    bool wall;
    Vector3 fastPos;
    tutorialWall tutorialWall;
    void Start()
    {
        //Timeline.SetActive(false);
        wall = false;
    }

    void Update()
    {
        if (!isClear&&koko)
        {
            if ((!AudioManager.manager.GetSource().isPlaying && isAudio) || (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && isAudio) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                isAudio = false;
                AudioManager.manager.GetSource().Stop();
                Play();
                //CLEAR();
                //if (Input.GetKeyDown(KeyCode.LeftShift))
                //CLEAR();
            }
        }

        if (!AudioManager.manager.GetSource().isPlaying && isAudio&&isClear)
        {
            isAudio = false;
            StageAnima.SetTrigger("Start");
            //SceneManager.LoadScene(sceneName.ToString());
            Debug.Log("げーむかいしー");
            uIScript.gameObject.SetActive(true);
            if (obj != null)
                Destroy(obj);
        }

        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
            CLEAR();
        //if (isRetry && !source.isPlaying && uianima)
        //{
        //    isRetry = false;
        //    //obj = Instantiate(fastBeta, transform.position, Quaternion.identity);
        //    obj.GetComponent<TutorialEnemy>().SetTutorial(this);
        //    source.clip = AudioManager.manager.data.announce;
        //}

    }
    public void KOKO()
    {
        AudioManager.manager.Play(AudioManager.manager.data.announce);
        koko = true;
    }
    public void Play()
    {
        obj = Instantiate(fastBeta, fastPos, Quaternion.identity);
        obj.GetComponent<TutorialEnemy>().SetTutorial(this);
        uIScript.gameObject.SetActive(true);
        uIScript.transform.position = fastPos;
    }
    public void Retry()
    {
        UIanima.gameObject.SetActive(true);
        uIScript.Retry();
        SetState(tutorialUIState.start);
    }
    public void SetState(tutorialUIState state)
    {
        uIScript.SetState(state);
    }
    public void CLEAR()
    {
        if (!wall)
            return;
        uIScript.gameObject.SetActive(false);
        //スタート処理。ドラゴンどうやったら時間弄れるんや
        if (!isClear)
        {
            AudioManager.manager.Stop();
            AudioManager.manager.Play(AudioManager.manager.data.free);
            isAudio = true;
            //Timeline.SetActive(true);
            isClear = true;
        }
    }
    public void PlayWall()
    {
        AudioManager.manager.Stop();
        AudioManager.manager.Play(AudioManager.manager.data.handle);
        wall = true;
        StartCoroutine("wallStart");

    }
    IEnumerator wallStart()
    {
        yield return new WaitWhile(() =>AudioManager.manager.GetSource().isPlaying);
        SetState(tutorialUIState.wall);
        for (int i = 0; i < pieceManagers.Count; i++)
            pieceManagers[i].WallStart();
    }
    public void setStageAnima(Animator animator) => StageAnima = animator;
    public void SetPos(Vector3 pos)
    {
        fastPos = pos;
    }
    public Vector3 GetPos() => fastPos;
    public void SetWall(tutorialWall a) => tutorialWall = a;
    public void SetPiece(TutorialPieceManager piece)
    {
        pieceManagers.Add(piece);
    }
}
