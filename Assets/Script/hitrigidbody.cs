using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitrigidbody : MonoBehaviour
{
    Rigidbody rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("MIMIC"))
        {
            rd.useGravity = true;
            Destroy(gameObject, 1.0f);
        }
    }
}
