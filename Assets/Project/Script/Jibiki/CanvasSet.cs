using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSet : MonoBehaviour
{
    RectTransform rect;

    OVRScenePlane floor;
    float posy;

    // Start is called before the first frame update
    void Start()
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

        rect = GetComponent<RectTransform>();
        rect.position = new Vector3(0, posy, 1.5f);
    }

}
