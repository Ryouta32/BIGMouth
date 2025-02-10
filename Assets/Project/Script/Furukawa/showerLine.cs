using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showerLine : MonoBehaviour
{

    Transform target;
    BouSakiScript saki;
    float point;
    Vector3 pos;
    ParticleSystem ps;
    ParticleSystem.ShapeModule sp;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
            sp = ps.shape;
    }
    private void Update()
    {
        if(target != null)
        {
            pos = (target.position - transform.position );
            sp.position = pos;
        }
    }
    public void SetPotision(float _point,Transform tra,BouSakiScript _saki)
    {
        point = _point;
        target = tra;
        saki = _saki;
    }
}
