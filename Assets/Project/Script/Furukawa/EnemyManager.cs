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
    bool normal;
    bool mash;

    private void Start()
    {
        betaSpawn = GetComponent<BetaSpawn>();
    }
    public void ClearCheck() {
        if (bossCount <= killCount&&mash&&normal)
        {
           GameObject obj= Instantiate(BIGBETA, bossPos.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward.normalized * 300);
            Instantiate(Ball, bossPos.position, Quaternion.identity);

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
    public void SetBossPos(Transform tra) => bossPos = tra;
}
