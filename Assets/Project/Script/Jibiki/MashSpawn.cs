using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* 部屋のオブジェクトを取得して生成させる */

public class MashSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    [SerializeField] GameObject kinokoprefab;
    [SerializeField] TextMeshProUGUI textText;

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
            if(classification.Contains(OVRSceneManager.Classification.Bed))
            {
                //classification.GetComponent<MeshRenderer>().material = m;

                Instantiate(kinokoprefab, classification.transform.position, Quaternion.identity);

                //textText.text = classification.transform.localEulerAngles.ToString();
            }
        }
    }
}
