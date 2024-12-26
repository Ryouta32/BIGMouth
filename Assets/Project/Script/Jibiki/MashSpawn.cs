using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class MashSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    [SerializeField] GameObject kinokoprefab;
    [SerializeField] GameObject tentacleprefab;
    GameObject dragonprefab;
    [SerializeField] GameObject targetObject;

    private void Awake()
    {
        dragonprefab = GameObject.Find("DragonPrefab");
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
                Vector3 pos = new Vector3(classification.transform.position.x, -1f, classification.transform.position.z);

                if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1f, LayerMask.GetMask("Wall")))
                {
                    transform.position = hit.point;
                    Instantiate(kinokoprefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(kinokoprefab, pos, Quaternion.identity);
                }
            }
            if (classification.Contains(OVRSceneManager.Classification.Lamp))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, -1f, classification.transform.position.z);

                if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1f, LayerMask.GetMask("Wall")))
                {
                    transform.position = hit.point;
                    Instantiate(tentacleprefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(tentacleprefab, pos, Quaternion.identity);
                }
            }
            if (classification.Contains(OVRSceneManager.Classification.Storage))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, classification.transform.position.y, 5f);
                dragonprefab.transform.LookAt(targetObject.transform);
                dragonprefab.transform.position = pos;
                //Instantiate(dragonprefab, classification.transform.position, Quaternion.identity);
            }

        }
    }
}
