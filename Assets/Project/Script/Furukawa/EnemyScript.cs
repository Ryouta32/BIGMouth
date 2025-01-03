﻿using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    BetaLife betaLife;
    EnemyManager manager;
    public BouSakiScript bouSaki;
    [SerializeField] public EnemyData _data;
    [SerializeField] GameObject stunEffect;
    [SerializeField] GameObject damageEffect;
    [SerializeField] GameObject DestroyEffect;
    public Rigidbody rb;
    public bool inHale;
    [HideInInspector]
    public EnemyData data;
    float time=0;
    private void Start()
    {
        initialization();
        data = new EnemyData(_data);
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
        if (diff.magnitude < bouSaki.GetInhaleDis() && bouSaki.GetInHale() && data.state == EnemyData.State.stun)
        {
            //吸い込みの処理
            
            bouSaki.StartOfSuction(transform.position - bouSaki.transform.position);
            destroyObj();
            inHale=true;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Brush")
            rb.constraints = RigidbodyConstraints.FreezeAll;
        else
            rb.constraints = RigidbodyConstraints.None;

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Brush")
            rb.constraints = RigidbodyConstraints.None;
    }
    public void initialization()
    {
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();
        data = new EnemyData(_data);
        betaLife = GetComponent<BetaLife>();
    }
    private void OnDestroy()
    {
        //Destroy(DestroyEffect, 5);
        if(!inHale)
        Instantiate(DestroyEffect, transform.position, Quaternion.identity);
    }
    public void HitDamage()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.miniFollDown,this.gameObject,3);
        Instantiate(damageEffect, transform.position, Quaternion.identity);

        ////吸い込み
        //if (bouSaki.GetInHale() && data.state == EnemyData.State.stun)
        //{
        //    destroyObj();
        //    bouSaki.StartOfSuction(transform.position);
        //    AudioSource.PlayClipAtPoint(audioM.data.bom, this.gameObject.transform.position);
        //    Destroy(this.gameObject);
        //}
        //スタン状態なら消す
        if (data.state == EnemyData.State.stun)
        {
            destroyObj();
            Debug.Log("削除");
            AudioSource.PlayClipAtPoint(AudioManager.manager.data.miniBom, this.gameObject.transform.position);
            Destroy(this.gameObject);
        }
        data.sutnCount--;
        //Debug.Log(data.sutnCount + "だよｙｙｙｙｙｙｙｙ");
        if (data.sutnCount <= 0)
        {
            SetState(EnemyData.State.stun);
            StartCoroutine("Stun");
        }else
        SetState(EnemyData.State.escape);
    }
    IEnumerator Stun()//スタン中の処理
    {
        stunEffect.SetActive(true);
        Debug.Log("スタンエフェクト");
        AudioManager.manager.PlayPoint(AudioManager.manager.data.ministun,this.gameObject,3);
        yield return new WaitForSeconds(data.sutnTime);
        SetState(EnemyData.State.general);
        StunReturn();
        stunEffect.SetActive(false);
    }
    public void MoveAudio()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.miniMove,this.gameObject);
    }
    public void StunReturn() => data.sutnCount = _data.sutnCount;
    public void setManager(EnemyManager x) => manager = x;
    public void destroyObj()
    {
        if (GetComponent<NormalBetaManager>())
            manager.killNormal();
        if (GetComponent<MashroomManager>())
            manager.killMash();
        manager.DestroyEnemys(this.gameObject); 
    }
    public void SetState(EnemyData.State sta)=>data.state = sta;
}
