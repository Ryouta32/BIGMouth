﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//それぞれのTrigger
//Damage
public class BIGEnemyAnima : MonoBehaviour
{
    [SerializeField] BigEnemyScript bigSc;
    [SerializeField] GameObject tentacle;
    [SerializeField] GameObject mush;
    [SerializeField] ParticleSystem third;
    [SerializeField] ParticleSystem forth;
    [SerializeField] int weekCount;
    [SerializeField] GameObject week;
    [SerializeField] Transform[] weekPos;
    Vector3 tentaPos;
    Vector3 mushPos;
    OVRScenePlane floor;
    GameObject tentaObj;
    GameObject mushObj;
    bool tentakill=false; 
    bool mushkill=false;
    int count = 0;
    Animator anima;
    string DamageStr = "Damage";
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        onAnchorsLoaded();
    }

    private void Update()
    {

        if (count >= weekCount)
        {
            bigSc.Erase();
        }
        if (tentakill && tentaObj == null)
        {
            tentakill = false;
            bigSc.SetInvincible(true);
            bigSc.GetAnima().anima.SetTrigger("kill");
        }
        if (mushkill && mushObj == null)
        {
            mushkill = false;
            bigSc.SetInvincible(true);
            bigSc.GetAnima().anima.SetTrigger("kill");
            for(int i = 0; i < weekPos.Length; i++)
            {
                GameObject obj = Instantiate(week, weekPos[i].position, Quaternion.identity, weekPos[i]);
                obj.GetComponent<BIGEnemyWeekPoint>().SetBig(bigSc);
            }
        }
    }
    public void Break()
    {
        count++;
        anima.SetTrigger(DamageStr);

    }
    public void WeekAudio()
    {
        AudioManager.manager.Play(AudioManager.manager.data.weekAnnounce);
    }
    public void KillAudio()
    {
        AudioManager.manager.Play(AudioManager.manager.data.killAnnounce);
    }

    public void fast()
    {
        tentaObj = Instantiate(tentacle, tentaPos, Quaternion.identity);
        tentakill = true;
    }
    public void second()
    {
        mushObj = Instantiate(mush, mushPos, Quaternion.identity);
        mushkill = true;
    }
    public void thirdAttack()
    {
        //third.Play();
    }
    public void thirdAttackStop()
    {
        //third.Stop();
    }
    public void forthAttack()
    {
        forth.Play();
    }
    public void forthAttackStop()
    {
        forth.Stop();
    }
    public void Invincible()
    {
        bigSc.SetInvincible(false);
    }
    void onAnchorsLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);
        float y = 0;
        floor = sceneRoom.Floor;
        float posy = floor.transform.position.y;
        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.Bed))
            {
                tentaPos = classification.transform.position;
            }
            if (classification.Contains(OVRSceneManager.Classification.Lamp))
            {
                mushPos = classification.transform.position;
            }
        }
        tentaPos.y = posy;
        mushPos.y = posy;
    }
}
