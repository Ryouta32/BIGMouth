using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateReset : MonoBehaviour
{
    [SerializeField] Vector3 rotate;
    [SerializeField] Vector3 move;
    [SerializeField] Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = transform.position + move;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = rotate;
        transform.localScale = scale;
    }
}
