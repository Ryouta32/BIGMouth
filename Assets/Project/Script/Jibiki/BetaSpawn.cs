using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BetaSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] float time = 5.0f;
    [SerializeField] private GameObject spawnPos;

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

        Debug.Log("x:" + x + "z:" + z);

        manager = gameObject.GetComponent<EnemyManager>();
    }

    public void spawan()
    {
        StartCoroutine("Spawn");
    }
    IEnumerator Spawn()
    {
        while (true)
        {

            yield return new WaitForSeconds(time);

            // 角度ランダム生成

            if(manager.SpawnCheck())
                break;
            int rnd = Random.Range(0, 360);
            GameObject obj = Instantiate(spawnPrefab, spawnPos.transform.position, Quaternion.Euler(0, rnd, 0), manager.gameObject.transform);
            if (obj.GetComponent<EnemyScript>())
            {
                obj.GetComponent<EnemyScript>().setManager(manager);
                obj.GetComponent<EnemyScript>().initialization();
                obj.GetComponent<Rigidbody>().AddForce(spawnPos.transform.forward.normalized * 300);
                manager.AddEnemys(obj);//Managerのリストに追加
            }
            }
        }
}
