using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/* 床の座標取得して */

public class NormalbetaSpawn : MonoBehaviour
{
    OVRSceneManager _sceneManager;

    Vector3 pos;

    //[SerializeField] TextMeshProUGUI textText;

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
    }

    // Update is called once per frame
    void Update()
    {
        floortranform();
    }

    private void onSceneModelLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //天井
        OVRScenePlane ceiling = sceneRoom.Ceiling;
        //床
        floor = sceneRoom.Floor;
        //壁
        OVRScenePlane[] walls = sceneRoom.Walls;

    }

    void floortranform()
    {
        gameObject.transform.position = new Vector3(this.transform.position.x, -0.5f,this.transform.position.z);
        //textText.text = floor.transform.localScale.ToString();
    }
}
