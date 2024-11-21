using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveScript : MonoBehaviour
{

    MeshRenderer tex;
    float pro=0;
    [SerializeField]float speed = 5;
    private void Start()
    {
        tex = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        pro += Time.deltaTime*speed;
        tex.material.SetFloat("_Progress", pro);

        if (pro >= 11)
            Destroy(this.gameObject);
    }
}
