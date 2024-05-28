using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouSakiScript : MonoBehaviour
{
    [SerializeField] bouScript bouSC;
    [SerializeField] Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "HA")
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        
    }
}
