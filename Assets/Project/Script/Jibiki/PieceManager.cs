using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*�v���C���̕ǂ�����Ă�������*/

public class PieceManager : MonoBehaviour
{
    [SerializeField] GameObject PieceParent;
    [SerializeField] Material PieceMaterial;
    [SerializeField] Vector3 power;
    List<Transform> PieceChildren;
    MeshRenderer mr;


    void Start()
    {
        PieceChildren = new List<Transform>();

        for (int i = 0; i < PieceParent.transform.childCount; i++)
        {
            PieceChildren.Add(PieceParent.transform.GetChild(i)); // GetChild()�Ŏq�I�u�W�F�N�g���擾
            //Debug.Log($"�������@�P�F {i} �Ԗڂ̎q���� {PieceChildren[i].name} �ł�");
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

        obj = PieceChildren[rnd].transform.GetChild(0).gameObject.GetComponent<Rigidbody>();

        if(obj.isKinematic)
        {
            obj.isKinematic = false;
            PieceChildren[rnd].transform.GetChild(0).gameObject.GetComponent<BoxCollider>().isTrigger = true;
            PieceChildren[rnd].transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = PieceMaterial;
            PieceChildren[rnd].gameObject.GetComponent<MeshRenderer>().enabled = true;
            PieceChildren[rnd].gameObject.GetComponent<BoxCollider>().enabled = true;
            obj.AddForce(power);

            PieceChildren.Remove(PieceChildren[rnd]);
        }
        else
        {
            CancelInvoke();
        }
    }
}
