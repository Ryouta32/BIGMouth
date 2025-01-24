using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class MushSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    OVRScenePlane floor;
    GameObject dragonprefab;
    float posy;

    private void Awake()
    {
        //ドラゴンの位置設定
        dragonprefab = GameObject.Find("DragonPrefab");

        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
    }
    void onAnchorsLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //床
        floor = sceneRoom.Floor;
        posy = floor.transform.position.y;

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.Storage))
            {
                dragonprefab.transform.position = new Vector3(classification.transform.position.x, posy + 0.8f, classification.transform.position.z + 2f);

                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                float rayDistance = 10f; // レイの長さ
                LayerMask mask = LayerMask.GetMask("Wall");

                // "Wall"レイヤーにのみ反応するレイキャスト
                if (Physics.Raycast(ray, out hit, rayDistance, mask))
                {
                    // ヒットした位置への方向を計算
                    Vector3 directionToTarget = hit.point - transform.position;

                    // 自身の正面をヒットした方向に向ける
                    transform.rotation = Quaternion.LookRotation(directionToTarget);
                }
            }
        }
    }
}
