using System.Collections;
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

    CanvasChange cc;

    private void Start()
    {
        betaSpawn = GetComponent<BetaSpawn>();
        cc = GameObject.Find("CanvasChange").GetComponent<CanvasChange>();

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
        if (enemys.Count == 0)
        {
            //ここにゲームクリアの処理
            cc.Phase[0] = false;
            cc.Phase[1] = true;
            //SceneManager.LoadScene(SceneName.sceneName.ClearScene.ToString());
        }

        int x = 0;
        foreach (var item in enemys)
        {
            if (item.GetComponent<NormalBetaManager>())
                x++;
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
    public void DestroyEnemys(GameObject obj) { 
        enemys.Remove(obj);
        killCount++;
        ClearCheck();
    }
    public void killNormal() =>normal=true;
    public void killMash() =>mush=true;
    public void ResetEnemys() => enemys=new List<GameObject>();
    public bool SpawnCheck() => enemys.Count>=spawnLimit;
}
