﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 中ベタのスポーン */

public class NormalBetaManager : MonoBehaviour
{
    //[Tooltip("スポーン位置")]
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject InEffect;
    [SerializeField] float repeattime;
    [SerializeField] BoxCollider[] col;
    [SerializeField] tentacleLine line;

    Animator anim;
    int number;
    int rot;

    [HideInInspector]
    public List<Transform> Children;

    [HideInInspector]
    public bool colsignal;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        colsignal = true;
        Children = new List<Transform>();

        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Children.Add(SpawnPoint.transform.GetChild(i)); // GetChild()で子オブジェクトを取得
        }

        //スタート時の位置
        number = Random.Range(0, Children.Count);
        gameObject.transform.position = new Vector3(Children[number].transform.position.x, SpawnPoint.transform.position.y, Children[number].transform.position.z);

        InvokeRepeating(nameof(StunStart), repeattime, repeattime);
    }

    //スポーン位置の選択
    void SpawnSelect()
    {
        //これはupdateでやる必要はないと思う
        Children.Clear();
        Debug.Log(SpawnPoint.transform.childCount);
        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Children.Add(SpawnPoint.transform.GetChild(i)); // GetChild()で子オブジェクトを取得
        }

        //number = Random.Range(0, Children.Count);
        
        if(Children.Count == 0)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            number = GetRandomValue(number);
            //ここのｙ座標どうしたいいのかあんまりわかってないよ
            gameObject.transform.position = new Vector3(Children[number].transform.position.x, SpawnPoint.transform.position.y, Children[number].transform.position.z);
        }
        line.setPos();

        anim.SetBool("Down", false);
        colsignal = true;
        InEffect.SetActive(false);
    }

    //同じところにスポーンするのを防ぐ
    int GetRandomValue(int oldNum)
    {
        int newNum = Random.Range(0, Children.Count);

        // 古い番号と同じとき
        if (newNum == oldNum)
        {
            int n = newNum + Random.Range(1, Children.Count);

            return n < Children.Count ? n : n - Children.Count;
        }
        else
        {
            return newNum;
        }
    }

    private void OnDestroy()
    {
        DragonVoice.TentacleDown = false;
    }

    void tyuuOut()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.tentacleOut, this.gameObject);
    }

    void OutEnabled()
    {
        foreach (BoxCollider collider in col)
        {
            collider.enabled = true;
        }
    }
    void InEnabled()
    {
        foreach (BoxCollider collider in col)
        {
            collider.enabled = false;
        }
    }

    void InParticle()
    {
        InEffect.SetActive(true);
    }

    void StunStart()
    {
        rot = Random.Range(0, 360);
        transform.Rotate(0, rot, 0);
        anim.SetTrigger("Attack");
    }

    void Stunsound()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.tentacleBetan, this.gameObject);
    }
}
