using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* ドラゴンが当たってきたら色変える*/

public class Piecephysics : MonoBehaviour
{
    [SerializeField] Material PieceMaterial;
    MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        mr = gameObject.GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dragon"))
        {
            mr.material = PieceMaterial;
        }
    }
}
