using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* プレイ中の壁が(時間経過)崩れていく挙動 */

public class PieceManager : MonoBehaviour
{
    [Tooltip("崩れる時のマテリアル")]
    [SerializeField] Material PieceMaterial;

    [Tooltip("崩れるときのちから")]
    [SerializeField] float power;

    [Tooltip("崩れるときのちから")]
    [SerializeField] Vector3 betapower;

    //[Tooltip("呼び出す間隔")]
    //[SerializeField] float RepeatTime;

    [Tooltip("開始するまでの秒数")]
    [SerializeField] float StartTime;

    [Tooltip("オブジェクトを消す秒数")]
    [SerializeField] float destroytime;

    [Tooltip("オブジェクトを消す秒数")]
    [SerializeField] float waittime;

    [SerializeField] GameObject beta;
    Rigidbody betarb;

    //ピースの親オブジェクト
    GameObject PieceParent;

    //ピースのメッシュレンダラー
    MeshRenderer mr;

    //ピースのリスト
    [HideInInspector]
    public List<Transform> PieceChildren = new List<Transform>();

    [HideInInspector]
    public bool childFlag;

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
        //InvokeRepeating(nameof(FallPiece), StartTime, RepeatTime);
    }

    //void FallPiece()
    //{
        //Rigidbody obj;

        //int rnd = Random.Range(0, PieceChildren.Count);

        //if (PieceChildren.Count > 0)
        //{
        //    obj = PieceChildren[rnd].gameObject.GetComponent<Rigidbody>();

        //    if (!obj)
        //    {
        //        //落ちるオブジェクトのリジットボディ取得
        //        obj = PieceChildren[rnd].gameObject.AddComponent<Rigidbody>();
        //        obj.isKinematic = true;
        //    }
        //    else
        //    {
        //        obj.isKinematic = true;
        //    }

        //    if (obj.isKinematic)
        //    {
        //        //キネマティックオフにして重力付ける
        //        obj.isKinematic = false;

        //        //マテリアルを壁色にする
        //        PieceChildren[rnd].gameObject.GetComponent<MeshRenderer>().material = PieceMaterial;

        //        //少しちからを入れる
        //        obj.AddForce(power);

        //        if(beta != null)
        //        {
        //            betarb = beta.GetComponent<Rigidbody>();
        //            Instantiate(beta, PieceChildren[rnd].gameObject.transform.position, Quaternion.Euler(180, 0, 0));
        //            betarb.AddForce(betapower);
        //        }

        //        Debug.Log("おちたーーーーーーーーーーーーーーー" + PieceChildren[rnd].name);

        //        //落ちたオブジェクトはリストから削除
        //        PieceChildren.Remove(PieceChildren[rnd]);
        //        Destroy(obj.gameObject, destroytime);
        //    }
        //}
        //else
        //{
        //    Debug.Log("やめたーーーーーーーーー");
        //    //いんぼけやめる
        //    CancelInvoke();

        //    //ゲームオーバーシーンに行く
        //    SceneManager.LoadScene("GameOverScene");
        //}
    //}

    IEnumerator FallPiece()
    {
        ClearList();
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

                    if (beta != null)
                    {
                        //betarb = beta.GetComponent<Rigidbody>();
                        Instantiate(beta, PieceChildren[rnd].gameObject.transform.position + transform.up, Quaternion.identity);
                        //betarb.AddForce(transform.up * power, ForceMode.Impulse);
                    }

                    Debug.Log("おちたーーーーーーーーーーーーーーー" + PieceChildren[rnd].name);

                    //落ちたオブジェクトはリストから削除
                    PieceChildren.Remove(PieceChildren[rnd]);
                    Destroy(obj.gameObject, destroytime);
                }

                //警告音鳴らす
                if(PieceChildren.Count < PieceChildren.Count / 2)
                {
                    AudioManager.manager.PlayPoint(AudioManager.manager.data.stageEnergency, this.gameObject);
                }
            }
            else
            {
                Debug.Log("やめたーーーーーーーーー");
                //いんぼけやめる
                CancelInvoke();

                //ゲームオーバーシーンに行く
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    public void AddItem(Transform item)
    {
        PieceChildren.Add(item);
    }

    public void RemoveItem(Transform item)
    {
        PieceChildren.Remove(item);
    }

    public void ClearList()
    {
        PieceChildren.Clear();
    }
}
