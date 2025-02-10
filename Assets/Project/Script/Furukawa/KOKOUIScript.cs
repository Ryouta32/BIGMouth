using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KOKOUIScript : MonoBehaviour
{
    [SerializeField] tutorialScript tutorialScript;
    [SerializeField] GameObject main;
    private void Start()
    {
        tutorialScript = GameObject.Find("tutorial").GetComponent<tutorialScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Brush")
        {
            tutorialScript.KOKO();
            Destroy(main);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Brush")
        {
        //AudioManager.manager.Play(AudioManager.manager.data.debug);
            tutorialScript.KOKO();
            Destroy(main);
        }
    }
}
