using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* プレイ中の壁が(時間経過)崩れていく挙動 */

public class WallPiece : MonoBehaviour
{
    [Tooltip("崩れる時のマテリアル")]
    [SerializeField] Material PieceMaterial;

    [Tooltip("崩れるときのちから")]
    [SerializeField] float power;

    [Tooltip("開始するまでの秒数")]
    [SerializeField] float StartTime;

    [Tooltip("次が落ちるまでの秒数")]
    [SerializeField] float waittime;

    [Tooltip("オブジェクトを消す秒数")]
    [SerializeField] float destroytime;

    //ピースの親オブジェクト
    GameObject PieceParent;

    //ピースのリスト
    List<Transform> PieceChildren = new List<Transform>();

    void Start()
    {
        PieceParent = this.gameObject;
        //リスト追加
        for (int i = 0; i < PieceParent.transform.childCount; i++)
        {
            PieceChildren.Add(PieceParent.transform.GetChild(i).GetChild(0)); // GetChild()で子オブジェクトを取得
            //Debug.Log($"検索方法１： {i} 番目の子供は {PieceChildren[i].name} です");
        }
        StartCoroutine("FallPiece");
    }

    IEnumerator FallPiece()
    {
        yield return new WaitForSeconds(StartTime);

        while (true)
        {
            yield return new WaitForSeconds(waittime);
            Rigidbody obj;

            int rnd = Random.Range(0, PieceChildren.Count);

            if (PieceChildren.Count > 0)
            {
                obj = PieceChildren[rnd].gameObject.GetComponent<Rigidbody>();

                if (!obj)
                {
                    //落ちるオブジェクトのリジットボディ取得
                    obj = PieceChildren[rnd].gameObject.AddComponent<Rigidbody>();
                    obj.isKinematic = true;
                }
                else
                {
                    obj.isKinematic = true;
                }

                if (obj.isKinematic)
                {
                    //キネマティックオフにして重力付ける
                    obj.isKinematic = false;

                    //マテリアルを壁色にする
                    PieceChildren[rnd].gameObject.GetComponent<MeshRenderer>().material = PieceMaterial;

                    //少しちからを入れる
                    obj.AddForce(transform.up * power, ForceMode.Impulse);

                    //落ちたオブジェクトはリストから削除
                    PieceChildren.Remove(PieceChildren[rnd]);
                    Destroy(obj.gameObject, destroytime);
                }
            }
        }
    }

    public void AddItem(Transform item)
    {
        PieceChildren.Add(item);
    }
}
