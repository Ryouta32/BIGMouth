using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRSizeSet : MonoBehaviour
{
    [SerializeField] Vector3 size;
    [SerializeField]GameObject obj;
    GameObject mark;
    void Start()
    {
        transform.parent = null;
        transform.localScale = size ;
        mark = Instantiate(obj, transform.position, Quaternion.identity);
        //game.transform.parent = this.gameObject.transform;
        mark.transform.localScale = size ;
    }

}
