using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaEntry : MonoBehaviour
{
    [SerializeField] GameObject beta;
    [SerializeField] Vector3 power;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = beta.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Betapush()
    {
        rb.AddForce(power);
    }
}
