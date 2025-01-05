using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    [SerializeField] GameObject stunEffect;
    [SerializeField] GameObject DestroyEffect;
    [SerializeField] public EnemyData _data;
    public BouSakiScript bouSaki;
    private EnemyData data;
    private tutorialScript tutorialSC;
    bool inHale;
    // Start is called before the first frame update
    void Start()
    {
        data = new EnemyData(_data);
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
        if (diff.magnitude < bouSaki.GetInhaleDis() && bouSaki.GetInHale() && data.state == EnemyData.State.stun)
        {
            //吸い込みの処理

            bouSaki.StartOfSuction(transform.position - bouSaki.transform.position);
            inHale = true;
            //成功アナウンスに変える
            AudioSource.PlayClipAtPoint(AudioManager.manager.data.miniBom, this.gameObject.transform.position);

            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brush"))
        {
            AudioManager.manager.PlayPoint(AudioManager.manager.data.miniFollDown, this.gameObject);

            //スタン状態なら消す
            if (data.state == EnemyData.State.stun)
            {
                //失敗アナウンスに変える
                //AudioSource.PlayClipAtPoint(AudioManager.manager.data.miniBom, this.gameObject.transform.position);
                tutorialSC.Retry();
                Debug.Log("しっぱい！");
                Destroy(this.gameObject);
            }
            data.sutnCount--;
            if (data.sutnCount <= 0)
            {
                SetState(EnemyData.State.stun);
                StartCoroutine("Stun");
            }
            else
                SetState(EnemyData.State.escape);
        }
    }
    IEnumerator Stun()//スタン中の処理
    {
        stunEffect.SetActive(true);
        Debug.Log("スタンエフェクト");
        AudioManager.manager.PlayPoint(AudioManager.manager.data.ministun, this.gameObject);
        yield return new WaitForSeconds(data.sutnTime);
        SetState(EnemyData.State.general);
        StunReturn();
        stunEffect.SetActive(false);
    }
    private void OnDestroy()
    {
        //Destroy(DestroyEffect, 5);
        if (!inHale)
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
    }
    public void StunReturn() => data.sutnCount = _data.sutnCount;

    public void SetState(EnemyData.State sta)=>data.state = sta;
    public void SetTutorial(tutorialScript sc) => tutorialSC = sc;
}
