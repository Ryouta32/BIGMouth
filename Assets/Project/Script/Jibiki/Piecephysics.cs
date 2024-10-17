using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* ドラゴン登場時の壁の挙動 */

public class Piecephysics : MonoBehaviour
{
    [SerializeField] Material PieceMaterial;
    GameObject obj;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //obj = transform.GetChild(0).gameObject;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Dragon"))
        {
            rb.isKinematic = false;
            gameObject.GetComponent<MeshRenderer>().material = PieceMaterial;
        }
    }
}
