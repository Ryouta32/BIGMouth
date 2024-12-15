using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 部屋のオブジェクトを取得して生成させる */

public class DragonSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    [SerializeField] GameObject dragonprefab;

    private void Awake()
    {
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
    }

    void onAnchorsLoaded()
    {
        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.Storage))
            {
                dragonprefab.transform.position = classification.transform.position;
                //Instantiate(dragonprefab, classification.transform.position, Quaternion.identity);
            }
        }
    }
}
