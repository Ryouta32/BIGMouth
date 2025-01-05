using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject fastBeta;
    private GameObject obj;
    void Start()
    {
        obj = Instantiate(fastBeta,transform.position,Quaternion.identity);
        obj.GetComponent<TutorialEnemy>().SetTutorial(this);
        AudioManager.manager.PlayPoint(AudioManager.manager.data.announce, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Retry()
    {
        obj = Instantiate(fastBeta, transform.position, Quaternion.identity);
        obj.GetComponent<TutorialEnemy>().SetTutorial(this);

    }
    public void CLEAR()
    {
        //スタート処理。ドラゴンどうやったら時間弄れるんや
        Debug.Log("げーむかいしー");
    }
}
