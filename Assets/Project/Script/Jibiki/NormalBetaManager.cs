using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 中ベタのスポーン */

public class NormalBetaManager : MonoBehaviour
{
    [Tooltip("スポーン位置")]
    [SerializeField] GameObject SpawnPoint;
    Animator anim;
    int number;

    [HideInInspector]
    public List<Transform> Children;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        Children = new List<Transform>();

        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Children.Add(SpawnPoint.transform.GetChild(i)); // GetChild()で子オブジェクトを取得
            //Debug.Log($"検索方法１： {i} 番目の子供は {PieceChildren[i].name} です");
        }

        //スタート時の位置
        number = Random.Range(0, Children.Count);
        gameObject.transform.position = new Vector3(Children[number].transform.position.x, 0.45f, Children[number].transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //これはupdateでやる必要はないと思う
        Children.Clear();
        for (int i = 0; i < SpawnPoint.transform.childCount; i++)
        {
            Children.Add(SpawnPoint.transform.GetChild(i)); // GetChild()で子オブジェクトを取得
            //Debug.Log($"検索方法１： {i} 番目の子供は {PieceChildren[i].name} です");
        }
    }

    //スポーン位置の選択
    void SpawnSelect()
    {
        //number = Random.Range(0, Children.Count);
        number = GetRandomValue(number);

        //ここのｙ座標どうしたいいのかあんまりわかってないよ
        gameObject.transform.position = new Vector3(Children[number].transform.position.x, 0.45f, Children[number].transform.position.z);

        anim.SetBool("Down", false);

        //Debug.Log("number：" + number);
        //Debug.Log("移動した！");
    }

    //同じところにスポーンするのを防ぐ
    int GetRandomValue(int oldNum)
    {
        int newNum = Random.Range(0, Children.Count);

        // 古い番号と同じとき
        if (newNum == oldNum)
        {
            int n = newNum + Random.Range(1, Children.Count);

            return n < Children.Count ? n : n - Children.Count;
        }
        else
        {
            return newNum;
        }
    }
}
