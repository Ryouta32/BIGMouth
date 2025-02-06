using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class TutorialSpawn : MonoBehaviour
{
    [SerializeField] tutorialScript Tutorial;
    [SerializeField] GameObject Main;

    OVRSceneManager ovrSceneManager;
    OVRScenePlane floor;

    RectTransform rect;
    float posy;

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
        posy = floor.transform.position.y+0.1f;

        //rect = GetComponent<RectTransform>();
        //rect.position = new Vector3(0, posy, 1.5f);

        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.WallArt))
            {
                Vector3 pos = new Vector3(classification.transform.position.x, floor.transform.position.y + 1.4f, classification.transform.position.z);
                GameObject obj = Instantiate(Main, pos, Quaternion.identity);
                obj.transform.localEulerAngles = new Vector3(0, 90, 0);
                Tutorial.setStageAnima(obj.GetComponent<Animator>());
            }
        }
    }
}
