using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* ドラゴンが当たってきたら色変える*/

public class piece : MonoBehaviour
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dragon"))
        {
            mr.material = PieceMaterial;
        }
    }
}
