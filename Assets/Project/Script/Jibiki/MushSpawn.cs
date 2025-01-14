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

    [SerializeField] GameObject Fade;


    private void Awake()
    {
        Fade.SetActive(false);
        //ドラゴンの位置設定
        CenterCamera = GameObject.Find("CenterEyeAnchor");
        dragonprefab = GameObject.Find("DragonPrefab");

        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
        Fade.SetActive(false);
    }
    void onAnchorsLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //床
        floor = sceneRoom.Floor;
        float posy = floor.transform.position.y;

        floor.transform.position = new Vector3(floor.transform.position.x, posy + 0.5f, floor.transform.position.z);
        //dragonprefab.transform.position = new Vector3(CenterCamera.transform.position.x, floor.transform.position.y + 0.4f, CenterCamera.transform.position.z + 5);

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.Table))
            {
                dragonprefab.transform.position = new Vector3(classification.transform.position.x, floor.transform.position.y + 0.4f, classification.transform.position.z + 4f);
            }
        }

    }
}
