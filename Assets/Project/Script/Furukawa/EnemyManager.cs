using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
   [SerializeField] List<GameObject> enemys;
    [SerializeField] int spawnLimit;
    [SerializeField] GameObject BIGBETA;
    public void ClearCheck() {
        if (enemys.Count == 0)
        {
            //ここにゲームクリアの処理
            SceneManager.LoadScene(SceneName.sceneName.ClearScene.ToString());
        }

        int x = 0;
        foreach (var item in enemys)
        {
            if (item.GetComponent<NormalBetaManager>())
                x++;
        }
        if (x != 0)
            Instantiate(BIGBETA, transform.position, Quaternion.identity);
    }
    
    public void AddEnemys(GameObject obj) => enemys.Add(obj);
    public void DestroyEnemys(GameObject obj) { enemys.Remove(obj); ClearCheck(); }
    public void ResetEnemys() => enemys=new List<GameObject>();
    public bool SpawnCheck() => enemys.Count>=spawnLimit;
}
