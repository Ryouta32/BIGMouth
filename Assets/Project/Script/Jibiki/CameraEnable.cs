﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* UIがオブジェクトに埋もれないようにする */

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
