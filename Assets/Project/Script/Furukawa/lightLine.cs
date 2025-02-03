using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightLine : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 tra;
    ParticleSystem ps;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
            var sp = ps.shape;
            sp.position = pos;
            //transform.localPosition = new Vector3(0,1,0);
    }
    public void setPos(Vector3 x) => pos = x;

}
