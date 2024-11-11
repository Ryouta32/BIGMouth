using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* プレイ中の壁が(時間経過)崩れていく挙動 */

public class PieceManager : MonoBehaviour
{
    [Tooltip("崩れる時のマテリアル")]
    [SerializeField] Material PieceMaterial;

    [Tooltip("崩れるときのちから")]
    [SerializeField] Vector3 power;

    [Tooltip("呼び出す間隔")]
    [SerializeField] float RepeatTime = 5.0f;

    [Tooltip("開始するまでの秒数")]
    [SerializeField] float StartTime = 5.0f;

    //ピースの親オブジェクト
    GameObject PieceParent;

    //ピースのメッシュレンダラー
    MeshRenderer mr;

    //ピースのリスト
    List<Transform> PieceChildren;

    void Start()
    {
        PieceParent = this.gameObject;

        //初期化
        PieceChildren = new List<Transform>();

        //リスト追加
        for (int i = 0; i < PieceParent.transform.childCount; i++)
        {
            PieceChildren.Add(PieceParent.transform.GetChild(i)); // GetChild()で子オブジェクトを取得
            //Debug.Log($"検索方法１： {i} 番目の子供は {PieceChildren[i].name} です");
        }

        InvokeRepeating(nameof(FallPiece), StartTime, RepeatTime);
    }

    void FallPiece()
    {
        Rigidbody obj;

        int rnd = Random.Range(0, PieceChildren.Count);

        //落ちるオブジェクトのリジットボディ取得
        obj = PieceChildren[rnd].gameObject.GetComponent<Rigidbody>();

        if(obj.isKinematic)
        {
            //キネマティックオフにして重力付ける
            obj.isKinematic = false;

            //マテリアルを壁色にする
            PieceChildren[rnd].gameObject.GetComponent<MeshRenderer>().material = PieceMaterial;

            //少しちからを入れる
            obj.AddForce(power);

            //落ちたオブジェクトはリストから削除
            PieceChildren.Remove(PieceChildren[rnd]);
        }
        else
        {
            //いんぼけやめる
            CancelInvoke();
        }
    }
}
