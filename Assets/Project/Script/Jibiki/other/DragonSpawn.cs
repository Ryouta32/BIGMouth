using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 部屋のオブジェクトを取得してドラゴン生成させる */

public class DragonSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    GameObject dragonprefab;
    OVRScenePlane floor;
    [SerializeField] Transform cam;

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

        foreach (var classification in classifications)
        {
            //ドラゴンの生成位置
            if (classification.Contains(OVRSceneManager.Classification.Storage))
            {
                //Vector3 pos = new Vector3(classification.transform.position.x, posy + 1.0f, classification.transform.position.z + 2f);
                //dragonprefab.transform.position = pos;
                dragonprefab.transform.position = cam.transform.position + new Vector3(0, 0, 5);

                //if (Physics.Raycast(dragonprefab.transform.position, transform.forward, out RaycastHit hit, 10f, LayerMask.GetMask("Obstacle")))
                //{
                //    Quaternion hitRotation = hit.transform.rotation;
                //    dragonprefab.transform.rotation = hitRotation;
                //}
            }
        }
    }
}
