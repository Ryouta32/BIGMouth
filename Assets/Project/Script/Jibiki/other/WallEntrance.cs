using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*壁に当たった時に*/

public class WallEntrance : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer mr;
    [SerializeField] Material PieceMaterial;

    [Tooltip("崩れるときのちから")]
    [SerializeField] Vector3 power;

    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        Debug.Log("追加！！！！！！！！");
    //        if (!collision.gameObject.GetComponent<Rigidbody>())
    //        {
    //            mr = collision.gameObject.GetComponent<MeshRenderer>();
    //            mr.material = PieceMaterial;

    //            rb = collision.gameObject.AddComponent<Rigidbody>();
    //            //rb.useGravity = false;

    //            rb.AddForce(power);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("追加！！！！！！！！");
            if (!other.gameObject.GetComponent<Rigidbody>())
            {
                mr = other.gameObject.GetComponent<MeshRenderer>();
                mr.material = PieceMaterial;

                rb = other.gameObject.AddComponent<Rigidbody>();
                //rb.useGravity = false;

                rb.AddForce(power);
            }
        }
    }
}
