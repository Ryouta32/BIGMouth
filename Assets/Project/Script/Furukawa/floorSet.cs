using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorSet : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    OVRScenePlane floor;
    GameObject dragonprefab;
    float posy;
    void onAnchorsLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //床
        floor = sceneRoom.Floor;
        posy = floor.transform.position.y;
        floor.transform.position = new Vector3(floor.transform.position.x, posy, floor.transform.position.z);

        //dragonprefab.transform.position = new Vector3(CenterCamera.transform.position.x, floor.transform.position.y + 0.4f, CenterCamera.transform.position.z + 5);

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
