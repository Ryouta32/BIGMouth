using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrancePlane : MonoBehaviour
{
    [SerializeField] Vector3 power;
    [SerializeField] Material PieceMaterial;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.isKinematic = false;
        gameObject.GetComponent<MeshRenderer>().material = PieceMaterial;
        gameObject.transform.parent.GetComponent<MeshRenderer>().enabled = true;
        rb.AddForce(power);

        //if (other.gameObject.CompareTag("MIMIC"))
        //{
        //    rb.isKinematic = false;
        //    gameObject.GetComponent<MeshRenderer>().material = PieceMaterial;
        //    gameObject.transform.parent.GetComponent<MeshRenderer>().enabled = true;
        //    rb.AddForce(power);
        //}
    }
}
