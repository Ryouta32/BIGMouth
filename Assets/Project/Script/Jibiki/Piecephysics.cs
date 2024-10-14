using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*ƒhƒ‰ƒSƒ““oê‚Ì•Ç‚Ì‹““®*/

public class Piecephysics : MonoBehaviour
{
    GameObject obj;
    Rigidbody rb;
    MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        obj = transform.GetChild(0).gameObject;
        rb = obj.GetComponent<Rigidbody>();
        mr = obj.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!rb.isKinematic)
        {
            mr.enabled = true;
        }
    }
}
