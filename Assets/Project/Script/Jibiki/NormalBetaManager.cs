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

        //スタート時の位置
        number = Random.Range(0, SpawnPoint.Length);
        gameObject.transform.position = new Vector3(SpawnPoint[number].transform.position.x, 0.45f, SpawnPoint[number].transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //スポーン位置の選択
    void SpawnSelect()
    {
        //はたしてRandomになっているのか
        number = Random.Range(0, SpawnPoint.Length);

        //ここのｙ座標どうしたいいのかあんまりわかってないよ
        gameObject.transform.position = new Vector3(SpawnPoint[number].transform.position.x, 0.45f, SpawnPoint[number].transform.position.z);
        anim.SetBool("Down", false);

        //Debug.Log("number：" + number);
        //Debug.Log("移動した！");
    }
}
