using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class MashSpawn : MonoBehaviour
{
    [SerializeField] GameObject kinokoprefab;
    [SerializeField] GameObject tentacleprefab;
    OVRSceneManager ovrSceneManager;
    GameObject dragonprefab;
    OVRScenePlane floor;


    private void Awake()
    {
        dragonprefab = GameObject.Find("DragonPrefab");
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
    }

    void onAnchorsLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //床
        floor = sceneRoom.Floor;
        float posy = floor.transform.position.y;

        floor.transform.position = new Vector3(floor.transform.position.x, posy + 0.5f, floor.transform.position.z);

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach　(var classification in classifications)
        {
            //キノコ
            if　(classification.Contains(OVRSceneManager.Classification.Bed))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, posy, classification.transform.position.z);

                if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1f, LayerMask.GetMask("Wall")))
                {
                    transform.position = hit.point;
                    Instantiate(kinokoprefab, pos, Quaternion.identity);
                }
                else
                {
                    Instantiate(kinokoprefab, pos, Quaternion.identity);
                }
            }

            //触手
            if (classification.Contains(OVRSceneManager.Classification.Lamp))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, posy, classification.transform.position.z);

                if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1f, LayerMask.GetMask("Wall")))
                {
                    transform.position = hit.point;
                    Instantiate(tentacleprefab, pos, Quaternion.identity);
                }
                else
                {
                    Instantiate(tentacleprefab, pos, Quaternion.identity);
                }
            }

            //ドラゴンの生成位置
            if (classification.Contains(OVRSceneManager.Classification.Storage))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, posy + 1.0f, classification.transform.position.z + 2f);
                dragonprefab.transform.position = pos;

                //if (Physics.Raycast(dragonprefab.transform.position, transform.forward, out RaycastHit hit, 10f, LayerMask.GetMask("Obstacle")))
                //{
                //    Quaternion hitRotation = hit.transform.rotation;
                //    dragonprefab.transform.rotation = hitRotation;
                //}
            }
        }
    }
}
