﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnima : MonoBehaviour
{
    Animator anima;
    float time;
    float limit;
    [SerializeField] BetaSpawn spawn;
    [SerializeField]float TentaTime;
    [SerializeField]float MushTime;
    bool mush=true;
    bool tent=true;
    float normalTime = 0;

    void Start()
    {
        limit = Random.Range(0, 10);
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        normalTime += Time.deltaTime;
        time += Time.deltaTime;

        if (time >= limit)
        {
            //anima.SetTrigger("Cough");
            time = 0;
            limit = Random.Range(0, 10);
        }

        if (normalTime >= TentaTime&&tent)
        {
            anima.SetTrigger("TentacleTrigger");
            tent = false;
        }
        if (normalTime >= MushTime&&mush)
        {
            anima.SetTrigger("MushTrigger");
            mush = false;
        }
    }
    public void Spawn()
    {
        //spawn.StartSpawan();
    }
    public void StartBGM() 
    {
        AudioManager.manager.PlayBGM(AudioManager.manager.data.mainBGM);
    }
    public void PlayHelp()=>
        AudioManager.manager.PlayPoint(AudioManager.manager.data.help, gameObject);
}
