using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BetaSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] float time = 5.0f;
    [SerializeField] private GameObject rightControllerPivot;

    Vector3 objectSize;
    float x, z;

    EnemyManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //OVRScenePlane floor = sceneRoom.Floor;

        // Rendererコンポーネントを取得
        //Renderer renderer = GetComponent<Renderer>();

        // オブジェクトのサイズを取得
        //objectSize = renderer.bounds.size;

        // サイズをログに出力
        //Debug.Log("Object Size: " + objectSize);

        x = objectSize.x / 2;
        z = objectSize.z / 2;

        // time秒ごとにSpawn呼び出す
        //InvokeRepeating(nameof(Spawn), 1, time);

        StartCoroutine("Spawn");
        Debug.Log("x:" + x + "z:" + z);

        manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    IEnumerator Spawn()
    {
        Debug.Log("waai");
        yield return new WaitForSeconds(time);

        // 角度ランダム生成

        int rnd = Random.Range(0, 360);
        GameObject obj = Instantiate(spawnPrefab, rightControllerPivot.transform.position, Quaternion.Euler(0, rnd, 0), manager.gameObject.transform);
        obj.GetComponent<EnemyScript>().setManager(manager);
        obj.GetComponent<EnemyScript>().initialization();
        manager.AddEnemys(obj);//Managerのリストに追加
                               //DebugText.Log2(transform.position);
        if (manager.SpawnCheck())
        {
            StartCoroutine("Spawn");
        }
    }
}
