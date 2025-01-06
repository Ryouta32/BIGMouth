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
    bool normal=false;
    bool mash=false;
    bool spawn = true;
    [SerializeField] bool debugmode;
    public static Vector3 mashPos;
    public static Vector3 tentPos;
    private void Start()
    {
        betaSpawn = GetComponent<BetaSpawn>();

    }

    public void ClearCheck() {
        Debug.Log(bossCount + " " + killCount);
        if ((bossCount <= killCount)&&mash&&normal&&spawn)
        {
            spawn = false;
            GameObject obj = Instantiate(Ball, bossPos.position, Quaternion.identity);
            obj.GetComponent<BIGBallSC>().setParent(bossPos);
        }
        if (enemys.Count == 0)
        {
            //ここにゲームクリアの処理
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
            mash = true;
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
    public void killMash() =>mash=true;
    public void ResetEnemys() => enemys=new List<GameObject>();
    public bool SpawnCheck() => enemys.Count>=spawnLimit;
}
