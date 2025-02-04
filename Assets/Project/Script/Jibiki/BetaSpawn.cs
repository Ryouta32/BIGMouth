﻿using System.Collections;
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

        x = objectSize.x / 2;
        z = objectSize.z / 2;


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
            int rnd = Random.Range(0, 360);
            if(BetaText.betacount <= 10)
            {
                GameObject obj = Instantiate(spawnPrefab, spawnPos.transform.position, Quaternion.Euler(0, rnd, 0), manager.gameObject.transform);
                BetaText.betacount++;
                if (obj.GetComponent<EnemyScript>())
                {
                    obj.GetComponent<EnemyScript>().setManager(manager);
                    obj.GetComponent<EnemyScript>().initialization();
                    obj.GetComponent<Rigidbody>().AddForce(spawnPos.transform.forward.normalized * 300);
                }
            }
        }
    }
}
