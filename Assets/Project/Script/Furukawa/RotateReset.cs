﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateReset : MonoBehaviour
{
    [SerializeField] Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = rotate;
    }
}
