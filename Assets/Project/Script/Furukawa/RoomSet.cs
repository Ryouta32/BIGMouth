using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSet : MonoBehaviour
{
    enum name
    { Floor, Ceiling, WallFace, Desk, Couch, DoorFrame, WindowFrame, Other, Storage, Bed, Screen, Lamp, Plant, Table, WallArt, InvisibleWallFace, GlobalMesh } 
    [SerializeField] name ObjName;
    OVRSceneManager ovrSceneManager;
    OVRScenePlane floor;

    RectTransform rect;
    float posy;
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
        posy = floor.transform.position.y + 0.1f;
        //rect = GetComponent<RectTransform>();
        //rect.position = new Vector3(0, posy, 1.5f);

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.WallArt))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, floor.transform.position.y + 1.4f, classification.transform.position.z);
                transform.position = pos;
            }
        }
    }
}
