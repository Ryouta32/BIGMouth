﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HibiKabe : MonoBehaviour
{
    [SerializeField] Material[] materials;
    int val=0;
    MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        onAnchorsLoaded();
    }

    private void Update()
    {
        transform.position += new Vector3( 0.001f,0,0.003f);
    }
    public void SetHibi()
    {
        meshRenderer.material=materials[val];
        val ++ ;
    }
    void onAnchorsLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //dragonprefab.transform.position = new Vector3(CenterCamera.transform.position.x, floor.transform.position.y + 0.4f, CenterCamera.transform.position.z + 5);

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.WallArt))
            {
                transform.position = new Vector3(classification.transform.position.x-5,classification.transform.position.y, classification.transform.position.z);
            }
        }
    }
}
