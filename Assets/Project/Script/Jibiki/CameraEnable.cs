using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*UI���I�u�W�F�N�g�ɖ�����Ȃ��悤�ɂ���*/

public class CameraEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().enabled = false;
        GetComponent<Camera>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
