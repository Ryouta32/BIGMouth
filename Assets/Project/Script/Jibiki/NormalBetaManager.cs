using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 中ベタの動き */

public class NormalBetaManager : MonoBehaviour
{
    [Tooltip("スポーン位置")]
    [SerializeField] GameObject[] SpawnPoint;
    Animator anim;
    int number;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnSelect()
    {
        number = Random.Range(0, SpawnPoint.Length);
        gameObject.transform.position = new Vector3(SpawnPoint[number].transform.position.x, 0, SpawnPoint[number].transform.position.z);
    }
}
