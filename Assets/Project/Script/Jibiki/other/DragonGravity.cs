using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonGravity : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Vector3 power;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(power);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    rb.isKinematic = false;
    //}
}
