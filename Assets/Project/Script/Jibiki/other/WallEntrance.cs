using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*壁に当たった時に*/

public class WallEntrance : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer mr;
    [SerializeField] Material PieceMaterial;

    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb = collision.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;

        mr = collision.gameObject.GetComponent<MeshRenderer>();
        mr.material = PieceMaterial;

        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    rb = collision.gameObject.AddComponent<Rigidbody>();
        //    rb.useGravity = false;
        //}
    }
}
