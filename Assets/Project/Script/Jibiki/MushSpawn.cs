using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 部屋のオブジェクトを取得して生成させる */

public class MashSpawn : MonoBehaviour
{
    //[SerializeField] GameObject kinokoprefab;
    //[SerializeField] GameObject tentacleprefab;
    [SerializeField] GameObject Tutorial;
    //[SerializeField] EnemyManager manager;

    OVRSceneManager ovrSceneManager;
    OVRScenePlane floor;
    GameObject dragonprefab;
    [HideInInspector]
    public List<Transform> NormalObj = new List<Transform>();
    [HideInInspector]
    public Vector3 tutorialpos;
    [SerializeField]
    GameObject camerac;

    //[SerializeField] GameObject plane;
    private void Awake()
    {
        dragonprefab = GameObject.Find("DragonPrefab");
        ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();

        //ルーム設定の読み込みが成功した時のコールバック登録
        ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
        dragonprefab.transform.position = camerac.transform.position + new Vector3(0, 0, 5);

    }
    //private void OnEnable()
    //{
    //    dragonprefab = GameObject.Find("DragonPrefab");
    //    ovrSceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
    //    //ルーム設定の読み込みが成功した時のコールバック登録
    //    ovrSceneManager.SceneModelLoadedSuccessfully += onAnchorsLoaded;
    //}

    void onAnchorsLoaded()
    {
        //OVRSceneRoomの参照取得
        OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //床
        floor = sceneRoom.Floor;
        float posy = floor.transform.position.y + 0.1f;

        floor.transform.position = new Vector3(floor.transform.position.x, posy + 0.5f, floor.transform.position.z);
        //Instantiate(plane, floor.transform.position, Quaternion.identity);
        var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

        foreach　(var classification in classifications)
        {
            ////キノコ
            //if　(classification.Contains(OVRSceneManager.Classification.Bed))
            //{
            //    Vector3 pos = new Vector3(classification.transform.position.x, posy, classification.transform.position.z);
            //    EnemyManager.mashPos=pos;
            //    if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1f, LayerMask.GetMask("Wall")))
            //    {
            //        transform.position = hit.point;
            //        GameObject obj = Instantiate(kinokoprefab, pos, Quaternion.identity);
            //        obj.GetComponent<EnemyScript>().setManager(manager);
            //        NormalObj.Add(obj.transform);
            //        obj.SetActive(false);
            //    }
            //    else
            //    {
            //        GameObject obj = Instantiate(kinokoprefab, pos, Quaternion.identity);
            //        obj.GetComponent<EnemyScript>().setManager(manager);
            //        NormalObj.Add(obj.transform);
            //        obj.SetActive(false);
            //    }
            //}

            ////触手
            //if (classification.Contains(OVRSceneManager.Classification.Lamp))
            //{
            //    Vector3 pos = new Vector3(classification.transform.position.x, posy, classification.transform.position.z);
            //    EnemyManager.tentPos = pos;

            //    if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1f, LayerMask.GetMask("Wall")))
            //    {
            //        transform.position = hit.point;
            //        GameObject obj = Instantiate(tentacleprefab, pos, Quaternion.identity);
            //        obj.GetComponent<EnemyScript>().setManager(manager);
            //        NormalObj.Add(obj.transform);
            //        obj.SetActive(false);
            //    }
            //    else
            //    {
            //        GameObject obj = Instantiate(tentacleprefab, pos, Quaternion.identity);
            //        obj.GetComponent<EnemyScript>().setManager(manager);
            //        NormalObj.Add(obj.transform);
            //        obj.SetActive(false);
            //    }
            //}

            ////ドラゴンの生成位置
            //if (classification.Contains(OVRSceneManager.Classification.Storage))
            //{
            //    //Vector3 pos = new Vector3(classification.transform.position.x, posy + 1.0f, classification.transform.position.z + 2f);
            //    Vector3 pos = new Vector3(classification.transform.position.x, classification.transform.position.y, classification.transform.position.z);
            //    //dragonprefab.transform.position = pos;

            //    //if (Physics.Raycast(dragonprefab.transform.position, transform.forward, out RaycastHit hit, 10f, LayerMask.GetMask("Wall")))
            //    //{
            //    //    Quaternion hitRotation = hit.transform.rotation;
            //    //    dragonprefab.transform.rotation = hitRotation;
            //    //}
            //}

            //チュートリアルオブジェクト
            if (classification.Contains(OVRSceneManager.Classification.Table))
            {
                tutorialpos = new Vector3(classification.transform.position.x, classification.transform.position.y, classification.transform.position.z);
                Vector3 pos = new Vector3(classification.transform.position.x, classification.transform.position.y, classification.transform.position.z);
                //Instantiate(Tutorial, pos, Quaternion.identity);
                Tutorial.transform.position = pos;
            }
        }
    }

    //チュートリアルが終わったら中ベタ表示させる
    public void ActiveObj()
    {
        for(int i = 0; i < NormalObj.Count; i++)
        {
            NormalObj[i].transform.gameObject.SetActive(true);
        }
    }
}
