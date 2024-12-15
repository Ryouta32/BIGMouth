using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/* 床の座標取得して中ベタの位置を指定する */

public class NormalbetaSpawn : MonoBehaviour
{
    OVRSceneManager _sceneManager;

    OVRScenePlane floor;

    private void Awake()
    {
        _sceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        //ルーム設定の読み込みが成功した時のコールバック登録
        _sceneManager.SceneModelLoadedSuccessfully += onSceneModelLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        floortranform();
    }

    private void onSceneModelLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //床
        floor = sceneRoom.Floor;
    }

    void floortranform()
    {
        gameObject.transform.position = new Vector3(this.transform.position.x, -0.5f,this.transform.position.z);
    }
}
