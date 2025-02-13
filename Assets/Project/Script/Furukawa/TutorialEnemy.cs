using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    [SerializeField] GameObject stunEffect;
    [SerializeField] GameObject DestroyEffect;
    [SerializeField] public EnemyData _data;
    [SerializeField] GameObject damageEffect;
    [SerializeField] bool SetOff;
    public BouSakiScript bouSaki;
    private EnemyData data;
    private tutorialScript tutorialSC;
    bool inHale;
    Animator anim;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        data = new EnemyData(_data);
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();
        tutorialSC = GameObject.Find("tutorial").GetComponent<tutorialScript>();
        //anim = gameObject.GetComponent<Animator>();

        if (SetOff)
        {
            tutorialSC.SetPos(new Vector3(transform.position.x, transform.position.y, transform.position.z));
            //tutorialSC.SetPos(transform.position);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
        var direction = bouSaki.gameObject.transform.position - transform.position;
        direction.y = 0;

        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);
        if (diff.magnitude < bouSaki.GetInhaleDis() && bouSaki.GetInHale() && data.state == EnemyData.State.stun)
        {
            //吸い込みの処理
            bouSaki.StartOfSuction(transform.position - bouSaki.transform.position, data.type);
            inHale = true;
            //成功アナウンスに変える
            tutorialSC.PlayWall();
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brush"))
        {
            //AudioManager.manager.PlayPoint(AudioManager.manager.data.kill, this.gameObject);
            //GameObject clone = Instantiate(damageEffect, transform.position, Quaternion.identity);
            //Destroy(clone, 1.0f);
            ////スタン状態なら消す
            //if (data.state == EnemyData.State.stun)
            //{
            //    //失敗アナウンスに変える
            //    //AudioSource.PlayClipAtPoint(AudioManager.manager.data.miniBom, this.gameObject.transform.position);
            //    tutorialSC.Retry();
            //    //anim.SetFloat("Speed", 1);
            //    //AudioManager.manager.Stop();
            //    //AudioManager.manager.Play(AudioManager.manager.data.tutorialSippai);
            //    Destroy(this.gameObject);
            //}
            //else
            //{
            //    data.sutnCount--;
            //}

            ////UIをスタン状態にする
            //if (data.sutnCount == _data.sutnCount - 1)
            //    tutorialSC.SetState(tutorialUIState.stun);
        }
    }
    IEnumerator Stun()//スタン中の処理
    {
        //anim.SetFloat("Speed", 0);
        stunEffect.SetActive(true);
        AudioManager.manager.PlayPoint(AudioManager.manager.data.stun, this.gameObject, 0.5f);
        //UIキル状態にする
        tutorialSC.SetState(tutorialUIState.kill);
        SetState(EnemyData.State.stun);
        yield return new WaitForSeconds(data.sutnTime);

        SetState(EnemyData.State.general);
        stunEffect.SetActive(false);
        //anim.SetFloat("Speed", 1);

        tutorialSC.SetState(tutorialUIState.start);
    }
    private void OnCollisionExit(Collision collision)
    {

        //if (data.sutnCount <= 0)
        //{
        //    //StunReturn();
        //    //StartCoroutine("Stun");
        //}
        //else
        //    SetState(EnemyData.State.escape);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brush"))
        {
            time += Time.deltaTime;

            if (time >= 0.3f)
            {

                //スタン状態なら消す
                if (data.state == EnemyData.State.stun)
                {
                    //失敗アナウンスに変える
                    //AudioSource.PlayClipAtPoint(AudioManager.manager.data.miniBom, this.gameObject.transform.position);
                    //tutorialSC.Retry();
                    //anim.SetFloat("Speed", 1);
                    //AudioManager.manager.Stop();
                    //AudioManager.manager.Play(AudioManager.manager.data.tutorialSippai);
                    //Destroy(this.gameObject);
                }
                else
                {
                    AudioManager.manager.PlayPoint(AudioManager.manager.data.kill, this.gameObject);
                    GameObject clone = Instantiate(damageEffect, transform.position, Quaternion.identity);
                    Destroy(clone, 1.0f);
                    data.sutnCount--;
                }

                //UIをスタン状態にする
                if (data.sutnCount == _data.sutnCount - 1)
                    tutorialSC.SetState(tutorialUIState.stun);

                time = 0.0f;
                if (data.sutnCount <= 0)
                {
                    StunReturn();
                    StartCoroutine("Stun");
                }
            }
        }
    }
    private void OnDestroy()
    {
        //Destroy(DestroyEffect, 5);
        if (!inHale)
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
    }
    public void StunReturn() => data.sutnCount = _data.sutnCount;

    public void SetState(EnemyData.State sta) => data.state = sta;
    public void SetTutorial(tutorialScript sc) => tutorialSC = sc;
}
