using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightLine : MonoBehaviour
{
    private Vector3 pos;
    ParticleSystem ps;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        var sp = ps.shape;
        sp.position = pos;
    }
    public void setPos(Vector3 x)=>pos = x;
}
