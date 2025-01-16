using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRSizeSet : MonoBehaviour
{
    [SerializeField] Vector3 size;
    [SerializeField]GameObject obj;
    [SerializeField] Vector3 rotate;
    GameObject mark;
    void Start()
    {
        AudioManager.manager.PlayPoint(AudioManager.manager.data.announce, gameObject);
        transform.parent = null;
        transform.localScale = size ;
        mark = Instantiate(obj, transform.position, Quaternion.identity);
        //game.transform.parent = this.gameObject.transform;
        mark.transform.localScale = size ;
        mark.transform.localEulerAngles = rotate;
    }

}
