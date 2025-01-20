using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HibiKabe : MonoBehaviour
{
    [SerializeField] Material[] materials;
    OVRSceneManager ovrSceneManager;
    int val=0;
    MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();

        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
    }
    public void SetHibi()
    {
        if (val == 1)
            Destroy(gameObject);
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
                transform.position = new Vector3(classification.transform.position.x,classification.transform.position.y, classification.transform.position.z-0.3f);
            }
        }
    }
}
