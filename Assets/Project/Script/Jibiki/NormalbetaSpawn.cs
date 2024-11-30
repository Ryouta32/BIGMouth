using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/* 床の座標取得して */

public class NormalbetaSpawn : MonoBehaviour
{
    [SerializeField]
    private OVRSceneManager _sceneManager;

    Vector3 pos;

    [SerializeField] TextMeshProUGUI textText;
    private List<OVRSceneAnchor> anchors = new List<OVRSceneAnchor>();

    private void Awake()
    {
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
        OVRScenePlane floor = sceneRoom.Floor;
        //壁
        OVRScenePlane[] walls = sceneRoom.Walls;

        pos.y = floor.transform.position.y;
    }

    void floortranform()
    {
        gameObject.transform.position = new Vector3(this.transform.position.x, pos.y,this.transform.position.z);
        textText.text = gameObject.transform.position.ToString();
    }
}
