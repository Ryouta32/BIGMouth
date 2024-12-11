using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* 部屋のオブジェクトを取得して生成させる */

public class DragonSpawn : MonoBehaviour
{
    OVRSceneManager ovrSceneManager;
    [SerializeField] Material m;
    GameObject dragon;
    GameObject storage;
    //[SerializeField] GameObject cube;
    Transform myTransform;

    [SerializeField] TextMeshProUGUI textText;

    private void Awake()
    {
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        dragon = GameObject.Find("Cube");
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
            if(classification.Contains(OVRSceneManager.Classification.Storage))
            {
                Transform myTransform = classification.transform;
                Transform draTransform = dragon.transform;
                Vector3 localPos;

                localPos.x = 0f;    // ローカル座標を基準にした、x座標を1に変更
                localPos.y = 0f;    // ローカル座標を基準にした、y座標を1に変更
                localPos.z = 5.0f;    // ローカル座標を基準にした、z座標を1に変更
                draTransform.localPosition = localPos; // ローカル座標での座標を設定

                draTransform.Translate(localPos);

                classification.GetComponent<MeshRenderer>().material = m;

                dragon.transform.position = classification.transform.position;
                dragon.transform.rotation = Quaternion.Euler(0f, 180f, 0);
                //textText.text = classification.transform.localEulerAngles.ToString();
            }
        }
    }
}
