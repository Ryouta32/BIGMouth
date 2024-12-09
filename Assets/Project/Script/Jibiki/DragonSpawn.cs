using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class DragonSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    [SerializeField] Material m;
    [SerializeField] GameObject dragon;

    private void Awake()
    {
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onAnchorsLoaded()
    {
        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach(var classification in classifications)
        {
            if(classification.Contains(OVRSceneManager.Classification.Floor))
            {
                gameObject.GetComponent<MeshRenderer>().material = m;

                dragon.transform.position = classification.transform.position;
            }
        }
    }
}
