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

    OVRSceneManager ovrSceneManager;

    //[SerializeField] GameObject plane;
    private void Awake()
    {
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();

        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
    }

    void onAnchorsLoaded()
    {
        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach (var classification in classifications)
        {
            if (classification.Contains(OVRSceneManager.Classification.Bed))
            {
                Instantiate(Case, classification.transform.position, Quaternion.identity);
            }
            if (classification.Contains(OVRSceneManager.Classification.Lamp))
            {
                Instantiate(Case2, classification.transform.position, Quaternion.identity);
            }
        }
    }
}
