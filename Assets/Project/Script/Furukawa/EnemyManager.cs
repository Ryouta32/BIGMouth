﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
   [SerializeField] List<GameObject> enemys;
    [SerializeField] int spawnLimit;
    [SerializeField] GameObject BIGBETA;
    [SerializeField] GameObject Ball;
    [SerializeField] Transform bossPos;
     BetaSpawn betaSpawn;
    [Tooltip("ボスが出るまでのキル数")][SerializeField] int bossCount;
    [HideInInspector] public int killCount;
    [SerializeField]BouSakiScript bouSakiScript;
    bool normal=false;
    bool mush=false;
    bool spawn = true;
    [SerializeField] bool debugmode;
    public static Vector3 mushPos;
    public static Vector3 tentPos;

    bool clearflag;

    private void Start()
    {
        betaSpawn = GetComponent<BetaSpawn>();
        clearflag = true;
    }

    public void ClearCheck() {
        Debug.Log(bossCount + " " + killCount);
        if ((bossCount <= killCount)&&mush&&normal&&spawn)
        {
            spawn = false;
            GameObject obj = Instantiate(Ball, bossPos.position, Quaternion.identity);
            obj.GetComponent<BIGBallSC>().setParent(bossPos);
            obj.GetComponent<BIGBallSC>().setSaki(bouSakiScript);
        }
        if (enemys.Count == 0 && clearflag)
        {
            //ここにゲームクリアの処理
            clearflag = false;
            //SceneManager.LoadScene(SceneName.sceneName.ClearScene.ToString());
        }
    }

    public void GameStart()
    {
        if (debugmode)
        {
            normal = true;
            mush = true;
            ClearCheck();
        }
    }
    
    public void AddEnemys(GameObject obj) => enemys.Add(obj);
    public void DestroyEnemys() { 
        //enemys.Remove(obj);
        killCount++;
        ClearCheck();
    }
    public void killNormal() =>normal=true;
    public void killMash() =>mush=true;
    public void ResetEnemys() => enemys=new List<GameObject>();
    public bool SpawnCheck() => enemys.Count>=spawnLimit;
}
