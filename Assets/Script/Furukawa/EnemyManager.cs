using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
   [SerializeField] List<GameObject> enemys;
    [SerializeField] int spawnLimit;
    public void ClearCheck() {
        if (enemys.Count == 0)
        {
            //‚±‚±‚ÉƒQ[ƒ€ƒNƒŠƒA‚Ìˆ—
            SceneManager.LoadScene(SceneName.sceneName.ClearScene.ToString());
        }
    }
    
    public void AddEnemys(GameObject obj) => enemys.Add(obj);
    public void DestroyEnemys(GameObject obj) { enemys.Remove(obj); ClearCheck(); }
    public void ResetEnemys() => enemys=new List<GameObject>();
    public bool SpawnCheck() => enemys.Count>=spawnLimit;
}
