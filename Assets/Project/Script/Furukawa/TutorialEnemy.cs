﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        data = new EnemyData(_data);
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();
        tutorialSC = GameObject.Find("tutorial").GetComponent<tutorialScript>();
        //anim = gameObject.GetComponent<Animator>();

        tutorialSC.SetPos(transform.position);
        if (SetOff)
            Destroy(gameObject);
    }

    void Update()
    {
        Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
        if (diff.magnitude < bouSaki.GetInhaleDis() && bouSaki.GetInHale() && data.state == EnemyData.State.stun)
        {
            //吸い込みの処理

            bouSaki.StartOfSuction(transform.position - bouSaki.transform.position,data.type);
            inHale = true;
            //成功アナウンスに変える
            AudioSource.PlayClipAtPoint(AudioManager.manager.data.damage, this.gameObject.transform.position);
            tutorialSC.CLEAR();
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(data.sutnCount);
        if (collision.gameObject.CompareTag("Brush"))
        {
            AudioManager.manager.PlayPoint(AudioManager.manager.data.kill, this.gameObject);
            GameObject clone = Instantiate(damageEffect, transform.position, Quaternion.identity);
            Destroy(clone, 1.0f);
            //スタン状態なら消す
            if (data.state == EnemyData.State.stun)
            {
                //失敗アナウンスに変える
                //AudioSource.PlayClipAtPoint(AudioManager.manager.data.miniBom, this.gameObject.transform.position);
                tutorialSC.Retry();
                //anim.SetFloat("Speed", 1);
                AudioManager.manager.PlayPoint(AudioManager.manager.data.tutorialSippai,tutorialSC.gameObject);
                AudioManager.manager.Play(AudioManager.manager.data.sippai);
                Destroy(this.gameObject);
            }
            else
            {
                data.sutnCount--;
            }

            //UIをスタン状態にする
            tutorialSC.SetState(tutorialUIState.stun);
        }
    }
    IEnumerator Stun()//スタン中の処理
    {
        //anim.SetFloat("Speed", 0);
        stunEffect.SetActive(true);
        AudioManager.manager.PlayPoint(AudioManager.manager.data.stun, this.gameObject);
        //UIキル状態にする
        tutorialSC.SetState(tutorialUIState.kill);
        yield return new WaitForSeconds(1.0f);
        SetState(EnemyData.State.stun);
        yield return new WaitForSeconds(data.sutnTime );

        SetState(EnemyData.State.general);
        stunEffect.SetActive(false);
        //anim.SetFloat("Speed", 1);

        tutorialSC.SetState(tutorialUIState.start);
    }
    private void OnCollisionExit(Collision collision)
    {

        if (data.sutnCount <= 0)
        {
            StunReturn();
            StartCoroutine("Stun");
        }
        else
            SetState(EnemyData.State.escape);
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
