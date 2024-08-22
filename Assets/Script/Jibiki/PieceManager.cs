using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] GameObject PieceParent;
    List<Transform> PieceChildren;

    void Start()
    {
        PieceChildren = new List<Transform>();

        for (int i = 0; i < PieceParent.transform.childCount; i++)
        {
            PieceChildren.Add(PieceParent.transform.GetChild(i)); // GetChild()で子オブジェクトを取得
            //Debug.Log($"検索方法１： {i} 番目の子供は {PieceChildren[i].name} です");
        }

        InvokeRepeating(nameof(FallPiece), 5.0f, 5.0f);
    }

    void Update()
    {
    }

    void FallPiece()
    {
        Rigidbody obj;

        int rnd = Random.Range(0, PieceChildren.Count);

        obj = PieceChildren[rnd].gameObject.GetComponent<Rigidbody>();

        obj.isKinematic = false;

        PieceChildren.Remove(PieceChildren[rnd]);
    }
}
