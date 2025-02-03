using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSet : MonoBehaviour
{
    RectTransform rect;
    OVRScenePlane floor;
    OVRSceneManager ovrSceneManager;
    float posy;

    // Start is called before the first frame update
    private void Awake()
    {
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
        posy = floor.transform.position.y;

        rect = GetComponent<RectTransform>();
        rect.position = new Vector3(0, posy, 1.5f);
    }

}
