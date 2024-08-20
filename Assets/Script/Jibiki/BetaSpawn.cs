using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaSpawn : MonoBehaviour
{
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] float time = 5.0f;

    Vector3 objectSize;
    float x, z;

    // Start is called before the first frame update
    void Start()
    {
        //OVRSceneRoom sceneRoom = FindAnyObjectByType<OVRSceneRoom>();
        //OVRScenePlane floor = sceneRoom.Floor;

        // オブジェクトのRendererコンポーネントを取得
        Renderer renderer = GetComponent<Renderer>();

        // オブジェクトのサイズを取得
        objectSize = renderer.bounds.size;

        // サイズをログに出力
        //Debug.Log("Object Size: " + objectSize);

        x = objectSize.x / 2;
        z = objectSize.z / 2;

        // time秒ごとにSpawn呼び出す
        InvokeRepeating(nameof(Spawn), 1, time);

        Debug.Log("x:" + x + "z:" + z);
    }

    void Spawn()
    {
        // 角度ランダム生成
        int rnd = Random.Range(0, 360);
        Instantiate(spawnPrefab, new Vector3(x, 1, z), Quaternion.Euler(0, rnd, 0));
    }
}
