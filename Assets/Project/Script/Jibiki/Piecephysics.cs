﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* ドラゴン登場時の壁の挙動 */

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

<<<<<<< HEAD
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Dragon"))
=======
    // Update is called once per frame
    void Update()
    {
        if(!rb.isKinematic)
>>>>>>> main
        {
            mr.enabled = true;
        }
    }
}
