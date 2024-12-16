using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class TentacleSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    [SerializeField] GameObject tentacleprefab;

    private void Awake()
    {
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1f, LayerMask.GetMask("Wall")))
        {
            transform.position = hit.point;
            Instantiate(tentacleprefab, hit.point, Quaternion.identity);
        }
    }

    void onAnchorsLoaded()
    {
        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.Lamp))
            {
                //Vector3 pos = new Vector3(classification.transform.position.x, -1f, classification.transform.position.z);

                Vector3 pos = new Vector3(classification.transform.position.x, transform.position.y, classification.transform.position.z);

                if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1f, LayerMask.GetMask("Wall")))
                {
                    transform.position = hit.point;
                    Instantiate(tentacleprefab, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
