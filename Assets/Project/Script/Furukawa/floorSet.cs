using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorSet : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    OVRScenePlane floor;
    GameObject dragonprefab;
    float posy;

    private void Start()
    {
        onAnchorsLoaded();
    }
    void onAnchorsLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //床
        floor = sceneRoom.Floor;
        posy = floor.transform.position.y;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, posy, gameObject.transform.position.z);
    }
}
