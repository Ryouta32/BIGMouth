using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* プレイ中の天井が(時間経過)崩れていく挙動 */

public class PieceManager : MonoBehaviour
{
    [Tooltip("崩れる時のマテリアル")]
    [SerializeField] Material PieceMaterial;

    [Tooltip("開始するまでの秒数")]
    [SerializeField] float StartTime;

    [Tooltip("次が落ちるまでの秒数")]
    [SerializeField] float waittime;

    [Tooltip("オブジェクトを消す秒数")]
    [SerializeField] float destroytime;

    //ベタが出てくるタイミング
    [SerializeField] int fallcount;

    [Tooltip("生成するベタ")]
    [SerializeField] GameObject beta;

    Animation Fadeanim;

    Image UI_HP;

    //ピースの親オブジェクト
    GameObject PieceParent;

    //ピースのリスト
    List<Transform> PieceChildren = new List<Transform>();

    //ゲームオーバーのフラッグ
    bool childFlag;

    //UIの最大値
    float piececount;

    CanvasChange cc;

    float count;

    void Start()
    {
        PieceParent = this.gameObject;

        childFlag = true;

        UI_HP = GameObject.Find("HP").GetComponent<Image>();
        cc = GameObject.Find("CanvasChange").GetComponent<CanvasChange>();
        Fadeanim = GameObject.Find("RedFade").GetComponent<Animation>();

        //リスト追加
        for (int i = 0; i < PieceParent.transform.childCount; i++)
        {
            PieceChildren.Add(PieceParent.transform.GetChild(i).GetChild(0)); // GetChild()で子オブジェクトを取得
            //Debug.Log($"検索方法１： {i} 番目の子供は {PieceChildren[i].name} です");
        }
        piececount = PieceChildren.Count;

        StartCoroutine("FallPiece");
    }
    private void Update()
    {
        count = waittime - BetaText.betacount;
    }

    IEnumerator FallPiece()
    {
        yield return new WaitForSeconds(StartTime);

        while (true)
        {
            yield return new WaitForSeconds(count);
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

                    count++;

                    //警告音鳴らす
                    if (UI_HP.fillAmount < 0.5 && count == fallcount)
                    {
                        AudioManager.manager.PlayPoint(AudioManager.manager.data.stageEnergency, this.gameObject);
                        Fadeanim.Play("RedFade");
                    }

                    if (beta != null && count == fallcount)
                    {
                        int rot = Random.Range(0, 360);
                        Instantiate(beta, PieceChildren[rnd].gameObject.transform.position + transform.up, Quaternion.Euler(0, rot, 0));
                        BetaText.betacount++;
                        count = 0;
                    }

                    //落ちたオブジェクトはリストから削除
                    PieceChildren.Remove(PieceChildren[rnd]);
                    UI_HP.fillAmount = PieceChildren.Count / piececount;
                    Destroy(obj.gameObject, destroytime);
                }
            }

            var classifications = FindObjectsByType<OVRSemanticClassification>(FindObjectsSortMode.None);

            foreach (var classification in classifications)
            {
                if (classification.Contains(OVRSceneManager.Classification.Ceiling))
                {
                    if (PieceChildren.Count <= 0 && childFlag)
                    {
                        childFlag = false;
                        cc.Phase[0] = false;
                        cc.Phase[2] = true;
                        AudioManager.manager.PlayPoint(AudioManager.manager.data.stageEnergency, this.gameObject, 5);
                    }
                    else if(PieceChildren.Count <= 0)
                    {
                        Fadeanim.Play("RedFade");
                    }
                }
            }
        }
    }

    public void AddItem(Transform item)
    {
        PieceChildren.Add(item);
    }
}
