using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOKOUIScript : MonoBehaviour
{
    [SerializeField] tutorialScript tutorialScript;
    private void Start()
    {
        tutorialScript = GameObject.Find("tutorial").GetComponent<tutorialScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Brush")
        {
            tutorialScript.KOKO();
            Destroy(transform.root.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brush")
        {
            tutorialScript.KOKO();
            Destroy(transform.root.gameObject);
        }
    }
}
