﻿using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    EnemyManager manager;
    [HideInInspector]
    public BouSakiScript bouSaki;
    [SerializeField] public EnemyData _data;
    [SerializeField] GameObject stunEffect;
    [SerializeField] GameObject damageEffect;
    [SerializeField] GameObject DestroyEffect;
    [SerializeField] GameObject destorySplash;
    [SerializeField] bool root=false;
    [HideInInspector]
    public Rigidbody rb;
    public bool inHale;
    [HideInInspector]
    public EnemyData data;
    Animator anim;

    private void Start()
    {
        initialization();
        data = new EnemyData(_data);
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        if (manager == null)
            manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }
    private void Update()
    {
        if (transform.position.y > 10 || transform.position.y < -10)
        {
            kill();
        }

        Vector3 diff = bouSaki.gameObject.transform.position - transform.position;
        if (diff.magnitude < bouSaki.GetInhaleDis() && bouSaki.GetInHale() && data.state == EnemyData.State.stun)
        {
            //吸い込みの処理

            bouSaki.StartOfSuction(transform.position - bouSaki.transform.position,data.type);

            destroyObj();

            inHale = true;
            kill();
        }
    }
    private void kill()
    {
        if (root)
        {
            Destroy(transform.root.gameObject);
            BetaText.betacount--;
        }
        else
        {
            Destroy(this.gameObject);
            BetaText.betacount--;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Brush")
            rb.isKinematic = true;
        else
            rb.isKinematic = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Brush")
            rb.constraints = RigidbodyConstraints.None;

        StunCheck();
    }

    //中ベタ用
    private void OnTriggerExit(Collider other)
    {
        if(this.gameObject.tag == "Normal" && other.transform.tag == "Brush")
        {
            if (data.sutnCount <= 0)
            {
                StartCoroutine("Stun");
            }
            else
            {
                SetState(EnemyData.State.escape);
            }
        }
    }
    //初期化
    public void initialization()
    {
        bouSaki = GameObject.Find("Stick").GetComponent<bouScript>().GetSaki();
        data = new EnemyData(_data);
    }
    private void OnDestroy()
    {
        if(!inHale)
        Instantiate(DestroyEffect, transform.position, Quaternion.identity);
    }
    public void HitDamage()
    {

        if (data.state == EnemyData.State.stun)
        {
            //destroyObj();
            //if (destorySplash != null)
            //    Instantiate(destorySplash, transform.position, Quaternion.identity);
            //AudioSource.PlayClipAtPoint(AudioManager.manager.data.damage, this.gameObject.transform.position);
            //kill();
            return;
        }
        else
        {
            AudioManager.manager.PlayPoint(AudioManager.manager.data.kill, this.gameObject);
            Instantiate(damageEffect, transform.position, Quaternion.identity);
            data.sutnCount--;
        }

        StunCheck();
        //Debug.Log(data.sutnCount);
    }
    IEnumerator Stun()//スタン中の処理
    {
        //スタンになったらアニメーション止める
        //anim.SetFloat("Speed", 0);
        if (data.state != EnemyData.State.stun)
        {
            stunEffect.SetActive(true);
            AudioManager.manager.PlayPoint(AudioManager.manager.data.stun, this.gameObject, 0.5f);
            SetState(EnemyData.State.stun);

            yield return new WaitForSeconds(0.2f);
            yield return new WaitForSeconds(data.sutnTime);
            SetState(EnemyData.State.general);
            StunReturn();
            stunEffect.SetActive(false);
        }
        //anim.SetFloat("Speed", 1);
    }
    public void MoveAudio()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.move,this.gameObject);
    }
    private void StunCheck()
    {

        if (data.sutnCount <= 0)
        {
            StartCoroutine("Stun");
        }
        else
            SetState(EnemyData.State.escape);
    }
    public void StunReturn() => data.sutnCount = _data.sutnCount;
    public void setManager(EnemyManager x) => manager = x;
    public void destroyObj()
    {
        if(manager != null)
        {
            if (GetComponent<NormalBetaCollision>())
            {
                manager.killNormal();
                manager.DestroyEnemys();
            }else if (GetComponent<MushroomManager>())
            {
                manager.killMash();
                manager.DestroyEnemys();
            }
            else
            {
                manager.DestroyEnemys();
            }
        }
    }
    public void SetState(EnemyData.State sta)=>data.state = sta;
}
