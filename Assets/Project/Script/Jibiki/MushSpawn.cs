using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class MushSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    OVRScenePlane floor;
    GameObject dragonprefab;
    GameObject CenterCamera;

    private void Awake()
    {
        //ドラゴンの位置設定
        CenterCamera = GameObject.Find("CenterEyeAnchor");
        dragonprefab = GameObject.Find("DragonPrefab");
        dragonprefab.transform.position = CenterCamera.transform.position + new Vector3(0, 0, 5);

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
        float posy = floor.transform.position.y;

        floor.transform.position = new Vector3(floor.transform.position.x, posy + 0.5f, floor.transform.position.z);
    }
}
