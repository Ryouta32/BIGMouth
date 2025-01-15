using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class TutorialSpawn : MonoBehaviour
{
    [Tooltip("ショーケース")]
    [SerializeField] GameObject Case;

    [Tooltip("ショーケース2")]
    [SerializeField] GameObject Case2;

    [Tooltip("パネル")]
    [SerializeField] GameObject[] Panel;

    [SerializeField] GameObject Tutorial;

    [SerializeField] GameObject Ornament;

    OVRSceneManager ovrSceneManager;
    OVRScenePlane floor;

    int i = 0;
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
        float posy = floor.transform.position.y;

        floor.transform.position = new Vector3(floor.transform.position.x, posy, floor.transform.position.z);

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.Bed))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, posy, classification.transform.position.z);
                Instantiate(Case, pos, Quaternion.identity);
            }
            if (classification.Contains(OVRSceneManager.Classification.Lamp))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, posy, classification.transform.position.z);
                Instantiate(Case2, pos, Quaternion.identity);
            }
            //if (classification.Contains(OVRSceneManager.Classification.WallArt))
            //{
            //    Instantiate(Panel[i], classification.transform.position, Quaternion.identity);
            //    i++;
            //}
            if (classification.Contains(OVRSceneManager.Classification.Table))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, classification.transform.position.y - 0.4f, classification.transform.position.z);
                Tutorial.transform.position = pos;
            }
            if (classification.Contains(OVRSceneManager.Classification.WallArt))
            {
                Instantiate(Ornament, classification.transform.position, Quaternion.Euler(0, 90, 0));
            }
        }
    }
}
