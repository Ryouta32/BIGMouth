using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class MashSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    [SerializeField] GameObject kinokoprefab;

    private void Awake()
    {
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
    }

    void onAnchorsLoaded()
    {
        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach　(var classification in classifications)
        {
            if　(classification.Contains(OVRSceneManager.Classification.Bed))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, -0.5f, classification.transform.position.z);

                Instantiate(kinokoprefab, pos, Quaternion.identity);
            }
        }
    }
}
