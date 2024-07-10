using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceilingtrack : MonoBehaviour
{
    OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();

    OVRScenePlane ceiling;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ceiling = sceneRoom.Ceiling;
    }
}
